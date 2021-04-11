package org.eldarian.sirius14.task27;

import java.io.*;

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        InputStream fileInputStream;
        OutputStream fileOutputStream;
        while(true) {
            try {
                fileInputStream = getInputStream(reader.readLine());
                break;
            } catch (FileNotFoundException ignored) {
                System.out.println("Файл не существует.");
            }
        }
        fileOutputStream = getOutputStream(reader.readLine());
        while (fileInputStream.available() > 0) {
            int data = fileInputStream.read();
            fileOutputStream.write(data);
        }
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
