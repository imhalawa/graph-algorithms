using Graph.Interfaces;

namespace Graph.DirectedGraph.Operations;

/// <summary>
/// Implements the Topological sort for Graph
/// </summary>
public static class TopologicalSort
{
    /// <summary>
    /// Implements an iterative approach to implement the Topological sort
    /// </summary>
    /// <param name="graph"></param>
    /// <returns></returns>
    public static Stack<int> IterativeSort(IDirectedGraph<int> graph)
    {
        var result = new Stack<int>();
        while (graph.Count > 0)
        {
            // Find the Sink
            var sink = graph.Vertices().First(v => graph.EdgesCount(v) == 0);

            // Amend it to the queue
            result.Push(sink);

            // Clear the Sink traces from all vertecies 
            graph.Vertices().ForEach(v => { graph.RemoveEdge(v, sink); });

            // Remove the Sink from the Graph
            graph.RemoveVertex(sink);
        }

        return result;
    }

    public static Queue<int> IndegreeSort(IDirectedGraph<int> graph)
    {
        // Result Stack
        var result = new Queue<int>();

        // Create the In-degree dictionary
        // Key-value pair of vertex as a key, and In-Degree as a value
        var indegree = graph.Vertices().ToDictionary(vertex => vertex, _ => 0);

        // Calculate the initial Indegree
        foreach (var edge in graph.Vertices().SelectMany(graph.Edges))
        {
            indegree[edge]++;
        }

        // Keep track of Zero In-degree vertices
        var zeroInDegree = new Stack<int>();
        foreach (var vertex in indegree.Keys)
        {
            if (indegree[vertex] == 0)
            {
                zeroInDegree.Push(vertex);
            }
        }

        // Iterate and Traverse the Graph based on the Zero-InDegree which represents Sources
        while (zeroInDegree.Count > 0)
        {
            // Fetch the top of the Indegree
            var source = zeroInDegree.Pop();

            // Amend it to result stack
            result.Enqueue(source);

            // Decrement the Indegree of Vertices that source was pointing to
            var sourceEdges = graph.Edges(source);
            foreach (var edge in sourceEdges)
            {
                indegree[edge]--;

                // As you decrement the Indegree, check if it's already a zero and keep track of it.
                if (indegree[edge] == 0)
                {
                    zeroInDegree.Push(edge);
                }
            }
        }

        return result;
    }
}