package src;

import java.io.*;

public class Task37 {

    public static int number(char num) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print(String.format("Введите число %c: ", num));
        return Integer.parseInt(reader.readLine());
    }

    public static boolean equal(int a, int b) {
        return a == b;
    }

    public static int answer(int a, int b, int c) {
        return equal(a, b) && !equal(b, c) ? 3
            : equal(a, c) && !equal(b, c) ? 2
            : equal(b, c) && !equal(a, c) ? 1
            : -1;
    }

    public static void main(String[] args) throws Throwable {
        System.out.println(answer(number('A'), number('B'), number('C')));
    }
}