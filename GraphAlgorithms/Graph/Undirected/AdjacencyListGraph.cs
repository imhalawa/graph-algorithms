using System.Text;
using Graph.Interfaces;

namespace Graph.Undirected;

public class AdjacencyListGraph : IGraph<int>
{
    private readonly List<int>[] _adjacencyList;
    private readonly int _vertices;

    public AdjacencyListGraph(int vertices)
    {
        this._vertices = vertices;
        _adjacencyList = new List<int>[vertices];
        for (var i = 0; i < vertices; i++)
        {
            _adjacencyList[i] = [];
        }
    }

    public IEnumerable<int> AdjacentVertices(int vertex)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(vertex, _vertices);
        return _adjacencyList[vertex];
    }

    public void AddEdge(int v, int w)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(v, _vertices);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(w, _vertices);

        _adjacencyList[v].Add(w);
        _adjacencyList[w].Add(v);
    }

    public void RemoveEdge(int v, int w)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(v, _vertices);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(w, _vertices);

        _adjacencyList[v].Remove(w);
        _adjacencyList[w].Remove(v);
    }

    public int Vertices()
    {
        return _vertices;
    }

    public int Edges()
    {
        return _adjacencyList.Sum(vertex => vertex.Count) / 2;
    }

    public int Edges(int vertex)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(vertex, _vertices);
        return _adjacencyList[vertex].Count;
    }

    public override string ToString()
    {
        var graphStr = new StringBuilder();
        for (int i = 0; i < this._vertices; i++)
        {
            var vertexStr = new StringBuilder($"({i}) -> [ ");
            var appended = false;
            foreach (var edge in _adjacencyList[i])
            {
                vertexStr.Append($"{edge} -> ");
                appended = true;
            }

            if (appended)
                vertexStr.Remove(vertexStr.Length - 4, 4);

            vertexStr.Append(" ] ");
            graphStr.Append(vertexStr).AppendLine();
        }

        return graphStr.ToString();
    }
}