package org.eldarian.sirius12.task26;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] stringArray = new String[10];
        int[] intArray = new int[10];
        for(int i = 0; i < 10; i++) {
            stringArray[i] = reader.readLine();
            intArray[i] = stringArray[i].length();
        }
        for(int i = 0; i < 10; i++) {
            System.out.println(intArray[i]);
        }
    }
}
