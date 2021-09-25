#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>

#include "../common.h"

char buf[1024];

int main()
{
    int sock;
    struct sockaddr_in addr;

    sock = socket(AF_INET, SOCK_STREAM, 0);
    if(sock < 0)
    {
        perror("socket");
        exit(1);
    }

    addr.sin_family = AF_INET;
    addr.sin_port = htons(port);
    addr.sin_addr.s_addr = htonl(INADDR_LOOPBACK);
    if(connect(sock, (struct sockaddr *)&addr, sizeof(addr)) < 0)
    {
        perror("connect");
        exit(2);
    }

    for(;;) {
        printf("Клиент: ");
        scanf("%s", buf);
        send(sock, buf, strlen(buf), 0);
        recv(sock, buf, sizeof(buf), 0);
        printf("Сервер: %s\n", buf);
    }

    close(sock);

    return 0;
}