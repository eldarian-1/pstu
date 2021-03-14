package src;

import java.io.*;

public class Task36 {

    public static String name() throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("Введите имя: ");
        return reader.readLine();
    }

    public static String equal(String a, String b) {
        return (a.equals(b) ? "Имена идентичны"
            : a.length() == b.length() ? "Длины имен равны"
            : "Имена разные");
    }

    public static void main(String[] args) throws Throwable {
        System.out.println(equal(name(), name()));
    }
}