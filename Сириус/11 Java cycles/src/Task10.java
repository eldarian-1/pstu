package src;

import java.io.*;

public class Task10 {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int num = Integer.parseInt(reader.readLine());
        System.out.println(num == 0 ? "ноль" : String.format("%s %s число",
            num > 0 ? "положительное" : "отрицательное",
            num % 2 == 0 ? "четное" : "нечетное"));
    }
}