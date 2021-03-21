package src;

public class Task8 {
    private static class Dog {
        private String about = null;

        public Dog(String name) {
            about = name;
        }

        public Dog(String name, int height) {
            about = String.format("%s (height: %d)", name, height);
        }

        public Dog(String name, int height, String color) {
            about = String.format("%s (height: %d, color: %s)",
                name, height, color);
        }

        public String about() {
            return about;
        }
    }

    public static void main(String[] args) {
        Dog friend = new Dog("Corsair");
        System.out.println(friend.about());
        friend = new Dog("Pirat", 103);
        System.out.println(friend.about());
        friend = new Dog("Malish", 92, "black");
        System.out.println(friend.about());
    }
}