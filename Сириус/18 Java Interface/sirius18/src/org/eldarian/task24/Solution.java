package org.eldarian.task24;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Solution {
    public static void main(String[] name) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        InputStream in = new FileInputStream(reader.readLine());
        String fileText = "";
        while(in.available() > 0) {
            fileText += String.format("%c", in.read());
        }
        in.close();
        reader.close();

        String[] nums = fileText.split(" ");
        List<Integer> list = new ArrayList<>();
        for (String num : nums) {
            list.add(Integer.parseInt(num));
        }

        Collections.sort(list);
        for(int i : list) {
            if(i % 2 == 0) {
                System.out.println(i);
            }
        }
    }
}

//mnt/disk_d/Lester/Политех/pstu/Сириус/18 Java Interface/sirius18/out/production/sirius18/org/eldarian/task16/test.txt
