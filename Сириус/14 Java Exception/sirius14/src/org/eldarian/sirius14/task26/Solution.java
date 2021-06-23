package org.eldarian.sirius14.task26;

import java.io.*;

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String sourceFileName = reader.readLine();
        String destinationFileName = reader.readLine();
        InputStream fileInputStream = getInputStream(sourceFileName);
        OutputStream fileOutputStream = getOutputStream(destinationFileName);
        int count = 0;
        while (fileInputStream.available() > 0) {
            int data = fileInputStream.read();
            fileOutputStream.write(data);
            count++;
        }
        System.out.println("Скопировано байт " + count);
        fileInputStream.close();
        fileOutputStream.close();
    }
    public static InputStream getInputStream(String fileName) throws IOException {
        return new FileInputStream(fileName);
    }
    public static OutputStream getOutputStream(String fileName) throws IOException {
        return new FileOutputStream(fileName);
    }
}

//mnt/disk_d/Lester/Политех/pstu/Сириус/14 Java Exception/sirius14/out/production/sirius14/org/eldarian/sirius14/task26/from.txt
//mnt/disk_d/Lester/Политех/pstu/Сириус/14 Java Exception/sirius14/out/production/sirius14/org/eldarian/sirius14/task26/to.txt