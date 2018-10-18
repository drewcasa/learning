using System;
using System.Collections.Generic;
using System.Text;

namespace Learning
{
    public class UndirectedGraphNode
    {
        public int label;
        public IList<UndirectedGraphNode> neighbors;

        public UndirectedGraphNode(int x)
        {
            label = x;
            neighbors = new List<UndirectedGraphNode>();
        }

        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null) return null;
            return CloneNode(node, new Dictionary<int, UndirectedGraphNode>());
        }

        private UndirectedGraphNode CloneNode(UndirectedGraphNode node, Dictionary<int, UndirectedGraphNode> clones)
        {
            if (clones.ContainsKey(node.label))
                return clones[node.label];

            var clone = new UndirectedGraphNode(node.label);
            clones.Add(clone.label, clone);

            foreach (var neighbor in node.neighbors)
                clone.neighbors.Add(CloneNode(neighbor, clones));

            return clone;
        }
    };
}
