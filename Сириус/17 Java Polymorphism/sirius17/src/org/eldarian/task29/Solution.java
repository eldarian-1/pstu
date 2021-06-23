package org.eldarian.task29;

public class Solution {
    public static void main(String[] args) {
        Horse horse = new Pegasus();
        horse.run();
    }
    public interface CanFly {
        void fly();
    }
    public static abstract class Horse {
        public void run() {}
    }
    public static class Pegasus extends Horse implements CanFly {
        public void fly() {}
    }
    public static class SwimmingPegasus extends Pegasus {
        public void swim() {}
    }
}
