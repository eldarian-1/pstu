package org.eldarian.sirius14.task24;

import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) {
        ArrayList<int[]> list = createList();
        printList(list);
    }
    public static ArrayList<int[]> createList() {
        ArrayList<int[]> list = new ArrayList<>();
        fillList(list, 5, 2, 4, 7, 0);
        return list;
    }
    public static void fillList(ArrayList<int[]> list, int... lengths) {
        for(int length : lengths) {
            int[] arr = new int[length];
            for(int i = 0; i < length; i++) {
                arr[i] = (int)(Math.random() * 1024);
            }
            list.add(arr);
        }
    }
    public static void printList(ArrayList<int[]> list) {
        for (int[] array : list) {
            for (int x : array) {
                System.out.print(x + " ");
            }
            System.out.println();
        }
    }
}
