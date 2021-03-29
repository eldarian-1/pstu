package org.eldarian.sirius12.task14;

import java.util.Scanner;

public class ConsoleReader {
    public static String readString() throws Exception {
        Scanner scanner = new Scanner(System.in);
        return scanner.nextLine();
    }
    public static int readInt() throws Exception {
        Scanner scanner = new Scanner(System.in);
        return scanner.nextInt();
    }
    public static double readDouble() throws Exception {
        Scanner scanner = new Scanner(System.in);
        return scanner.nextDouble();
    }
    public static boolean readBoolean() throws Exception {
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine();
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
