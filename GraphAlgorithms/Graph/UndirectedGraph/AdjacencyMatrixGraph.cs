using System.Text;
using Graph.Interfaces;
using Graph.Undirected.Abstract;

namespace Graph.Undirected;

public class AdjacencyMatrixGraph(int vertices) : IUndirectedGraph<int>
{
    private readonly int[,] _adjacencyMatrix = new int[vertices, vertices];

    public IEnumerable<int> AdjacentVertices(int vertex)
    {
        for (var i = 0; i < vertices; i++)
        {
            if (_adjacencyMatrix[vertex, i] == 1)
            {
                yield return i;
            }
        }
    }

    public void AddEdge(int v, int w)
    {
        if (v >= vertices || w >= vertices) return;
        _adjacencyMatrix[v, w] = 1;
        _adjacencyMatrix[w, v] = 1;
    }

    public void RemoveEdge(int v, int w)
    {
        _adjacencyMatrix[v, w] = 0;
        _adjacencyMatrix[w, v] = 0;
    }

    public int Vertices()
    {
        return vertices;
    }

    public int Edges()
    {
        var edges = 0;
        for (var i = 0; i < vertices; i++)
        {
            for (var j = 0; j < vertices; j++)
            {
                if (_adjacencyMatrix[i, j] == 1 || _adjacencyMatrix[j, i] == 1)
                    ++edges;
            }
        }

        return edges / 2;
    }

    public int Edges(int vertex)
    {
        var edges = 0;
        for (var i = 0; i < vertices; i++)
        {
            if (_adjacencyMatrix[vertex, i] == 1)
                ++edges;
        }

        return edges;
    }

    public override string ToString()
    {
        var graphStr = new StringBuilder();

        for (var i = 0; i < vertices; i++)
        {
            var vertexStr = new StringBuilder();
            var appended = false;
            vertexStr.Append($"({i})->[ ");
            for (var j = 0; j < vertices; j++)
            {
                if (_adjacencyMatrix[i, j] != 1) continue;
                vertexStr.Append($"{j} -> ");
                appended = true;
            }

            if (appended)
            {
                vertexStr.Remove(vertexStr.Length - 4, 4);
            }

            vertexStr.Append(" ]");
            graphStr.Append(vertexStr);
            graphStr.AppendLine();
        }

        return graphStr.ToString();
    }
}