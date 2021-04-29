package src;

public class Task37 {
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

        public boolean fight(Cat cat) {
            int score = age < cat.age ? 1 : 0;
            score += weight > cat.weight ? 1 : 0;
            score += strength > cat.strength ? 1 : 0;
            return (score > 1);
        }

        public String getName() {
            return name;
        }
    }

    public static void fight(Cat red, Cat blue) {
        System.out.println(String.format("%s vs %s\n%s won!",
            red.getName(), blue.getName(),
            (red.fight(blue)) ? red.getName() : blue.getName()));
    }

    public static void main(String[] args) {
        Cat barsick = new Cat("Barsick", 3, 5, 15);
        Cat vasya = new Cat("Vasya", 1, 2, 7);
        Cat boris = new Cat("Boris", 9, 9, 4);
        fight(barsick, vasya);
        fight(barsick, boris);
        fight(boris, vasya);
    }
}