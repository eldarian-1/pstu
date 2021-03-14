package src;

import java.io.*;

public class Task28 {

    public static double edge(char edge) throws Throwable {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print(String.format("Введите сторону %c: ", edge));
        return Double.parseDouble(reader.readLine());
    }

    public static boolean isEdge(double a, double b1, double b2) {
        return a < b1 + b2;
    }

    public static boolean isTriangle(double a, double b, double c) {
        return isEdge(a, b, c) && isEdge(b, c, a) && isEdge(c, a, b);
    }

    public static void main(String[] args) throws Throwable {
        System.out.println(isTriangle(edge('A'), edge('B'), edge('C'))
            ? "Нормальный треугольник" : "Некорректные данные!");
    }
}