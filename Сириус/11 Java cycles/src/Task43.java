package src;

public class Task43 {
    public static class Cat {
        private String name;
        private int weight;
        private int age;
        private String address;
        private String color;

        private void defaultCat() {
            name = null;
            weight = 3;
            age = 4;
            address = null;
            color = "gray";
        }

        public Cat() {
            defaultCat();
        }

        public void initialize(String name) {
            defaultCat();
            this.name = name;
        }

        public void initialize(String name, int age) {
            initialize(name);
            this.age = age;
        }

        public void initialize(String name, int weight, int age) {
            initialize(name, age);
            this.weight = weight;
        }

        public void initialize(int weight, String color) {
            defaultCat();
            this.weight = weight;
            this.color = color;
        }

        public void initialize(int weight, String color, String address) {
            initialize(weight, color);
            this.address = address;
        }

        public String about() {
            return String.format("%s%s (weight: %d; age: %d; color: %s)",
                (name == null ? "cat" : name),
                (address == null ? "" : " from " + address),
                weight, age, color);
        }
    }

    public static void main(String[] args) {
        Cat cat = new Cat();
        System.out.println(cat.about());
        cat.initialize("Vasya");
        System.out.println(cat.about());
        cat.initialize("Boris", 7);
        System.out.println(cat.about());
        cat.initialize("Markiz", 5, 6);
        System.out.println(cat.about());
        cat.initialize(3, "black");
        System.out.println(cat.about());
        cat.initialize(2, "white", "Saint Petersburg");
        System.out.println(cat.about());
    }
}