package org.eldarian.sirius12.task7;

public class StringHelper {
    public static String multiply(String s) {
        return multiply(s, 5);
    }

    public static String multiply(String s, int count) {
        String result = "";
        for(int i = 0; i < count; i++) {
            result += s;
        }
        return result;
    }

    public static void main(String[] args) {
        System.out.println(multiply("Sirius", 2));
        System.out.println(multiply("Sirius"));
    }
}
