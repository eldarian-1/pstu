package org.eldarian.task12;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        Movie movie;
        while((movie = MovieFactory.getMovie(reader.readLine())) != null) {
            System.out.println(movie.getClass().getSimpleName());
        }
    }
    static class MovieFactory {
        static Movie getMovie(String key) {
            Movie movie = null;
            if ("soapOpera".equals(key)) {
                movie = new SoapOpera();
            } else if ("cartoon".equals(key)) {
                movie = new Cartoon();
            } else if ("thriller".equals(key)) {
                movie = new Thriller();
            }
            return movie;
        }
    }
    static abstract class Movie {}
    static class SoapOpera extends Movie {}
    static class Cartoon extends Movie {}
    static class Thriller extends Movie {}
}
