package org.eldarian.task18;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        int[] array = new int[30];
        String[] sNums = reader.readLine().split(" ");
        for (int i = 0, n = sNums.length; i < n; i++) {
            array[i] = Integer.parseInt(sNums[i]);
        }
        sort(array);
        System.out.println(array[9]);
        System.out.println(array[10]);
    }
    public static void sort(int[] array) {
        for(int i = 0, n = array.length; i < n; ++i) {
            for(int j = i + 1; j < n; ++j) {
                if(array[i] > array[j]) {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }
}
