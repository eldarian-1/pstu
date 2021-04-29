package org.eldarian.sirius13.task9;

import java.util.ArrayList;
import java.util.Date;
import java.util.LinkedList;
import java.util.List;

public class Solution {
    public static void main(String[] args) {
        System.out.println(getInsertTimeInMs(new ArrayList<>()));
        System.out.println(getInsertTimeInMs(new LinkedList<>()));
    }
    public static long getInsertTimeInMs(List<Integer> list) {
        Date begin = new Date();
        insert10000(list);
        Date end = new Date();
        return end.getTime() - begin.getTime();
    }
    public static void insert10000(List<Integer> list) {
        for (int i = 0; i < 10000; i++) {
            list.add(0, i);
        }
    }
}
