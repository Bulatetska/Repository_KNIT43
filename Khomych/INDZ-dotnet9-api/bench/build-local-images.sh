#!/usr/bin/env bash
# Збирає образи без MCR/Docker Hub: rootfs формується з кореня Ubuntu 25.10 ($R),
# де встановлені dotnet-sdk-9.0 і dotnet-sdk-aot-9.0. Використано лише на цьому стенді.
# На звичайній машині беріть docker/Dockerfile.* (офіційні образи Microsoft).
set -euo pipefail
R=${R:-/opt/sdkroot}; W=${W:-/var/tmp/rootfs}; P="$(cd "$(dirname "$0")/.." && pwd)/publish"
copy_libs() { # $1 = dest, решта = бібліотеки
  local d=$1; shift; for f in "$@"; do
    for hit in $R/usr/lib/x86_64-linux-gnu/$f $R/lib/x86_64-linux-gnu/$f; do
      [ -e "$hit" ] || continue
      mkdir -p "$d/usr/lib/x86_64-linux-gnu"; cp -L "$hit" "$d/usr/lib/x86_64-linux-gnu/$f"; break
    done; done
}
base() { # спільна мінімальна основа: як у chiseled/distroless немає shell і менеджера пакетів
  local d=$1; rm -rf "$d"; mkdir -p "$d"/{etc,tmp,app,lib64,usr/lib/x86_64-linux-gnu}; chmod 1777 "$d/tmp"
  ln -s usr/lib "$d/lib"
  cp -L $R/lib64/ld-linux-x86-64.so.2 "$d/lib64/"
  printf 'root:x:0:0:root:/root:/noshell\napp:x:1654:1654::/home/app:/noshell\n' > "$d/etc/passwd"
  printf 'root:x:0:\napp:x:1654:\n' > "$d/etc/group"
  copy_libs "$d" libc.so.6 libm.so.6 libssl.so.3 libcrypto.so.3 libz.so.1 libzstd.so.1
}
imp() { # $1 dir, $2 tag, решта --change
  local d=$1 t=$2; shift 2; tar -C "$d" -c . | docker import "$@" - "$t" >/dev/null; }
E=(-c 'ENV ASPNETCORE_URLS=http://0.0.0.0:8080' -c 'ENV DOTNET_NOLOGO=1' -c 'USER 1654' -c 'WORKDIR /app' -c 'EXPOSE 8080')

# JIT, slim: еквівалент aspnet:9.0-noble-chiseled
for v in controllers:Api.Controllers minimal:Api.Minimal; do
  n=${v%%:*}; a=${v##*:}; d=$W/$n; base "$d"
  # Збірка .NET з Ubuntu лінкує системний libunwind, тому беремо повне замикання залежностей
  copy_libs "$d" $(chroot "$R" bash -c 'for f in $(find /usr/lib/dotnet/shared -name "*.so") /usr/lib/dotnet/dotnet; do ldd $f 2>/dev/null; done' | awk '/=>/{print $1}' | sort -u)
  mkdir -p "$d/usr/lib/dotnet/shared"
  cp -a $R/usr/lib/dotnet/dotnet $R/usr/lib/dotnet/host "$d/usr/lib/dotnet/"
  cp -a $R/usr/lib/dotnet/shared/. "$d/usr/lib/dotnet/shared/"
  cp -a "$P/$n/." "$d/app/"; rm -f "$d"/app/*.pdb
  imp "$d" "bench/$n:slim" "${E[@]}" -c "ENTRYPOINT [\"/usr/lib/dotnet/dotnet\",\"/app/$a.dll\"]"
done

# Native AOT: еквівалент runtime-deps:9.0-noble-chiseled
d=$W/aot; base "$d"; cp "$P/aot/Api.MinimalAot" "$d/app/"
imp "$d" bench/aot:slim "${E[@]}" -c 'ENTRYPOINT ["/app/Api.MinimalAot"]'

# Повний Ubuntu 25.10 + aspnetcore-runtime-9.0: для порівняння зі звичайним (не slim) образом
if [ -d "${FULL:-/opt/fullroot}" ]; then
  tar -C "${FULL:-/opt/fullroot}" --exclude=./proc --exclude=./sys --exclude=./dev --exclude=./var/cache/apt \
      --exclude=./var/lib/apt/lists -c . | docker import "${E[@]}" - bench/ubuntu-aspnet:9.0 >/dev/null
fi

# Контроль: статичний C-сервер у scratch
d=$W/control; rm -rf "$d"; mkdir -p "$d"
gcc -O2 -static -s -o "$d/control" "$(dirname "$0")/control.c"
imp "$d" bench/control:scratch -c 'ENTRYPOINT ["/control"]'
docker images --format '{{.Repository}}:{{.Tag}} {{.Size}}' | grep bench/
