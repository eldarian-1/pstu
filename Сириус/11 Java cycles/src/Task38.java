package src;

public class Task38 {
    public static class Dog {
        private String name;
        private int height;
        private String color;

        public void initialize(String name) {
            this.name = name;
            this.height = 0;
            this.color = null;
        }

        public void initialize(String name, int height) {
            this.name = name;
            this.height = height;
            this.color = null;
        }

        public void initialize(String name, int height, String color) {
            this.name = name;
            this.height = height;
            this.color = color;
        }

        public String about() {
            return (height == 0 ? name : color == null ?
                String.format("%s (height: %d)", name, height) :
                String.format("%s (%s, height: %d)", name, color, height));
        }
    }

    public static void main(String[] args) {
        Dog dog = new Dog();
        dog.initialize("Rex", 110);
        System.out.println(dog.about());
        dog.initialize("Dina");
        System.out.println(dog.about());
        dog.initialize("Muhtar", 120, "brown");
        System.out.println(dog.about());
    }
}