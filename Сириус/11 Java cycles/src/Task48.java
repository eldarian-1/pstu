package src;

public class Task48 {
    public static class Circle {
        public double x;
        public double y;
        public double radius;

        public Circle(double x, double y, double radius) {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }
    }

    public static void main(String[] args) {
        Circle circle = new Circle(13, 29, 9);
        System.out.println(circle.x + " " + circle.y + " " + circle.radius);
    }
}