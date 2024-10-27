using Graph.Undirected;

var graph = new AdjacencyMatrixGraph(13);

graph.AddEdge(0,1);
graph.AddEdge(0,2);
graph.AddEdge(0,5);
graph.AddEdge(0,6);
graph.AddEdge(3,4);
graph.AddEdge(3,5);
graph.AddEdge(4,5);
graph.AddEdge(4,6);
graph.AddEdge(7,8);
graph.AddEdge(9,10);
graph.AddEdge(9,11);
graph.AddEdge(9,12);
graph.AddEdge(11,12);


Console.WriteLine($"Total Number Of Edges: {graph.Edges()}");
Console.WriteLine($"Total Number of Vertex(0) Edges: {graph.Edges(0)}");
graph.RemoveEdge(9,11);
graph.RemoveEdge(11,12);

Console.WriteLine(graph);