﻿using Graph.Undirected;
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

var dfsAlgorithm = new DepthFirstSearch(graph, 0);
Console.WriteLine($" (0 -> 12)?: {dfsAlgorithm.HasPathTo(12)}");
Console.WriteLine($" (0 -> 6)?: {dfsAlgorithm.HasPathTo(6)}");
Console.WriteLine(dfsAlgorithm.PathToStr(3));
Console.WriteLine(dfsAlgorithm.PathToStr(6));