package src;

import java.io.*;

public class Task5 {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        double sum = 0, temp = 0;
        int count = 0;
        while(temp != -1) {
            temp = Double.parseDouble(reader.readLine());
            if(temp != -1) {
                ++count;
                sum += temp;
            }
        }
        System.out.println(sum / count);
    }
}