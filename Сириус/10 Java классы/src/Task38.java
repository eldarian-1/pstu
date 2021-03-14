package src;

import java.io.*;

public class Task38 {

    public static int number(char num) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print(String.format("Введите число %c: ", num));
        return Integer.parseInt(reader.readLine());
    }

    public static int min(int a, int b) {
        return (a < b ? a : b);
    }

    public static int max(int a, int b) {
        return (a < b ? b : a);
    }

    public static int min(int a, int b, int c) {
        return min(min(a, b), c);
    }

    public static int avg(int a, int b, int c) {
        return min(max(a, b), max(a, c), max(b, c));
    }

    public static int max(int a, int b, int c) {
        return max(max(a, b), c);
    }

    public static String answer(int a, int b, int c) {
        return String.format("%d %d %d", max(a, b, c), avg(a, b, c), min(a, b, c));
    }

    public static void main(String[] args) throws Throwable {
        System.out.println(answer(number('A'), number('B'), number('C')));
    }
}