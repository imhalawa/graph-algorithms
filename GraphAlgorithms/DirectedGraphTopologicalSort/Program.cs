// See https://aka.ms/new-console-template for more information

using Graph.DirectedGraph;
using Graph.DirectedGraph.Operations;

var graph = new AdjacencyListDirectedGraph();
graph.AddEdge(0, 4);
graph.AddEdge(4, 7);
graph.AddEdge(2, 6);
graph.AddEdge(6, 7);
graph.AddEdge(1, 5);
graph.AddEdge(3, 7);

// By Definition, 0 -> Source, 3 -> 1st-Sink
// var sortedGraph = TopologicalSort.IterativeSort(graph);
var sortedGraph = TopologicalSort.IndegreeSort(graph);

while (sortedGraph.Count > 0)
{
    Console.WriteLine(sortedGraph.Dequeue());
}