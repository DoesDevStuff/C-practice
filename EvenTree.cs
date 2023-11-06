using System;
using System.Collections.Generic;

namespace EvenTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the input for N and M, representing the number of nodes and edges
            string[] NM = Console.ReadLine().Split(' ');

            int N = Int32.Parse(NM[0]);
            int M = Int32.Parse(NM[1]);

            // Initialize the root node
            Node root = null;

            // Read and process each edge
            for (int i = 0; i < M; i++)
            {
                // Read the edge input
                string[] edge = Console.ReadLine().Split(' ');

                // Parse the initial and final nodes of the edge
                int initial = Int32.Parse(edge[0]);
                int final = Int32.Parse(edge[1]);

                // Create node instances for the edge
                Node node1 = new Node(initial);
                Node node2 = new Node(final);

                // If root is not assigned, set it to node1
                if (root == null)
                    root = node1;

                // Insert the nodes into the tree
                root.Insert(node1, node2);
            }

            // Output the result of removing edges to make the tree even
            Console.WriteLine(Node.RemoveEdges(root));
        }
    }

    class Node
    {
        private List<Node> adjacentNode;
        public int NodeValue { get; set; }

        public Node()
        {
            adjacentNode = new List<Node>();
        }

        public Node(int value) : this()
        {
            NodeValue = value;
        }

        // Recursive method to calculate the number of vertices and edges to remove
        private static int GetVertexCount(Node root, ref int removableEdgesCount)
        {
            int vertexCount = 1;

            foreach (Node child in root.adjacentNode)
                vertexCount += GetVertexCount(child, ref removableEdgesCount);

            // If the vertex count is even, increment the removableEdgesCount
            if ((vertexCount % 2) == 0)
                removableEdgesCount++;

            return vertexCount;
        }

        // Public method to initiate the removal of edges
        public static int RemoveEdges(Node root)
        {
            int edgeCount = 0;

            // Call the recursive method to calculate removable edges
            GetVertexCount(root, ref edgeCount);

            // Return the result after removing edges to make the tree even
            return edgeCount - 1;
        }

        // Method to insert nodes into the tree
        public void Insert(Node node1, Node node2)
        {
            Node n1 = Dfs(this, node1);
            Node n2 = Dfs(this, node2);

            // If both nodes are not found, add them to each other's adjacent nodes
            if ((n1 == null) && (n2 == null))
            {
                node1.adjacentNode.Add(node2);
                adjacentNode.Add(node1);
            }
            // If one node is found, add the other node to its adjacent nodes
            else if ((n1 != null) && (n2 == null))
            {
                n1.adjacentNode.Add(node2);
            }
            else if ((n1 == null) && (n2 != null))
            {
                n2.adjacentNode.Add(node1);
            }
        }

        // Depth-first search to find a specific node in the tree
        private Node Dfs(Node root, Node target)
        {
            // If the current node is the target, return it
            if (root == target)
                return root;
            // Otherwise, recursively search in the adjacent nodes
            else
            {
                foreach (Node child in root.adjacentNode)
                {
                    Node res = Dfs(child, target);

                    // If the target is found in the subtree, return the result
                    if (res != null)
                        return res;
                }
            }

            // If the target is not found in the subtree, return null
            return null;
        }

        // Override equality operators to compare nodes based on their values
        public static bool operator ==(Node node1, Node node2)
        {
            if (ReferenceEquals(node1, node2))
                return true;
            else if (((object)node1 == null) || ((object)node2 == null))
                return false;

            return (node1.NodeValue == node2.NodeValue);
        }

        public static bool operator !=(Node node1, Node node2)
        {
            return !(node1 == node2);
        }
    }
}
