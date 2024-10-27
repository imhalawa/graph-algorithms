using System.Text;

namespace Graph.Undirected.Problems;

public class DepthFirstSearch
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
        foreach (var point in path)
        {
            pathStr.Append($"{point} <- ");
        }

        return pathStr.ToString();
    }

    public List<int> PathTo(int s)
    {
        if (!HasPathTo(s)) return [];

        List<int> path = [s];
        var navigator = _edgeTo[s];
        while (navigator != _edgeTo[navigator])
        {
            path.Add(navigator);
            navigator = _edgeTo[navigator];
        }

        path.Add(navigator);
        return path;
    }
}