using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learning
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
            return DepthFirstSort(GraphNode.BuildGraph(map));
        }

        public static List<string> DepthFirstSort(Dictionary<string, GraphNode> graph)
        {
            var sorted = new List<string>();

            foreach (var node in graph.Values)
                Visit(node, sorted);

            return sorted;
        }

        private static void Visit(GraphNode node, List<string> sorted)
        {
            node.IsVisited = true;

            foreach (var dep in node.Dependencies)
            {
                if (dep.IsSorted) continue;
                if (dep.IsVisited) throw new InvalidOperationException("Circular dependency found.");
                Visit(dep, sorted);
            }

            node.IsSorted = true;
            sorted.Add(node.Key);
        }

    }

    public class GraphNode
    {
        public string Key;
        public bool IsVisited;
        public bool IsSorted;
        public List<GraphNode> Dependencies;
        public IEnumerable<string> _depKeys;

        public GraphNode(string key, IEnumerable<string> depKeys)
        {
            Key = key;
            IsVisited = false;
            IsSorted = false;
            Dependencies = new List<GraphNode>();
            _depKeys = depKeys;
        }

        public GraphNode(string key)
        {
            Key = key;
            IsVisited = false;
            IsSorted = false;
            Dependencies = new List<GraphNode>();
        }

        public void FillDependencies(Dictionary<string, GraphNode> graph)
        {
            foreach (var key in _depKeys)
                Dependencies.Add(graph[key]);
        }

        public static Dictionary<string, GraphNode> BuildGraph(Dictionary<string, HashSet<string>> map)
        {
            var graph = new Dictionary<string, GraphNode>();

            foreach (var kvp in map)
                graph[kvp.Key] = new GraphNode(kvp.Key, kvp.Value);
            foreach (var node in graph.Values)
                node.FillDependencies(graph);

            return graph;
        }

        public static Dictionary<string, GraphNode> BuildGraphFaster(Dictionary<string, HashSet<string>> map)
        {
            var graph = new Dictionary<string, GraphNode>();

            foreach (var kvp in map)
                graph[kvp.Key] = new GraphNode(kvp.Key);
            foreach (var kvp in map)
            {
                var node = graph[kvp.Key];
                foreach (var depKey in kvp.Value)
                    node.Dependencies.Add(graph[depKey]);
            }

            return graph;
        }

    }


}
