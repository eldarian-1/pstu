package org.eldarian.sirius12.task30;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        ArrayList<String> list = new ArrayList<>();
        Scanner scanner = new Scanner(System.in);
        for(int i = 0; i < 5; i++) {
            list.add(scanner.nextLine());
        }
        System.out.println("Size: " + list.size());
        for(int i = 0; i < 5; i++) {
            System.out.println(list.get(i));
        }
    }
}
