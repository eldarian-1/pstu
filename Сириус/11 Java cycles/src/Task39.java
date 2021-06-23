package src;

public class Task39 {
    public static class Circle {
        private int centerX;
        private int centerY;
        private int radius;
        private int width;
        private String color;

        public void initialize(int centerX, int centerY, int radius) {
            this.centerX = centerX;
            this.centerY = centerY;
            this.radius = radius;
            this.width = 0;
            this.color = null;
        }

        public void initialize(int centerX, int centerY, int radius, int width) {
            initialize(centerX, centerY, radius);
            this.width = width;
        }

        public void initialize(int centerX, int centerY, int radius, int width,
            String color) {
            initialize(centerX, centerY, radius, width);
            this.color = color;
        }

        public String about() {
            return String.format("X: %d; Y: %d; Radius: %d%s",
                centerX, centerY, radius,
                (width == 0 ? "" : String.format("; Width: %d%s", width,
                    (color == null ? "" : "; Color: " + color))));
        }
    }

    public static void main(String[] args) {
        Circle circle = new Circle();
        circle.initialize(11, 44, 15, 2);
        System.out.println(circle.about());
        circle.initialize(7, 5, 2);
        System.out.println(circle.about());
        circle.initialize(70, 32, 25, 3, "Blue");
        System.out.println(circle.about());
    }
}