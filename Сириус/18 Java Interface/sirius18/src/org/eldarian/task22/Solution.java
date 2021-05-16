package org.eldarian.task22;

import java.awt.*;

public class Solution {
    public static void main(String[] args) throws Exception {
    }
    public interface Animal {
        default Color getColor() {
            return Color.ORANGE;
        }
        default Integer getAge() {
            return 20;
        }
    }
    public static class Fox implements Animal {
        public String getName() {
            return "Fox";
        }
    }
}
