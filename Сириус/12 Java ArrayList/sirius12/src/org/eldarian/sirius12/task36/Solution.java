package org.eldarian.sirius12.task36;

import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) throws Exception {
        Scanner scanner = new Scanner(System.in);
        ArrayList<String> list = new ArrayList<>();
        int max = 0, min = 2000000000;
        for(int i = 0; i < 10; i++) {
            list.add(scanner.nextLine());
            max = Math.max(max, list.get(i).length());
            min = Math.min(min, list.get(i).length());
        }
        for(int i = 0, n = list.size(); i < n; i++) {
            if(max == list.get(i).length()) {
                System.out.println("Самая длинная строка встретилась раньше: " +
                        list.get(i));
                break;
            }
            if(min == list.get(i).length()) {
                System.out.println("Самая короткая строка встретилась раньше: " +
                        list.get(i));
                break;
            }
        }
    }
}
