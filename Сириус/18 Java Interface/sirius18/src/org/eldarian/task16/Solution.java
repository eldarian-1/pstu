package org.eldarian.task16;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.InputStream;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] name) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        InputStream in = new FileInputStream(reader.readLine());
        while(in.available() > 0) {
            System.out.printf("%c", in.read());
        }
        in.close();
        reader.close();
    }
}

//mnt/disk_d/Lester/Политех/pstu/Сириус/18 Java Interface/sirius18/out/production/sirius18/org/eldarian/task16/test.txt
