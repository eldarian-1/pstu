package org.eldarian.sirius14.task21;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Solution {
    public static void main(String[] args) {
        readData();
    }
    public static void readData() {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        List<Integer> list = new ArrayList<>();
        try {
            while(true) {
                list.add(Integer.parseInt(reader.readLine()));
            }
        } catch (IOException | NumberFormatException e) {
            for(int item : list) {
                System.out.print(item + " ");
            }
            System.out.println();
        }
    }
}
