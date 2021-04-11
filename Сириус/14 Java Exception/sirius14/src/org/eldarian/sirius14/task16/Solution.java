package org.eldarian.sirius14.task16;

import java.io.IOException;
import java.rmi.RemoteException;

public class Solution {
    public interface Func {
        void run() throws Throwable;
    }
    public static void main(String[] args) {
        handleExceptions(new Solution());
    }
    public static void handleExceptions(Solution obj) {
        obj.helpMethod(obj::method1, obj::method2, obj::method3);
    }
    public void helpMethod(Func... methods) {
        for(Func method : methods) {
            try {
                method.run();
            } catch (Throwable e) {
                System.out.println(e.getClass().getName());
            }
        }
    }
    public void method1() throws IOException {
        throw new IOException();
    }
    public void method2() throws NoSuchFieldException {
        throw new NoSuchFieldException();
    }
    public void method3() throws RemoteException {
        throw new RemoteException();
    }
}
