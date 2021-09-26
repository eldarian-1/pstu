#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>

#include <stdlib.h>
#include <stdio.h>
#include <string.h>

#include "../common.h"

const size_t buf_size = 1024;
char buf[1024];
char *buff = buf;

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

    //while(1)
    {
        printf("Клиент: ");
        //scanf("%s", buf);
        getline(&buff, &buf_size, stdin);
        send(sock, buf, strlen(buf), 0);
        memset(buf, '\0', buf_size);
        recv(sock, buf, sizeof(buf), 0);
        printf("Сервер: %s\n", buf);
    }

    close(sock);

    return 0;
}