package org.eldarian.task14;

public class Solution {
    public static void main(String[] args) {
        Swimmable animal = new Orca();
        animal.swim();
        animal = new Whale();
        animal.swim();
        animal = new Otter();
        animal.swim();
    }
    public static void test(Swimmable animal) {
        animal.swim();
    }
    interface Walkable {
        void walk();
    }
    interface Swimmable {
        void swim();
    }
    static abstract class OceanAnimal implements Swimmable {
        public void swim() {
            OceanAnimal currentAnimal = (OceanAnimal) getCurrentAnimal();
            currentAnimal.displaySwim();
        }
        private void displaySwim() {
            System.out.println(getCurrentAnimal().getClass().getSimpleName()
                    + " is swimming");
        }
        abstract Swimmable getCurrentAnimal();
    }
    static class Orca extends OceanAnimal {
        @Override
        Swimmable getCurrentAnimal() {
            return this;
        }
    }
    static class Whale extends OceanAnimal {
        @Override
        Swimmable getCurrentAnimal() {
            return this;
        }
    }
    static class Otter extends OceanAnimal implements Walkable {
        @Override
        public void walk() {

        }
        @Override
        Swimmable getCurrentAnimal() {
            return this;
        }
    }
}
