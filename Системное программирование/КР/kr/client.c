#include "client.h"
#include "consts.h"

#include <stdio.h>
#include <unistd.h>
#include <string.h>
#include <sys/socket.h>
#include <netinet/in.h>

void client_run() {
    size_t buf_size = 1024;
    char buf[1024];
    char *buff = buf;

    int sock;
    struct sockaddr_in addr;

    do {
        sock = socket(AF_INET, SOCK_STREAM, 0);
        if (sock < 0) {
            usleep(100);
        }
    } while (sock < 0);

    addr.sin_family = AF_INET;
    addr.sin_port = htons(PORT);
    addr.sin_addr.s_addr = htonl(INADDR_LOOPBACK);
    int isConnect;
    do {
        isConnect = connect(sock, (struct sockaddr *) &addr, sizeof(addr));
        if (isConnect < 0) {
            usleep(100);
        }
    } while (isConnect < 0);

    printf("Клиент: ");
    scanf("%s", buff);
    getchar();
    send(sock, buf, strlen(buf), 0);
    memset(buf, '\0', buf_size);
    recv(sock, buf, sizeof(buf), 0);
    printf("Сервер: %s\n", buf);

    close(sock);
}
