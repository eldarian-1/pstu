package src;

public class Task42 {
    public static class Rectangle {
        private int left;
        private int top;
        private int width;
        private int height;
        public void initialize(int left, int top, int width, int height) {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
        }
        public void initialize(int left, int top, int width) {
            initialize(left, top, width, width);
        }
        public void initialize(int left, int top) {
            initialize(left, top, 0, 0);
        }
        public void initialize(int left) {
            initialize(left, left);
        }
        public void initialize() {
            initialize(10);
        }
        public void initialize(Rectangle rect) {
            initialize(rect.left, rect.top, rect.width, rect.height);
        }
        public String about() {
            return left + " " + top + " " + width + " " + height;
        }
    }
    public static void main(String[] args) {
        Rectangle rectA = new Rectangle();
        Rectangle rectB = new Rectangle();
        rectA.initialize(13, 19, 30, 40);
        System.out.println(rectA.about());
        rectA.initialize(6, 7, 9);
        System.out.println(rectA.about());
        rectA.initialize(5, 10);
        System.out.println(rectA.about());
        rectA.initialize();
        System.out.println(rectA.about());
        rectB.initialize(rectA);
        System.out.println(rectB.about());
    }
}