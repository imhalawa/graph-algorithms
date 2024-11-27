using System.Threading.Tasks.Dataflow;

namespace ActionDAG;

public class Dag : IGraph
{
    private readonly Dictionary<DagBlock, List<DagBlock>> _dagBlockAdjacencyList = [];
    private readonly Queue<DagBlock> _topologicalExecutionQueue = new Queue<DagBlock>();
    private bool _isBuilt = false;

    public IEnumerable<DagBlock> Precedences(DagBlock vertex)
    {
        throw new NotImplementedException();
    }

    public IGraph AddActions(params DagBlock[] dagBlocks)
    {
        foreach (var dagBlock in dagBlocks)
        {
            ArgumentNullException.ThrowIfNull(dagBlocks);
            _dagBlockAdjacencyList.Add(dagBlock, []);
        }

        return this;
    }

    public IGraph DependsOn(DagBlock v, DagBlock w)
    {
        ArgumentNullException.ThrowIfNull(v);
        
        ArgumentNullException.ThrowIfNull(w);
        if (_dagBlockAdjacencyList.TryGetValue(v, out var value) && !value.Contains(w))
        {
            value.Add(w);
        }

        return this;
    }

    public IGraph IndependentOf(DagBlock v, DagBlock w)
    {
        ArgumentNullException.ThrowIfNull(v);
        ArgumentNullException.ThrowIfNull(w);
        if (_dagBlockAdjacencyList.TryGetValue(v, out var value) && value.Contains(w))
        {
            value.Remove(w);
        }

        return this;
    }

    public IGraph Build()
    {
        // Execute Toplogical Sort
        // 


        _isBuilt = true;
        return this;
    }

    public IGraph Execute( /* will accept parameters here later as part of the generic DAG implementation*/)
    {
        if (!_isBuilt) throw new DagExecutionException();
        while (_topologicalExecutionQueue.Count > 0)
        {
            var nextDagBlock = _topologicalExecutionQueue.Dequeue();
            nextDagBlock.Action.Invoke();
        }

        return this;
    }

    public int Actions()
    {
        return _dagBlockAdjacencyList.Count;
    }

    public List<DagBlock> Dependents(DagBlock vertex)
    {
        return _dagBlockAdjacencyList.TryGetValue(vertex, out var result) ? result : [];
    }
}

public record DagBlock(string Name, string Description, Action Action);

// public class FunctionBlock<TArg, TResult>(string name, string description, Func<TArg, TResult> func)
//     : DagBlock(name, description)
// {
//     public required Func<TArg, TResult> Function { get; set; } = func;
// }

public class DagExecutionException(string message = "Please use `Build` before executing the DAG") : Exception(message);