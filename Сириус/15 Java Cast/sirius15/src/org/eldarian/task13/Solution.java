package org.eldarian.task13;

import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) {
        ArrayList<String>[] arrayOfStringList = createList();
        printList(arrayOfStringList);
    }
    public static ArrayList<String>[] createList() {
        ArrayList<String>[] arrayOfStringList = new ArrayList[3];
        for(int i = 0; i < 3; ++i) {
            arrayOfStringList[i] = new ArrayList<>();
            for(int j = 0; j < 3; ++j) {
                arrayOfStringList[i].add(String.valueOf(i * 3 + j));
            }
        }
        return arrayOfStringList;
    }
    public static void printList(ArrayList<String>[] arrayOfStringList) {
        for (ArrayList<String> list : arrayOfStringList) {
            for (String s : list) {
                System.out.println(s);
            }
        }
    }
}
