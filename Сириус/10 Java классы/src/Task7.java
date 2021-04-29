package src;

import java.io.*;
import java.util.Scanner;

public class Task7 {

    private static String weakDay(int number) {
        if(number == 1)
            return "Понедельник";
        else if(number == 2)
            return "Вторник";
        else if(number == 3)
            return "Среда";
        else if(number == 4)
            return "Четверг";
        else if(number == 5)
            return "Пятница";
        else if(number == 6)
            return "Суббота";
        else if(number == 7)
            return "Воскресение";
        else
            return "Значение некорректно!";
    }

    private static void printDay(int number) {
        System.out.println(weakDay(number));
    }

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        int num = 0;
        do {
            System.out.println("Введите номер дня недели: ");
            num = in.nextInt();
            printDay(num);
        } while(num != 0);
    }
}