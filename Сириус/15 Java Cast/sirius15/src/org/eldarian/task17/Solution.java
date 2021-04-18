package org.eldarian.task17;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        ArrayList<Integer> list = new ArrayList<>();
        String[] sNums = reader.readLine().split(" ");
        for (int i = 0, n = sNums.length; i < n; i++) {
            list.add(Integer.parseInt(sNums[i]));
        }
        System.out.println(safeGetElement(list, 5, 1));
        System.out.println(safeGetElement(list, 20, 7));
        System.out.println(safeGetElement(list, -5, 9));
    }
    public static int safeGetElement(ArrayList<Integer> list, int index,
                                     int defaultValue) {
        try {
            return list.get(index);
        } catch (IndexOutOfBoundsException e) {
            return defaultValue;
        }
    }
}
