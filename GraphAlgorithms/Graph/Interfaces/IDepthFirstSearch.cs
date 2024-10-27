namespace Graph.Undirected.Problems;

public interface IDepthFirstSearch
{
    bool HasPathTo(int s);
    string PathToStr(int s);
    Stack<int> PathTo(int s);
}