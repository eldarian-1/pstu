package src;

public class Task25 {

    public static final int MIN = 50;
    public static final int MAX = 100;

    public static void main(String[] args) {
        checkInterval(60);
        checkInterval(112);
        checkInterval(10);
    }

    public static void checkInterval(int a) {
        System.out.println(String.format("Число %d%s содержится в интервале", a,
            MIN < a && a < MAX ? " не" : ""));
    }
}