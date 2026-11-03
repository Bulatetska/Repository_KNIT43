using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;

namespace Bench.Core;

/// <summary>
/// Обчислювальне навантаження: ланцюг SHA-256 і випуск JWT (HS256).
/// JWT формується вручну поверх System.Security.Cryptography: так немає сторонніх
/// залежностей і немає рефлексії, тож код однаковий для JIT і Native AOT.
/// </summary>
public static class CpuWork
{
    private static readonly byte[] Key = "bench-secret-key-bench-secret-key-32b"u8.ToArray();
    private static readonly byte[] Header = Encoding.UTF8.GetBytes(
        Base64Url.EncodeToString("""{"alg":"HS256","typ":"JWT"}"""u8));

    public static CpuResponse Run(string input, int rounds, DateTimeOffset now)
    {
        Span<byte> hash = stackalloc byte[SHA256.HashSizeInBytes];
        SHA256.HashData(Encoding.UTF8.GetBytes(input), hash);
        for (var i = 1; i < rounds; i++)
            SHA256.HashData(hash, hash);

        var hex = Convert.ToHexStringLower(hash);
        return new CpuResponse(hex, rounds, IssueJwt(hex, now));
    }

    private static string IssueJwt(string subject, DateTimeOffset now)
    {
        var payloadJson = $$"""{"sub":"{{subject}}","iat":{{now.ToUnixTimeSeconds()}},"exp":{{now.AddHours(1).ToUnixTimeSeconds()}}}""";
        var payload = Base64Url.EncodeToString(Encoding.UTF8.GetBytes(payloadJson));
        var signingInput = Encoding.UTF8.GetString(Header) + "." + payload;
        Span<byte> mac = stackalloc byte[HMACSHA256.HashSizeInBytes];
        HMACSHA256.HashData(Key, Encoding.UTF8.GetBytes(signingInput), mac);
        return signingInput + "." + Base64Url.EncodeToString(mac);
    }
}
