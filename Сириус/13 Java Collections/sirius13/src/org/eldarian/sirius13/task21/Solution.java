package org.eldarian.sirius13.task21;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        List<String> list = new ArrayList<>();
        String[] array = reader.readLine().split(" ");
        for(int i = 0; i < 20; i++) {
            list.add(array[i]);
        }
        list.sort(String::compareTo);
        list.forEach(System.out::println);
    }
}
