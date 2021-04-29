package src;

import java.io.*;

public class Task36 {
    
    private static BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

    public static String name() throws Throwable {
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