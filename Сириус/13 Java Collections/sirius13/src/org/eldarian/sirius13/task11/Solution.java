package org.eldarian.sirius13.task11;

import java.util.ArrayList;
import java.util.Date;
import java.util.LinkedList;
import java.util.List;

public class Solution {
    public static void main(String[] args) {
        System.out.println(getGetTimeInMs(fill(new ArrayList<>())));
        System.out.println(getGetTimeInMs(fill(new LinkedList<>())));
    }
    public static List<Integer> fill(List<Integer> list) {
        for (int i = 0; i < 10000; i++) {
            list.add(i);
        }
        return list;
    }
    public static long getGetTimeInMs(List<Integer> list) {
        Date begin = new Date();
        get10000(list);
        Date end = new Date();
        return end.getTime() - begin.getTime();
    }
    public static void get10000(List<Integer> list) {
        if (list.isEmpty()) {
            return;
        }
        int x = list.size() / 2;
        for (int i = 0; i < 10000; i++) {
            list.get(x);
        }
    }
}
