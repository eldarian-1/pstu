package src;

public class Task22 {
    public static double convertEurToUsd(int eur, double course) {
        return eur * course;
    }

    public static void convertOutput(int eur, double course) {
        System.out.println(
            String.format("%d евро = %f долларов (по курсу %f)",
                eur, convertEurToUsd(eur, course), course));
    }

    public static void main(String[] args) {
        convertOutput(1638, 1.19);
        convertOutput(3156, 1.17);
    }
}