package src;

import java.io.*;

public class Task29 {
    
    private static BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

    public static double time() throws Throwable {
        System.out.print("Введите время в минутах: ");
        return Double.parseDouble(reader.readLine());
    }

    public static double residue(double time) {
        return time % 5;
    }

    public static String color(double residue) {
        return residue < 3 ? "Зеленый" : residue < 4 ? "Желтый" : "Красный";
    }

    public static void main(String[] args) throws Throwable {
        System.out.println(color(residue(time())));
    }
}