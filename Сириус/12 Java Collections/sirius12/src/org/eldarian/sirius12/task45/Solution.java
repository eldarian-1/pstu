package org.eldarian.sirius12.task45;

import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        ArrayList<String> list = new ArrayList<>();
        Scanner scanner = new Scanner(System.in);
        while(true) {
            String temp = scanner.nextLine();
            if(temp.equals("end")) {
                break;
            }
            list.add(temp);
        }
        for(String item : list) {
            System.out.println(item);
        }
    }
}
