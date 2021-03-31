package org.eldarian.sirius12.task49;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        ArrayList<String> strings = new ArrayList<>();
        while (true) {
            String string = reader.readLine();
            if (string == null || string.isEmpty()) break;
            strings.add(string);
        }
        ArrayList<String> resultStrings = new ArrayList<>();
        for (int i = 0, n = strings.size(); i < n; i++) {
            String string = strings.get(i);
            if(string.length() % 2 == 0) {
                resultStrings.add(string + " " + string);
            }
            else {
                resultStrings.add(string + " " + string + " " + string);
            }
        }
        for (int i = 0, n = resultStrings.size(); i < n; i++) {
            System.out.println(resultStrings.get(i));
        }
    }
}
