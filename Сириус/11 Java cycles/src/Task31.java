package src;

import java.io.*;

public class Task31 {
    public static int min(int a, int b) {
        return (a < b ? a : b);
    }

    public static int max(int a, int b) {
        return (a > b ? a : b);
    }

    public static int avg(int a, int b, int c) {
        return max(max(min(a, b), min(b, c)), min(a, c));
    }

    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int a = Integer.parseInt(reader.readLine());
        int b = Integer.parseInt(reader.readLine());
        int c = Integer.parseInt(reader.readLine());
        System.out.println(avg(a, b, c));
    }
}