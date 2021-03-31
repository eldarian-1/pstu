package org.eldarian.sirius12.task41;

import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) {
        ArrayList<String> strings = new ArrayList<String>();
        strings.add("мама");
        strings.add("виноград");
        strings.add("лодка");
        strings = fix(strings);
        for (String string : strings) {
            System.out.println(string);
        }
    }
    public static ArrayList<String> fix(ArrayList<String> strings) {
        ArrayList<String> result = new ArrayList<>(strings);
        for(int i = 0; i < result.size(); i++) {
            boolean r = result.get(i).indexOf("р") != -1;
            boolean l = result.get(i).indexOf("л") != -1;
            if(r && l) {
                continue;
            }
            if(r) {
                result.remove(i--);
            }
            if(l) {
                result.add(i, result.get(i++));
            }
        }
        return result;
    }
}
