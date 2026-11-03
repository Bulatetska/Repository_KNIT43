/* Контрольний мінімальний HTTP-сервер: базова лінія витрат самого Docker на запуск контейнера. */
#include <arpa/inet.h>
#include <netinet/in.h>
#include <string.h>
#include <sys/socket.h>
#include <unistd.h>
int main(void) {
    static const char r[] = "HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: 35\r\nConnection: close\r\n\r\n{\"status\":\"ok\",\"message\":\"control\"}";
    int s = socket(AF_INET, SOCK_STREAM, 0), one = 1;
    setsockopt(s, SOL_SOCKET, SO_REUSEADDR, &one, sizeof one);
    struct sockaddr_in a = {.sin_family = AF_INET, .sin_port = htons(8080), .sin_addr.s_addr = INADDR_ANY};
    bind(s, (struct sockaddr *)&a, sizeof a); listen(s, 128);
    for (char b[2048];;) { int c = accept(s, 0, 0); if (c < 0) continue; read(c, b, sizeof b); write(c, r, sizeof r - 1); close(c); }
}
