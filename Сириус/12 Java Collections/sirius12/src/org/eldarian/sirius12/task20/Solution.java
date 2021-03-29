package org.eldarian.sirius12.task20;

public class Solution {
    public static void main(String[] args) {
        printIdea(new Idea("Процессор из дерева"));
    }

    public static class Idea {
        private String description;
        public Idea(String description) {
            this.description = description;
        }
        public String getDescription() {
            return description;
        }
    }

    public static void printIdea(Idea idea) {
        System.out.println(idea.getDescription());
    }
}
