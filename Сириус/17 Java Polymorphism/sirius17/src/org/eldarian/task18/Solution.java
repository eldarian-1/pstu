package org.eldarian.task18;

public class Solution {
    public static void main(String[] args) {}
    public interface CanRun {
        void run();
    }
    public interface CanSwim {
        void swim();
    }
    public static abstract class Human implements CanRun, CanSwim {
        public abstract void run();
        public abstract void swim();
    }
}
