using System.Collections.Generic;

namespace Enumerators
{
    public class GraphEnumerator<T> : IEnumerator<T> where T : notnull
    {
        private Dictionary<T, List<T>> graph;
        private T startNode;
        private List<T> traversalOrder;
        private int i; // Current index in the traversal path
        private int n; // Total visited nodes

        public GraphEnumerator(Dictionary<T, List<T>> graph, T startNode)
        {
            this.graph = graph;
            this.startNode = startNode;
            this.traversalOrder = new List<T>();
            this.i = -1;

            CalculateBFS(); // Pre-calculate the traversal order
            this.n = traversalOrder.Count;
        }

        // Helper method to compute Breadth-First Search path
        private void CalculateBFS()
        {
            if (!graph.ContainsKey(startNode)) return;

            HashSet<T> visited = new HashSet<T>();
            Queue<T> queue = new Queue<T>();

            visited.Add(startNode);
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                T current = queue.Dequeue();
                traversalOrder.Add(current);

                if (graph.ContainsKey(current))
                {
                    foreach (T neighbor in graph[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
        }

        public void First()
        {
            i = 0;
        }

        public void Next()
        {
            i++;
        }

        public bool End()
        {
            return i >= n;
        }

        public T Current()
        {
            return traversalOrder[i];
        }
    }
}