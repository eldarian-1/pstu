package src;

public class Task15 {

    public static void main(String[] args) {
        System.out.println(min(12, 33));
        System.out.println(min(-20, 0));
        System.out.println(min(-10, -20));
    }
    
    public static int min(int left, int right) {
        return (left > right ? right : left);
    }

}