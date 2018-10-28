using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learning.Graphs
{
    public class TopologicalSort
    {

        public static List<string> BruteForceSort(Dictionary<string, HashSet<string>> map)
        {
            var keys = new HashSet<string>(map.Keys);
            var sorted = new List<string>();
            bool anySorted = true;

            // start with elements that have no dependencies
            while (anySorted && map.Count > 0)
            {
                anySorted = false;
                foreach (var key in keys) // n^2
                {
                    if (map[key].Count == 0)
                    {
                        // add to sorted collection, remove from dependencies map and other dependent nodes
                        sorted.Add(key);
                        anySorted = true;
                        map.Remove(key);
                        foreach (var kvp in map) // n^3
                            kvp.Value.Remove(key);
                    }
                }
            }

            if (map.Count > 0)
                throw new InvalidOperationException();

            return sorted;
        }

        public static List<string> DepthFirstSort(Dictionary<string, HashSet<string>> map)
        {
            var graph = new Graph<string>(map);
            return DepthFirstSort(graph);
        }

        public static List<T> DepthFirstSort<T>(Graph<T> graph)
        {
            var sorted = new List<T>();

            foreach (var node in graph.Nodes.Values)
                Visit(node, sorted);

            return sorted;
        }

        private static void Visit<T>(GraphNode<T> node, List<T> sorted)
        {
            node.IsVisited = true;

            foreach (var dep in node.Dependencies)
            {
                if (dep.IsSorted) continue;
                if (dep.IsVisited) throw new InvalidOperationException("Circular dependency found.");
                Visit(dep, sorted);
            }

            node.IsSorted = true;
            sorted.Add(node.Value);
        }

    }

    public class GraphNode<T>
    {
        public T Value;
        public bool IsVisited;
        public bool IsSorted;
        public List<GraphNode<T>> Dependencies;
        public IEnumerable<T> _depKeys;

        public GraphNode(T key, IEnumerable<T> depKeys)
        {
            Value = key;
            IsVisited = false;
            IsSorted = false;
            Dependencies = new List<GraphNode<T>>();
            _depKeys = depKeys;
        }

        public GraphNode(T key)
        {
            Value = key;
            IsVisited = false;
            IsSorted = false;
            Dependencies = new List<GraphNode<T>>();
        }

        public void FillDependencies(Dictionary<T, GraphNode<T>> graph)
        {
            foreach (var key in _depKeys)
                Dependencies.Add(graph[key]);
        }

    }

    public class Graph<T>
    {
        public Dictionary<T, GraphNode<T>> Nodes;

        private Graph()
        {
            Nodes = new Dictionary<T, GraphNode<T>>();
        }

        public Graph(Dictionary<T, HashSet<T>> map, bool isFaster)
        {
            foreach (var kvp in map)
                Nodes[kvp.Key] = new GraphNode<T>(kvp.Key);
            foreach (var kvp in map)
            {
                var node = Nodes[kvp.Key];
                foreach (var depKey in kvp.Value)
                    node.Dependencies.Add(Nodes[depKey]);
            }
        }

        public Graph(Dictionary<T, HashSet<T>> map)
        {
            foreach (var kvp in map)
                Nodes[kvp.Key] = new GraphNode<T>(kvp.Key, kvp.Value);
            foreach (var node in Nodes.Values)
                node.FillDependencies(Nodes);
        }

        public Graph(IEnumerable<Tuple<T, T>> pairs)
        {
            foreach (var pair in pairs)
            {
                var curr = GetNode(pair.Item1);
                curr.Dependencies.Add(GetNode(pair.Item2));
            }
        }

        public GraphNode<T> GetNode(T value)
        {
            if (!Nodes.ContainsKey(value))
                Nodes[value] = new GraphNode<T>(value);
            return Nodes[value];
        }

    }

}
