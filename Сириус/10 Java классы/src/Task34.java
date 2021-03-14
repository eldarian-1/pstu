package src;

import java.io.*;

public class Task34 {

    public static int number(char num) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print(String.format("Введите число %c: ", num));
        return Integer.parseInt(reader.readLine());
    }

    public static int min(int a, int b) {
        return (a < b ? a : b);
    }

    public static void main(String[] args) throws Throwable {
        System.out.println(min(number('A'), number('B')));
    }
}