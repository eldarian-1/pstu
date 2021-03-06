package org.eldarian.euler;

public class VertexAdjacency {

    private int _dimension;
    private boolean[][] _matrix;

    public VertexAdjacency(boolean[][] matrix) {
        _dimension = matrix.length;
        _matrix = matrix;
    }

    public int GetDimension() {
        return _dimension;
    }

    public void SetValue(int i, int j, boolean value) {
        _matrix[i][j] = value;
    }

    public AdjacencyList AdjacencyList(int vertex) {
        AdjacencyList list = new AdjacencyList(this, vertex);
        for (int i = 0; i < _dimension; ++i)
            if(_matrix[vertex][i])
                list.add(i);
        return list;
    }

    public void RemoveEdge(int row, int column) {
        SetValue(row, column, false);
        SetValue(column, row, false);
    }
}
