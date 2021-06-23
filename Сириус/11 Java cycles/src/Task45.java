package src;

public class Task45 {
    public static class Cat {
        private String name;
        private int weight;
        private int age;
        private String address;
        private String color;

        public Cat() {
            name = null;
            weight = 3;
            age = 4;
            address = null;
            color = "gray";
        }

        public Cat(String name) {
            this();
            this.name = name;
        }

        public Cat(String name, int age) {
            this(name);
            this.age = age;
        }

        public Cat(String name, int weight, int age) {
            this(name, age);
            this.weight = weight;
        }

        public Cat(int weight, String color) {
            this();
            this.weight = weight;
            this.color = color;
        }

        public Cat(int weight, String color, String address) {
            this(weight, color);
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
        cat = new Cat("Vasya");
        System.out.println(cat.about());
        cat = new Cat("Boris", 7);
        System.out.println(cat.about());
        cat = new Cat("Markiz", 5, 6);
        System.out.println(cat.about());
        cat = new Cat(3, "black");
        System.out.println(cat.about());
        cat = new Cat(2, "white", "Saint Petersburg");
        System.out.println(cat.about());
    }
}