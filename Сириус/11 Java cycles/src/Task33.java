package src;

public class Task33 {
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
        Cat barsick = new Cat("Barsick", 3, 5, 15);
        Cat vasya = new Cat("Vasya", 1, 2, 7);
        Cat boris = new Cat("Boris", 9, 9, 4);
        System.out.println(barsick.about());
        System.out.println(vasya.about());
        System.out.println(boris.about());
    }
}