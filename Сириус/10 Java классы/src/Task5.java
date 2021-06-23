package src;

public class Task5 {

    private static String checkSeason(int number) {
        if(number > 0 && number <= 12)
            if(number <= 2 || number == 12)
                return "winter";
            else if (number <= 5)
                return "spring";
            else if (number <= 8)
                return "summer";
            else
                return "autemn";
        else
            return "incorrect!";
    }

    private static void printSeason(int number) {
        System.out.println(checkSeason(number));
    }

    public static void main(String[] args) {
        printSeason(1);
        printSeason(4);
        printSeason(8);
        printSeason(100);
        printSeason(11);
    }
}