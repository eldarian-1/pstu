package org.eldarian.task4;

import java.awt.*;

public class Solution {
    public static void main(String[] args) throws Exception {
        System.out.println(new Fox().getName());
    }
    public interface Animal {
        String getName();
        Color getColor();
    }
    public static class Fox implements Animal {
        public String getName() {
            return "Fox";
        }
        public Color getColor() {
            return Color.ORANGE;
        }
    }
}
