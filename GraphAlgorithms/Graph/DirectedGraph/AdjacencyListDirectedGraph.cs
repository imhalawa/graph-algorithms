using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Text;
using Graph.Interfaces;

namespace Graph.DirectedGraph;

public class AdjacencyListDirectedGraph : IDirectedGraph<int>
{
    private readonly Dictionary<int, List<int>> _adjacencyList = new();

    public ImmutableList<int> Edges(int vertex)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(vertex, Count, nameof(vertex));
        return _adjacencyList[vertex].ToImmutableList();
    }

    public FrozenDictionary<int, ImmutableList<int>> AdjacencyList()
    {
        return _adjacencyList.Select(
            p => KeyValuePair.Create(p.Key, p.Value.ToImmutableList())
        ).ToList().ToFrozenDictionary();
    }

    public void AddEdge(int v, int w)
    {
        if (!_adjacencyList.ContainsKey(v))
        {
            _adjacencyList.Add(v, []);
        }

        if (!_adjacencyList.ContainsKey(w))
        {
            _adjacencyList.Add(w, []);
        }

        _adjacencyList[v].Add(w);
    }

    public void RemoveEdge(int v, int w)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(false, _adjacencyList.ContainsKey(v));
        ArgumentOutOfRangeException.ThrowIfEqual(false, _adjacencyList.ContainsKey(w));
        _adjacencyList[v].Remove(w);
    }

    public void RemoveVertex(int vertex)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(false, _adjacencyList.ContainsKey(vertex));
        _adjacencyList.Remove(vertex);
    }

    public int Count => _adjacencyList.Keys.Count;

    public ImmutableList<int> Vertices() => _adjacencyList.Keys.ToImmutableList();

    public int Edges()
    {
        return _adjacencyList.Aggregate(0, (count, next) => count + next.Value.Count);
    }

    public int EdgesCount(int vertex)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(false, _adjacencyList.ContainsKey(vertex));
        return _adjacencyList[vertex].Count;
    }

    public override string ToString()
    {
        var graph = new StringBuilder();
        for (var vertex = 0; vertex < Count; vertex++)
        {
            graph.AppendLine($"{vertex} -> {string.Join(",", _adjacencyList[vertex].Select(s => s.ToString()))}");
        }

        return graph.ToString();
    }
}