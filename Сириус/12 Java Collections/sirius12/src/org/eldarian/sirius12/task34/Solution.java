package org.eldarian.sirius12.task34;

import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) throws Exception {
        Scanner scanner = new Scanner(System.in);
        ArrayList<String> list = new ArrayList<>();
        for(int i = 0; i < 10; i++) {
            list.add(0, scanner.nextLine());
        }
        for(int i = 0, n = list.size(); i < n; i++) {
            System.out.println(list.get(i));
        }
    }
}
