package org.eldarian.sirius12.task38;

import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) throws Exception {
        ArrayList<String> list = new ArrayList<>();
        list.add("мама");
        list.add("мыла");
        list.add("раму");
        for(int i = 0; i < list.size(); i += 2) {
            list.add(i + 1, "именно");
        }
        for(int i = 0, n = list.size(); i < n; i++) {
            System.out.println(list.get(i));
        }
    }
}
