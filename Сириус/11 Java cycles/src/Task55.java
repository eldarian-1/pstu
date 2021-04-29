package src;

import java.io.*;

public class Task55 {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int sum = 0;
        while(true) {
            String s = reader.readLine();
            if (s.equals("сумма"))
                break;
            else
                sum += Integer.parseInt(s);
        }
        System.out.println("Summ = " + sum);
    }
}