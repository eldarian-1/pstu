package org.eldarian.sirius14.task11;

import java.util.HashMap;

public class Solution {
    public static void main(String[] args) {
        try {
            HashMap map = new HashMap(null);
            map.put(null, null);
            map.remove(null);
        } catch(NullPointerException e) {
            System.out.println(e.getClass().getName());
        }
    }
}
