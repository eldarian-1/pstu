package org.eldarian.sirius13.task26;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] words = reader.readLine().split(" ");
        String result = "";
        for(String item : words) {
            result += item.substring(0, 1).toUpperCase()
                    + item.substring(1) + " ";
        }
        System.out.println(result);
    }
}
