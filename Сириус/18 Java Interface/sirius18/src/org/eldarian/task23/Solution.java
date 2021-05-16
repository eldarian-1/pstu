package org.eldarian.task23;

import java.awt.*;

public class Solution {
    public static void main(String[] args) throws Exception {
        Fox bigFox = new BigFox();
        System.out.println(bigFox.getName());
        System.out.println(bigFox.getColor());
    }
    public interface Animal {
        Color getColor();
    }
    public abstract static class Fox implements Animal {
        public Color getColor() {
            return Color.ORANGE;
        }
        public String getName() {
            return "Fox";
        }
    }
    public static class BigFox extends Fox {
    }

}
