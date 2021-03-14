package src;

import java.io.*;

public class Task29 {

    public static double time() throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("Введите время в минутах: ");
        return Double.parseDouble(reader.readLine());
    }

    public static double residue(double time) {
        return time - Math.floor(time) + Math.floor(time) % 5;
    }

    public static String color(double residue) {
        return residue < 3 ? "Зеленый" : residue < 4 ? "Желтый" : "Красный";
    }

    public static void main(String[] args) throws Throwable {
        System.out.println(color(residue(time())));
    }
}