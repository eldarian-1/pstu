package org.eldarian.sirius12.task40;

import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) throws Exception {
        Scanner scanner = new Scanner(System.in);
        ArrayList<String> list = new ArrayList<>();
        for(int i = 0; i < 10; i++) {
            list.add(scanner.nextLine());
        }
        ArrayList<String> doubleList = doubleValues(list);
        for(int i = 0, n = doubleList.size(); i < n; i++) {
            System.out.println(doubleList.get(i));
        }
    }

    public static ArrayList<String> doubleValues(ArrayList<String> list) {
        ArrayList<String> result = new ArrayList<>();
        for(int i = 0, n = list.size(); i < n; i++) {
            result.add(list.get(i));
            result.add(list.get(i));
        }
        return result;
    }
}
