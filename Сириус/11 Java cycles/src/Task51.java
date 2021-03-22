package src;

public class Task42 {
    public static class Color {
        private String description;

        public String getDescription() {
            return description;
        }

        public void setDescription(String description) {
            this.description = description;
        }
    }

    public static class Circle {
        public Color color;

        public Circle() {
            color = new Color();
            color.setDescription("White");
        }
    }

    public static void main(String[] args) {
        Circle circle = new Circle();
        circle.color.setDescription("Red");
        System.out.println(circle.color.getDescription());
    }
}