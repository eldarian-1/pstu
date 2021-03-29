package org.eldarian.sirius12.task43;

import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        ArrayList<Integer> list = new ArrayList<>();
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int m = scanner.nextInt();
        for(int i = 0; i < n; i++) {
            list.add(scanner.nextInt());
        }
        for(int i = 0; i < m; i++) {
            list.add(list.remove(0));
        }
        for(int i = 0; i < n; i++) {
            System.out.println(list.get(i));
        }
    }
}
