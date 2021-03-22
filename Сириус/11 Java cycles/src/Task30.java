package src;

import java.io.*;

public class Task30 {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int sum = 0, temp = 0;
        while(true) {
            temp = Integer.parseInt(reader.readLine());
            if(temp != -1)
                sum += temp;
            else
                break;
        }
        System.out.println(sum);
    }
}