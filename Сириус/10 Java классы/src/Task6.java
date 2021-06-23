package src;

public class Task6 {

    private static String compare(int number) {
        if(number > 5)
            return "Число больше 5";
        else if (number < 5)
            return "Число меньше 5";
        else
            return "Число равно 5";
    }

    private static void printCompare(int number) {
        System.out.println(compare(number));
    }

    public static void main(String[] args) {
        printCompare(3);
        printCompare(6);
        printCompare(5);
    }
}