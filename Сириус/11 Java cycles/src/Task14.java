package src;

import java.io.*;

public class Task14 {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String str = reader.readLine();
        int n = Integer.parseInt(reader.readLine());
        while (n-- > 0) {
            System.out.println(str);
        }
    }
}