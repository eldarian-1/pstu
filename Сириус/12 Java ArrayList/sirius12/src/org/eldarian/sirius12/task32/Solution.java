package org.eldarian.sirius12.task32;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] nums = reader.readLine().split(" ");
        int[] array = new int[20];
        for (int i = 0; i < 20; i++) {
            array[i] = Integer.parseInt(nums[i]);
        }
        sort(array);
        for (int x : array) {
            System.out.print(x + " ");
        }
    }
    public static void sort(int[] array) {
        for(int i = 0, n = array.length; i < n; i++) {
            for(int j = i + 1; j < n; j++) {
                if(array[i] < array[j]) {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }
}
