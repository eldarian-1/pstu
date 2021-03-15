package src;

import java.io.*;

public class Task30 {
    
    private static BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

    public static int number(char num) throws Throwable {
        System.out.print(String.format("Введите число %c: ", num));
        return Integer.parseInt(reader.readLine());
    }

    public static boolean equal(int a, int b) {
        return a == b;
    }

    public static String answer(int a, int b, int c) {
        return equal(a, b) && equal(b, c) ? String.format("%d %d %d", a, b, c)
            : equal(a, b) ? String.format("%d %d", a, b)
            : equal(a, c) ? String.format("%d %d", a, c)
            : equal(b, c) ? String.format("%d %d", b, c)
            : "Numbers aren't equals";
    }

    public static void main(String[] args) throws Throwable {
        System.out.println(answer(number('A'), number('B'), number('C')));
    }
}