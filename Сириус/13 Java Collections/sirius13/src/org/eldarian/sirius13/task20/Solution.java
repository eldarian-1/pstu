package org.eldarian.sirius13.task20;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

public class Solution {
    private static final Map<String, Integer> MONTHS = new HashMap<>();

    public static void fill() {
        MONTHS.put("January", 1);
        MONTHS.put("February", 2);
        MONTHS.put("March", 3);
        MONTHS.put("April", 4);
        MONTHS.put("May", 5);
        MONTHS.put("June", 6);
        MONTHS.put("Jule", 7);
        MONTHS.put("August", 8);
        MONTHS.put("September", 9);
        MONTHS.put("October", 10);
        MONTHS.put("November", 11);
        MONTHS.put("December", 12);
    }

    public static void main(String[] args) throws Throwable {
        fill();
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String month = reader.readLine();
        System.out.println(month + " is the " + MONTHS.get(month));
    }
}
