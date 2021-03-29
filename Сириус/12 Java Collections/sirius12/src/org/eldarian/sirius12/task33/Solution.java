package org.eldarian.sirius12.task33;

import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) throws Exception {
        Scanner scanner = new Scanner(System.in);
        ArrayList<String> list = new ArrayList<>();
        ArrayList<String> minList = new ArrayList<>();
        int min = 2000000000;
        for(int i = 0; i < 5; i++) {
            list.add(scanner.nextLine());
            min = Math.min(min, list.get(i).length());
        }
        for(int i = 0; i < 5; i++) {
            if(list.get(i).length() == min) {
                minList.add(list.get(i));
            }
        }
        for(int i = 0, n = minList.size(); i < n; i++) {
            System.out.println(minList.get(i));
        }
    }
}
