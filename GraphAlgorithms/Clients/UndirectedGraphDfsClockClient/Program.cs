using Graph.Undirected;
using Graph.Undirected.Problems;

var graph = new AdjacencyListGraph(13);
graph.AddEdge(0, 1);
graph.AddEdge(0, 2);
graph.AddEdge(0, 5);
graph.AddEdge(0, 6);
graph.AddEdge(3, 4);
graph.AddEdge(3, 5);
graph.AddEdge(4, 5);
graph.AddEdge(4, 6);
graph.AddEdge(7, 8);
graph.AddEdge(9, 10);
graph.AddEdge(9, 11);
graph.AddEdge(9, 12);
graph.AddEdge(11, 12);

var dfsClock = new DfsClock(graph);
Console.WriteLine(dfsClock.IsDisjoint(6,9));
Console.WriteLine(dfsClock.IsNested(6,0));
Console.WriteLine(dfsClock.IsDisjoint(6,5));
