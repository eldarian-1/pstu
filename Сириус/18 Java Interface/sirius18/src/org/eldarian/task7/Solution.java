package org.eldarian.task7;

public class Solution {
    public static void main(String[] args) throws Exception {
    }
    interface SimpleObject<T> {
        SimpleObject<T> getInstance();
    }
    static class StringObject implements SimpleObject<String>
    {
        private static StringObject instance = new StringObject();

        @Override
        public StringObject getInstance() {
            return instance;
        }
    }
}
