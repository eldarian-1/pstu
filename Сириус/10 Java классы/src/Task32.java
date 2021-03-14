package src;

import java.io.*;

public class Task32 {

    public static String name() throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("Введите имя: ");
        return reader.readLine();
    }

    public static int age() throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("Введите возраст: ");
        return Integer.parseInt(reader.readLine());
    }

    public static void main(String[] args) throws Throwable {
        String name = name();
        int age = age();
        if(age > 20)
            System.out.println("И 18 достаточно");
        else
            System.out.println("Ок");
    }
}