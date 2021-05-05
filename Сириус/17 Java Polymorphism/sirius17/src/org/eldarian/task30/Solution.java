package org.eldarian.task30;

public class Solution {
    public static void main(String[] args) {
        Pegasus horse = new Pegasus();
    }
    public interface CanFly {
        void fly();
    }
    public static class Horse {
        public void run() {}
    }
    public static class Pegasus extends Horse implements CanFly{
        @Override
        public void fly() {}
    }
}
