package src;

public class Task24 {

    public static final int N = 10;

    public static void main(String[] args) {
        displayClosestToTen(8, 11);
        displayClosestToTen(7, 14);
    }

    public static void displayClosestToTen(int a, int b) {
        System.out.println(nearest(a, b));
    }

    public static int nearest(int a, int b) {
        return diff(a) < diff(b) ? a : b;
    }

    public static int diff(int a) {
        return abs(N - a);
    }

    public static int abs(int n) {
        return n < 0 ? -n : n;
    }
}