using Graph.Interfaces;
using Graph.Undirected.Abstract;

namespace Graph.Undirected;

public class EdgeListGraph : IUndirectedGraph<int>
{
    private readonly List<Edge<int>> _edgeList = [];
    private readonly List<int> _vertices = [];

    public IEnumerable<int> AdjacentVertices(int vertex)
    {
        List<int> result = [];
        result.AddRange(from edge in _edgeList where edge.Source.Equals(vertex) select edge.Destination);
        return result;
    }

    public void AddEdge(int v, int w)
    {
        var undirectedEdge = GetAssociatedEdges(v, w);
        if (undirectedEdge.Count != 0) return;

        _edgeList.Add(new Edge<int>(v, w));
        _edgeList.Add(new Edge<int>(w, v));

        if (!_vertices.Contains(v))
        {
            _vertices.Add(v);
        }

        if (!_vertices.Contains(w))
        {
            _vertices.Add(w);
        }
    }

    public void RemoveEdge(int v, int w)
    {
        var undirectedEdge = GetAssociatedEdges(v, w);

        if (undirectedEdge.Count == 0) return;

        // Indicates the last connection to the vertex *v*
        if (_edgeList.Count(e => e.Source.Equals(v)).Equals(1))
        {
            _vertices.Remove(v);
        }

        // Indicates the last connection to the vertex *w*
        if (_edgeList.Count(e => e.Source.Equals(w)).Equals(1))
        {
            _vertices.Remove(w);
        }

        foreach (var edge in undirectedEdge)
        {
            _edgeList.Remove(edge);
        }
    }

    public int Vertices()
    {
        return _vertices.Count;
    }

    public int Edges()
    {
        return _edgeList.Count / 2;
    }

    public int Edges(int vertex)
    {
        return _edgeList.Count(e => e.Source.Equals(vertex));
    }

    private List<Edge<int>> GetAssociatedEdges(int v, int w)=>  _edgeList.Where(e =>
            (e.Source.Equals(v) && e.Destination.Equals(w)) || (e.Source.Equals(w) && e.Destination.Equals(v)))
        .ToList();
    
    private record Edge<T>(T Source, T Destination);
}