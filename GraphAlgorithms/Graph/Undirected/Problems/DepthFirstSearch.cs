using System.Text;
using Graph.Interfaces;

namespace Graph.Undirected.Problems;

public class DepthFirstSearch : IDepthFirstSearch
{
    private readonly int[] _edgeTo;
    private readonly bool[] _visited;
    private readonly int _v;

    public DepthFirstSearch(AdjacencyListGraph graph, int v)
    {
        _v = v;
        _visited = new bool[graph.Vertices()];
        _edgeTo = new int[graph.Vertices()];

        Dfs(graph, v);
    }

    private void Dfs(AdjacencyListGraph graph, int vertex)
    {
        _visited[vertex] = true;
        foreach (var edge in graph.AdjacentVertices(vertex))
        {
            if (_visited[edge]) continue;
            _edgeTo[edge] = vertex;
            Dfs(graph, edge);
        }
    }

    public bool HasPathTo(int s)
    {
        return _visited[s];
    }

    public string PathToStr(int s)
    {
        var path = PathTo(s);
        if (path.Count == 0) return "No paths were found!";

        var pathStr = new StringBuilder();
        while (path.Count > 0)
        {
            var point = path.Pop();
            pathStr.Append($"{point}{(path.Count == 0 ? "" : " -> ")}");
        }

        return pathStr.ToString();
    }

    public Stack<int> PathTo(int s)
    {
        if (!HasPathTo(s)) return [];

        var path = new Stack<int>();
        for (var x = s; x != _v; x = _edgeTo[x])
        {
            path.Push(x);
        }

        path.Push(_v);
        return path;
    }
}