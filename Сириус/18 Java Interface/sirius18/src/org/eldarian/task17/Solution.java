package org.eldarian.task17;

import java.io.BufferedReader;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] name) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        OutputStream out = new FileOutputStream(reader.readLine());
        String temp;
        do {
            temp = reader.readLine() + "\n";
            out.write(temp.getBytes());
        } while(!temp.equals("exit\n"));
        reader.close();
        out.close();
    }
}
