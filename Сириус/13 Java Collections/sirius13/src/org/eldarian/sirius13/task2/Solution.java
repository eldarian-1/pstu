package org.eldarian.sirius13.task2;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.HashSet;
import java.util.Set;

public class Solution {
    public static Set<Integer> createSet() {
        return new HashSet<>();
    }

    public static Set<Integer> removeAllNumbersGreaterThan10
            (Set<Integer> set) {
        Set<Integer> result = new HashSet<>(set);
        for(Integer item : set) {
            if(item > 10) {
                result.remove(item);
            }
        }
        return result;
    }

    public static void main(String[] args) throws Exception {
        Set<Integer> set = createSet();
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] nums = reader.readLine().split(" ");
        for(String item : nums) {
            set.add(Integer.parseInt(item));
        }
        set = removeAllNumbersGreaterThan10(set);
        for(Integer item : set) {
            System.out.print(item + " ");
        }
        System.out.println();
    }
}
