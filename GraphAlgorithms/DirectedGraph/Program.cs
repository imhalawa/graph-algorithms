using Graph.DirectedGraph;
using Graph.DirectedGraph.Operations;

var graph = new AdjacencyListDirectedGraph();
graph.AddEdge(0,1);
graph.AddEdge(0,2);
graph.AddEdge(0,4);
graph.AddEdge(1,3);
graph.AddEdge(3,4);
graph.AddEdge(4,3); // --> Cycle
graph.AddEdge(3,3); // --> Self-loop
Console.WriteLine(graph);