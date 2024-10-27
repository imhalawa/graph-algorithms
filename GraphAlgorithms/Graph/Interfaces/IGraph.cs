namespace Graph.Interfaces;

public interface IGraph<T>
{
    /// <summary>
    /// Get a collection containing all adjacent vertices to a given vertex 'v'
    /// </summary>
    /// <param name="vertex"> A vertex that belongs to the graph</param>
    /// <returns></returns>
    IEnumerable<T> AdjacentVertices(T vertex);
    
    /// <summary>
    /// Connects two vertices. In an Undirected graph, vertices are connected both ways.
    /// </summary>
    /// <param name="v">Starting vertex</param>
    /// <param name="w">Destination vertex</param>
    void AddEdge(T v, T w);

    /// <summary>
    /// Disconnects two vertices. In an Undirected graph, vertices are disconnected both ways.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="w"></param>
    void RemoveEdge(T v, T w);
    
    /// <summary>
    /// The number of vertices in a graph
    /// </summary>
    /// <returns></returns>
    int Vertices();
    
    /// <summary>
    /// The total edges in a graph
    /// </summary>
    /// <returns></returns>
    int Edges();
    
    /// <summary>
    /// The total edges of a given vertex
    /// </summary>
    /// <param name="vertex"></param>
    /// <returns></returns>
    int Edges(T vertex);
}