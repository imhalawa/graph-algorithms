using System.Collections.Frozen;
using System.Collections.Immutable;

namespace Graph.Interfaces;

public interface IDirectedGraph<TKey>
{
    /// <summary>
    /// Get a collection containing all adjacent vertices to a given vertex 'v'
    /// </summary>
    /// <param name="vertex"> A vertex that belongs to the graph</param>
    /// <returns></returns>
    ImmutableList<TKey> Edges(TKey vertex);

    /// <summary>
    /// Get an immutable version for the adjacency list
    /// </summary>
    /// <returns></returns>
    FrozenDictionary<TKey, ImmutableList<TKey>> AdjacencyList();

    /// <summary>
    /// Connects two vertices. In an Undirected graph, vertices are connected both ways.
    /// </summary>
    /// <param name="v">Starting vertex</param>
    /// <param name="w">Destination vertex</param>
    void AddEdge(TKey v, TKey w);

    /// <summary>
    /// Disconnects two vertices. In an Undirected graph, vertices are disconnected both ways.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="w"></param>
    void RemoveEdge(TKey v, TKey w);

    /// <summary>
    /// Remove a vertex along with it's connections from the graph
    /// </summary>
    /// <param name="vertex"></param>
    void RemoveVertex(TKey vertex);

    /// <summary>
    /// The number of vertices in a graph
    /// </summary>
    /// <returns></returns>
    int Count { get; }

    /// <summary>
    /// Distinct list of vertices in the graph
    /// </summary>
    /// <returns></returns>
    ImmutableList<TKey> Vertices();

    /// <summary>
    /// The total edges of a given vertex
    /// </summary>
    /// <param name="vertex"></param>
    /// <returns></returns>
    int EdgesCount(TKey vertex);
}