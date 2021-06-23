package org.eldarian.task13;

public class Solution {
    public static void main(String[] args) {
    }
    public interface Movable {
        void move();
    }
    public interface Eatable {
        void beEaten();
    }
    public interface Eat {
        void eat();
    }
    public static class Dog implements Movable, Eat{
        public void move() {}
        public void eat() {}
    }
    public static class Cat implements Movable, Eatable, Eat {
        public void move() {}
        public void beEaten() {}
        public void eat() {}
    }
    public static class Mouse implements Movable, Eatable {
        public void move() {}
        public void beEaten() {}
    }

}
