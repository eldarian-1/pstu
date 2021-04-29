package org.eldarian.sirius12.task25;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {

    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] array = new String[10];
        for(int i = 0; i < 8; i++) {
            array[i] = reader.readLine();
        }
        for(int i = 9; i >= 0; i--) {
            System.out.println(array[i] == null ? "" : array[i]);
        }
    }
}
