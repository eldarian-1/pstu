package org.eldarian.sirius12.task37;

import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) throws Exception {
        Scanner scanner = new Scanner(System.in);
        ArrayList<String> list = new ArrayList<>();
        for(int i = 0; i < 5; i++) {
            list.add(scanner.nextLine());
        }
        list.remove(2);
        for(int i = list.size() - 1; i >= 0; i--) {
            System.out.println(list.get(i));
        }
    }
}
