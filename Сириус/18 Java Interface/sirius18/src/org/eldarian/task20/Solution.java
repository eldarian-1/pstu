package org.eldarian.task20;

public class Solution {
    public static void main(String[] args) throws Exception {
        SimpleObject<String> stringObject = new StringObject();
    }
    interface SimpleObject<T> {
        SimpleObject<T> getInstance();
    }
    public static class StringObject implements SimpleObject<String> {

        private static StringObject instance = new StringObject();

        @Override
        public StringObject  getInstance() {
            return instance;
        }
    }
}
