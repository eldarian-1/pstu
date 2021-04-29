package org.eldarian.sirius13.task8;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

public class Solution {
    public static void main(String[] args) {
        // ArrayList
        List<Integer> arrayList = new ArrayList<>();
        insert10000(arrayList);
        get10000(arrayList);
        set10000(arrayList);
        remove10000(arrayList);
        // LinkedList
        List<Integer> linkedList = new LinkedList<>();
        insert10000(linkedList);
        get10000(linkedList);
        set10000(linkedList);
        remove10000(linkedList);
    }
    public static void insert10000(List<Integer> list) {
        for(int i = 0; i < 10000; i++) {
            list.add(i);
        }
    }
    public static void get10000(List<Integer> list) {
        for(int i = 0; i < 10000; i++) {
            System.out.print(list.get(i) + " ");
        }
        System.out.println();
    }
    public static void set10000(List<Integer> list) {
        for(int i = 0; i < 10000; i++) {
            list.set(i, i + 1);
        }
    }
    public static void remove10000(List<Integer> list) {
        for(int i = 9999; i >= 0; i--) {
            list.remove(i);
        }
    }
}
