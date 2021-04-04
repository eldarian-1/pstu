package org.eldarian.sirius12.task27;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] nums = reader.readLine().split(" ");
        int[] array = new int[10];
        for(int i = 0; i < 10; i++) {
            array[i] = Integer.parseInt(nums[i]);
        }
        for(int i = 9; i >= 0; i--) {
            System.out.println(array[i]);
        }
    }
}
