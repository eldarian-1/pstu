package org.eldarian.sirius13.task22;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Solution {
    public static void main(String[] args) throws Exception {
        List<Integer> integerList = getIntegerList();
        System.out.println(getMinimum(integerList));
    }
    public static int getMinimum(List<Integer> array) {
        int min = array.get(0);
        for(int item : array) {
            min = Math.min(min, item);
        }
        return min;
    }
    public static List<Integer> getIntegerList() throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        List<Integer> list = new ArrayList<>();
        int n = Integer.parseInt(reader.readLine());
        String[] nums = reader.readLine().split(" ");
        for(int i = 0; i < n; i++) {
            list.add(Integer.parseInt(nums[i]));
        }
        return list;
    }
}
