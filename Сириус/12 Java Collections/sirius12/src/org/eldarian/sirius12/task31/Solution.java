package org.eldarian.sirius12.task31;

import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        ArrayList<String> list = new ArrayList<>();
        ArrayList<String> maxList = new ArrayList<>();
        int max = 0;
        Scanner scanner = new Scanner(System.in);
        for(int i = 0; i < 5; i++) {
            list.add(scanner.nextLine());
            max = Math.max(max, list.get(i).length());
        }
        for(int i = 0; i < 5; i++) {
            if(list.get(i).length() == max) {
                maxList.add(list.get(i));
            }
        }
        for(int i = 0, n = maxList.size(); i < n; i++) {
                System.out.println(maxList.get(i));
        }
    }
}
