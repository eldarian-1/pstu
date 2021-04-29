package org.eldarian.task1;

public class Solution {
    public static void main(String[] args) {
        System.out.println(new Horse());
        System.out.println(new Pegasus());
    }
    public static class Horse {
        @Override
        public String toString() {
            return "Horse";
        }
    }
    public static class Pegasus extends Horse {
        @Override
        public String toString() {
            return "Flying " + super.toString();
        }
    }
}
