package src;

public class Task13 {

    public static void main(String[] args) {
        System.out.println(getWeight(888));
    }
    
    public static double getWeight(int earthWeight) {
        return 0.17 * earthWeight;
    }

}