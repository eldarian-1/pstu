package src;

public class Task14 {
    private static final double PI = 3.14;

    public static void main(String[] args) {
        printCircleLength(5);  
    }

    private static void printCircleLength(int radius) {
        System.out.println(2 * PI * radius);
    }
}
