package org.eldarian.task2;

public class Solution {
    public static void main(String[] args) throws Exception {
        Screen screen = new Screen();
        screen.onSelect();
        screen.refresh();
    }
    interface Selectable {
        void onSelect();
    }
    interface Updatable {
        void refresh();
    }
    public static class Screen implements Selectable, Updatable{
        @Override
        public void onSelect() {
            System.out.println("событие выбора экрана");
        }

        @Override
        public void refresh() {
            System.out.println("Перерисовка");
        }
    }
}
