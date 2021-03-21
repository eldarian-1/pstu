package src;

public class Task7 {
    private static class Dog {
        private String about = null;

        public void initialize(String name) {
            about = name;
        }

        public void initialize(String name, int height) {
            about = String.format("%s (height: %d)", name, height);
        }

        public void initialize(String name, int height, String color) {
            about = String.format("%s (height: %d, color: %s)",
                name, height, color);
        }

        public String about() {
            return about;
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