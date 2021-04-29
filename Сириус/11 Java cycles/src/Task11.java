package src;

import java.io.*;

public class Task11 {
    private static boolean rank(int num, int rank) {
        int devide = num / (int)Math.pow(10, rank - 1);
        return (devide > 0 && devide < 10);
    }

    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int num = Integer.parseInt(reader.readLine());
        if(num > 0 && num < 1000) {
            System.out.println(String.format("%s %s число",
                num % 2 == 0 ? "четное" : "нечетное",
                rank(num, 1) ? "однозначное" :
                    rank(num, 2) ? "двузначное" : "трехзначное"));
        }
    }
}