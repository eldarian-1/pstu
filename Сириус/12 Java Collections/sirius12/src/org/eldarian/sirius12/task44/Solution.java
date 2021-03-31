package org.eldarian.sirius12.task44;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] nums = reader.readLine().split(" ");
        int[] array = new int[20];
        int min = 2000000000, max = -2000000000;
        for(int i = 0; i < 20; i++) {
            array[i] = Integer.parseInt(nums[i]);
            min = Math.min(min, array[i]);
            max = Math.max(max, array[i]);
        }
        System.out.println("Min: " + min + "; Max: " + max);
    }
}
