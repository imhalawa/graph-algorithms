namespace ActionDAG;

public interface IGraph
{
    /// <summary>
    /// Get a collection of actions that an action v depends on
    /// </summary>
    /// <param name="vertex"> A vertex that belongs to the graph</param>
    /// <returns></returns>
    IEnumerable<DagBlock> Precedences(DagBlock vertex);

    /// <summary>
    /// Amend a new action to the Action Graph
    /// </summary>
    IGraph AddActions(params DagBlock[] functionBlock);
    
    /// <summary>
    /// Make an action v dependent on action w
    /// </summary>
    /// <param name="v">dependent action</param>
    /// <param name="w">Destination vertex</param>
    IGraph DependsOn(DagBlock v, DagBlock w);

    /// <summary>
    /// Disconnects two vertices. In an Undirected graph, vertices are disconnected both ways.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="w"></param>
    IGraph IndependentOf(DagBlock v, DagBlock w);

    /// <summary>
    /// Build the topological order of dag execution
    /// </summary>
    /// <returns></returns>
    IGraph Build();

    /// <summary>
    /// Execute the dag
    /// </summary>
    /// <returns></returns>
    IGraph Execute();
    
    /// <summary>
    /// The number of actions in a graph
    /// </summary>
    /// <returns></returns>
    int Actions();

    /// <summary>
    /// Get the actions that an action v depends on
    /// </summary>
    /// <param name="vertex"></param>
    /// <returns></returns>
    List<DagBlock> Dependents(DagBlock vertex);
}