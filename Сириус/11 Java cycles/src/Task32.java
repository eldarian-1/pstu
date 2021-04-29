package src;

public class Task32 {
    public static class Cat {
        private String name;
        private int age;
        private int weight;
        private int strength;

        public Cat(String name, int age, int weight, int strength) {
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.strength = strength;
        }

        public String about() {
            return String.format("%s (age: %d; weight: %d; strength: %d)",
                name, age, weight, strength);
        }
    }

    public static void main(String[] args) {
        Cat cat = new Cat("Barsick", 3, 5, 15);
        System.out.println(cat.about());
    }
}