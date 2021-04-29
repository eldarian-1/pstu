package org.eldarian.euler;

import java.util.ArrayList;

public class AdjacencyList extends ArrayList<Integer> {

    private VertexAdjacency _matrix;
    private int _vertex;

    public AdjacencyList(VertexAdjacency matrix, int vertex) {
        _matrix = matrix;
        _vertex = vertex;
    }

    public void Remove(int vertex) {
        _matrix.RemoveEdge(_vertex, vertex);
    }

}
