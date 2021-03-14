package src;

import java.io.*;

public class Task26 {

    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("Введите число: ");
        int num = Integer.parseInt(reader.readLine());
        task(num);
    }

    public static void task(int a) {
        if(a < 0)
            System.out.println(a+1);
        else if(a > 0)
            System.out.println(a*2);
        else
            System.out.println(0);
    }
}