package src;

import java.io.*;

public class Task47 {
    public static int min(int a, int b) {
        return (a < b ? a : b);
    }

    public static int min(int a, int b, int c, int d, int e) {
        return min(min(min(a, b), c), min(d, e));
    }

    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int a = Integer.parseInt(reader.readLine());
        int b = Integer.parseInt(reader.readLine());
        int c = Integer.parseInt(reader.readLine());
        int d = Integer.parseInt(reader.readLine());
        int e = Integer.parseInt(reader.readLine());
        int minimum = min(a, b, c, d, e);
        System.out.println("Minimum = " + minimum);
    }
}