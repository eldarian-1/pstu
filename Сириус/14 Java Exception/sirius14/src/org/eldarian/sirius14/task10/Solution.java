package org.eldarian.sirius14.task10;

import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) {
        try {
            ArrayList<String> list = new ArrayList<>();
            String s = list.get(18);
        } catch(IndexOutOfBoundsException e) {
            System.out.println(e.getClass().getName());
        }
    }
}
