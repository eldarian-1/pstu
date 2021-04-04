package org.eldarian.sirius12.task14;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.Scanner;

public class ConsoleReader {
    public static String readString() throws Exception {
        return new BufferedReader(new InputStreamReader(System.in))
                .readLine();
    }
    public static int readInt() throws Exception {
        return Integer.parseInt(
                new BufferedReader(new InputStreamReader(System.in))
                        .readLine());
    }
    public static double readDouble() throws Exception {
        return Double.parseDouble(
                new BufferedReader(new InputStreamReader(System.in))
                        .readLine());
    }
    public static boolean readBoolean() throws Exception {
        String text = new BufferedReader(
                new InputStreamReader(System.in)).readLine();
        if(text.equals("true")) {
            return true;
        }
        else if(text.equals("false")) {
            return false;
        }
        else {
            throw new Exception("Некорректный ввод!");
        }
    }
    public static void main(String[] args) throws Exception {
        System.out.println(readString());
        System.out.println(readInt());
        System.out.println(readDouble());
        System.out.println(readBoolean());
    }
}
