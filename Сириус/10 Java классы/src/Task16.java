package src;

public class Task16 {

    public static void main(String[] args) {
        System.out.println(min(1, 2, 3));
        System.out.println(min(-1, -2, -3));
        System.out.println(min(3, 5, 3));
        System.out.println(min(5, 5, 10));
    }
    
    public static int min(int left, int right) {
        return (left > right ? right : left);
    }
    
    public static int min(int left, int center, int right) {
        return min(min(left, right), center);
    }

}