package org.eldarian.task26;

public class Solution {
    public static void main(String[] args) {
        Human human = new Human();
        System.out.println(human);
    }
    public interface Worker {
        void workLazy();
    }
    public interface Businessman {
        void workHard();
    }
    public interface Secretary {
        void workLazy();
    }
    public interface Miner {
        void workVeryHard();
    }
    public static class Human implements Worker, Businessman{
        @Override
        public void workHard() {}
        @Override
        public void workLazy() {}
    }
}
