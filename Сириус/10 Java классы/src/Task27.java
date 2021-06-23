package src;

import java.io.*;

public class Task27 {

    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("Введите год: ");
        int num = Integer.parseInt(reader.readLine());
        task(num);
    }

    public static void task(int y) {
        System.out.println(String.format("Дней в %d году: %d", y,
            isLeap(y) ? 366 : 365));
    }

    public static boolean isLeap(int y) {
        return (y % 400 == 0 ? true : y % 100 == 0 ? false : y % 4 == 0);
    }
}