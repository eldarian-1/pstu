package src;

import java.io.*;

public class Task48 {
    public static int max(int a, int b) {
        return (a > b ? a : b);
    }

    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int max = -(int)Math.pow(2, 31);
        int n = Integer.parseInt(reader.readLine());
        while(n-- > 0) {
            max = max(max, Integer.parseInt(reader.readLine()));
        }
        System.out.println("Maximum = " + max);
    }
}