package src;

import java.io.*;

public class Task35 {
    
    private static BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

    public static int number(char num) throws Throwable {
        System.out.print(String.format("Введите число %c: ", num));
        return Integer.parseInt(reader.readLine());
    }

    public static int max(int a, int b) {
        return (a < b ? b : a);
    }

    public static void main(String[] args) throws Throwable {
        System.out.println(max(max(number('A'), number('B')), max(number('C'), number('D'))));
    }
}