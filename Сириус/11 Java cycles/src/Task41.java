package src;

public class Task41 {
    public static class Person {
        private String name;
        private char sex;
        private int money;
        private int weight;
        private double size;

        public void initialize(String name, char sex, int money, int weight,
            double size) {
            this.name = name;
            this.sex = sex;
            this.money = money;
            this.weight = weight;
            this.size = size;
        }

        public String about() {
            return String.format("%s (%c, money: %d; weight: %d; size: %f)",
                name, sex, money, weight, size);
        }
    }

    public static void main(String[] args) {
        Person person = new Person();
        person.initialize("Mall Gibson", 'm', 13500, 187, 92);
        System.out.println(person.about());
    }
}