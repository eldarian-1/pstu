package src;

public class Task29 {
    public static int sumDigitsInNumber(int number) {
        return (number / 100 + number / 10 % 10 + number % 10);
    }

    public static void main(String[] args) {
        System.out.println(sumDigitsInNumber(546));
    }
}