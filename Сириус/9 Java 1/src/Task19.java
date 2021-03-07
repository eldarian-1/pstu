package src;

public class Task19 {
    public static void main(String[] args) {
        System.out.println(convertCelsiusToFahrenheit(41));
    }

    public static double convertCelsiusToFahrenheit(int celsius) {
        return 9.0/5.0*celsius + 32;
    }
}
