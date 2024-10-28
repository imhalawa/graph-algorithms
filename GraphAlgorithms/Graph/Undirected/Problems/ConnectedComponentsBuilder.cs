using Graph.Interfaces;

namespace Graph.Undirected.Problems;

public class ConnectedComponentsBuilder(AdjacencyListGraph graph)
{
    private int _connectedComponentsCount = 0;
    private readonly int[] _connectedComponents = new int[graph.Vertices()];
    private readonly bool[] _visited = new bool[graph.Vertices()];

    public List<int>[] GetConnectedComponents()
    {
        Discover();

        var connectedComponents = new List<int>[_connectedComponentsCount];
        for (var cc = 0; cc < _connectedComponentsCount; cc++)
        {
            connectedComponents[cc] = [];
        }

        for (var cc = 0; cc < _connectedComponents.Length; cc++)
        {
            connectedComponents[_connectedComponents[cc]-1].Add(cc);
        }

        return connectedComponents;
    }

    private void Discover()
    {
        var vertices = graph.Vertices();
        for (var vertex = 0; vertex < vertices; vertex++)
        {
            if (_visited[vertex]) continue;
            _connectedComponentsCount++;
            Dfs(graph, vertex);
        }
    }

    private void Dfs(AdjacencyListGraph g, int vertex)
    {
        _visited[vertex] = true;
        _connectedComponents[vertex] = _connectedComponentsCount;
        var edges = g.AdjacentVertices(vertex);
        foreach (var edge in edges)
        {
            if (!_visited[edge])
            {
                Dfs(g, edge);
            }
        }
    }
}