package src;

public class Task17 {

    public static void main(String[] args) {
        System.out.println(min(-20, -10));
        System.out.println(min(-40, -10, -30, 40));
        System.out.println(min(-20, -40, -30, 40));
        System.out.println(min(-20, -10, -40, 40));
        System.out.println(min(-20, -10, -30, -40));
    }
    
    public static int min(int left, int right) {
        return (left > right ? right : left);
    }
    
    public static int min(int left, int center1, int center2, int right) {
        return min(min(left, right), min(center1, center2));
    }

}