namespace Graph.Undirected.Problems;

public class DfsClock
{
    private bool[] _visited;
    private int[,] _clockIntervals;
    private int _clockTick;

    public DfsClock(AdjacencyListGraph graph)
    {
        _visited = new bool[graph.Vertices()];
        _clockIntervals = new int[graph.Vertices(), 2];
        _clockTick = 0;

        Discover(graph);
    }

    private void Discover(AdjacencyListGraph graph)
    {
        for (var vertex = 0; vertex < graph.Vertices(); vertex++)
        {
            if (_visited[vertex]) continue;
            Dfs(graph, vertex);
        }
    }

    private void Dfs(AdjacencyListGraph graph, int vertex)
    {
        _visited[vertex] = true;
        PreVisit(vertex);
        foreach (var edge in graph.AdjacentVertices(vertex))
        {
            if (_visited[edge]) continue;
            Dfs(graph, edge);
        }
        PostVisit(vertex);
    }

    private void PreVisit(int vertex)
    {
        _clockIntervals[vertex, 0] = _clockTick++;
    }

    private void PostVisit(int vertex)
    {
        _clockIntervals[vertex, 1] = _clockTick++;
    }

    public bool IsDisjoint(int v, int w)
    {
        var vIntervals = new Interval(_clockIntervals[v, 0], _clockIntervals[v, 1]);
        var wIntervals = new Interval(_clockIntervals[w, 0], _clockIntervals[w, 1]);
        return vIntervals.IsDisjointWith(wIntervals);
    }

    public bool IsNested(int v, int w)
    {
        var vIntervals = new Interval(_clockIntervals[v, 0], _clockIntervals[v, 1]);
        var wIntervals = new Interval(_clockIntervals[w, 0], _clockIntervals[w, 1]);
        return vIntervals.IsNestedOf(wIntervals) || wIntervals.IsNestedOf(vIntervals);
    }

    private record Interval(int Start, int End)
    {
        public bool IsDisjointWith(Interval interval) => this.Start > interval.End || interval.Start > this.End;
        public bool IsNestedOf(Interval interval) => this.Start > interval.Start || this.End < interval.End;
    }
}