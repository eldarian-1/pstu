package org.eldarian.sirius12.task8;

import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        ArrayList<Integer> list = new ArrayList<>();
        for(int i = 0; i < 5; i++) {
            list.add(reader.nextInt());
        }
        list.sort((a, b)-> (a > b ? 1 : a < b ? -1 : 0));
        for(int i = 0; i < 5; i++) {
            System.out.print(list.get(i) + " ");
        }
    }
}
