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

var ccBuilder = new ConnectedComponentsBuilder(graph);
var connectedComponents = ccBuilder.GetConnectedComponents();
connectedComponents.ToList().ForEach(connectedComponent =>
{
    connectedComponent.ForEach(v =>
    {
        Console.Write($"{v},");
    });
    Console.WriteLine("\n------------------------------");
});