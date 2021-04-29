package src;

public class Task7 {
    private static class Dog {
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
            return (height == 0 ? name : color == null
                ? String.format("%s (height: %d)", name, height)
                : String.format("%s (height: %d, color: %s)", name, height, color));
        }
    }

    public static void main(String[] args) {
        Dog friend = new Dog();
        friend.initialize("Corsair");
        System.out.println(friend.about());
        friend.initialize("Pirat", 103);
        System.out.println(friend.about());
        friend.initialize("Malish", 92, "black");
        System.out.println(friend.about());
    }
}