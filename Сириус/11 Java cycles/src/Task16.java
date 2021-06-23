package src;

public class Task16 {
    public static void main(String[] args) {
        int n = 0;
        while (n++ < 10) {
            int m = 0;
            while (m++ < 10) {
                System.out.print(String.format("%d ", n * m));
            }
            System.out.println();
        }
    }
}