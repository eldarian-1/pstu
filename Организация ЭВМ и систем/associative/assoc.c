#include "assoc.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef unsigned char byte;
typedef void (*task)(void**);

struct bin {
    char s[9];
};

const byte BYTE_COUNT = 64;

const char *DIALOG =
        "Меню:\n"
        "\t1. Создать устройство ассоциативной памяти.\n"
        "\t2. Вывести все записи.\n"
        "\t3. Прочитать из памяти.\n"
        "\t4. Записать в память.\n"
        "\t5. Удалить из памяти.\n"
        "\t6. Удалить устройство ассоциативной памяти.\n"
        "\t(*). Выход.\n"
        "Введите номер действия: ";

const char *INCORRECT = "Некорректный индекс!";

const task TASKS[] = {
        &create,
        &out,
        &read,
        &write,
        &rem,
        &drop
};

int read_index(byte *result);
byte read_value();
struct bin byte_to_bin(byte b);
byte bin_to_byte(struct bin b);

void run() {
    int number;
    void *mem = NULL;
    while(1) {
        printf("%s", DIALOG);
        scanf("%d", &number);
        if(1 <= number && number <= 6) {
            if(number > 1 && mem == NULL) {
                printf("Устройство ассоциативной памяти не было создано!\n\n");
                continue;
            } else {
                TASKS[number - 1](&mem);
                printf("\n");
            }
        } else {
            printf("Спасибо за работу! До свидания!\n");
            return;
        }
    }
}

void create(void **mem) {
    if(*mem) {
        free(*mem);
    }
    *mem = malloc(BYTE_COUNT);
    for(byte i = 0; i < BYTE_COUNT; ++i) {
        ((byte*)*mem)[i] = 0;
    }
    printf("Устройство ассоциативной памяти создано.\n");
}

void out(void **mem) {
    byte count = 0;
    printf("Содержимое памяти:\n");
    for(byte i = 0; i < BYTE_COUNT; ++i) {
        byte value = ((byte*)*mem)[i];
        if(value) {
            printf("\t%s -> %c\n", byte_to_bin(i).s, value);
            ++count;
        }
    }
    if(count == 0) {
        printf("\t<пусто>\n");
    }
    printf("Всего записей: %d\n", count);
}

void read(void **mem) {
    byte index;
    if (read_index(&index)) {
        byte value = ((byte *) *mem)[index];
        printf("%s -> %c\n", byte_to_bin(index).s, value);
    } else {
        printf("%s\n", INCORRECT);
    }
}

void write(void **mem) {
    byte index;
    if (read_index(&index)) {
        byte value = read_value();
        ((byte*)*mem)[index] = value;
        printf("%s -> %c\n", byte_to_bin(index).s, value);
    } else {
        printf("%s\n", INCORRECT);
    }
}

void rem(void **mem) {
    byte index;
    if (read_index(&index)) {
        if(((byte*)*mem)[index]) {
            ((byte*)*mem)[index] = 0;
            printf("Байт по индексу %s обнулён.\n", byte_to_bin(index).s);
        } else {
            printf("Байт по индексу %s уже был обнулён.\n", byte_to_bin(index).s);
        }
    } else {
        printf("%s\n", INCORRECT);
    }
}

void drop(void **mem) {
    free(*mem);
    *mem = NULL;
    printf("Устройство ассоциативной памяти удалено.\n");
}

int read_index(byte *result) {
    struct bin b;
    printf("Введите индекс: ");
    scanf("%s", b.s);
    *result = bin_to_byte(b);
    getchar();
    return *result < 64;
}

byte read_value() {
    byte value;
    printf("Введите значение: ");
    scanf("\n%c", &value);
    return value;
}

struct bin byte_to_bin(byte b) {
    struct bin r;
    r.s[8] = '\0';
    for(int i = 0; i < 8; ++i) {
        r.s[i] = (b & 128) ? '1' : '0';
        b <<= 1;
    }
    return r;
}

byte bin_to_byte(struct bin b) {
    byte r = 0;
    for(byte i = 0, n = strlen(b.s); i < n; ++i) {
        r <<= 1;
        r |= (b.s[i] != '0' ? 1 : 0);
    }
    return r;
}
