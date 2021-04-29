package org.eldarian.sirius14.task22;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

public class Solution {
    public static void main(String[] args) {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
        try {
            Date date = format.parse(reader.readLine());
            format = new SimpleDateFormat("MMM dd, yyyy", Locale.ENGLISH);
            System.out.println(format.format(date).toUpperCase());
        } catch (ParseException | IOException e) {
            e.printStackTrace();
        }
    }
}
