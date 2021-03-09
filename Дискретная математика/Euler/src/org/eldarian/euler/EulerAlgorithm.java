package org.eldarian.euler;

import java.util.Stack;

public class EulerAlgorithm {

    private VertexAdjacency _matrix;

    public EulerAlgorithm(boolean[][] matrix) {
        _matrix = new VertexAdjacency(matrix);
    }

    public Stack<Integer> Calculate(int vertex) {
        Stack<Integer> result = new Stack<>();
        Stack<Integer> stack = new Stack<>();
        stack.push(vertex);
        while(!stack.empty()) {
            AdjacencyList list = _matrix.AdjacencyList(stack.peek());
            if(list.isEmpty())
                result.push(stack.pop());
            else
                list.Remove(stack.push(list.get(0)));
        }
        return result;
    }

    public String Answer(){
        String answer = "This graph is not Euler.";
        Stack<Integer> way = Calculate(0);
        if(way.size() == _matrix.GetDimension() + 1) {
            answer = "";
            for (int i : way)
                answer += String.format("%c ", 'A' + i);
        }
        return answer;
    }

}
