package src;

import java.io.*;

public class Task33 {
    
    private static BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

    public static int number(char num) throws Throwable {
        System.out.print(String.format("Введите число %c: ", num));
        return Integer.parseInt(reader.readLine());
    }

    public static int fourth(int x, int y) {
        if(x >= 0 && y >= 0)
            return 1;
        else if(x < 0 && y >= 0)
            return 2;
        else if(x < 0 && y < 0)
            return 3;
        else
            return 4;
    }

    public static void main(String[] args) throws Throwable {
        System.out.println(fourth(number('x'), number('y')));
    }
}