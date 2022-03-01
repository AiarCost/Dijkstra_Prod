using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathFindDijkstra 
{
    public class NodeRecord: IComparable<NodeRecord>
    {
        public Node node;
        public Connection connection;
        public float costSoFar;

        public int CompareTo(NodeRecord other)
        {
            if(other == null)
            {
                return 1;
            }

            return (int)(costSoFar - other.costSoFar);
        }
    }

    public class PathfindingList
    {
        List<NodeRecord> nodeRecords = new List<NodeRecord>();


        public void Add(NodeRecord n) { nodeRecords.Add(n); }
        public void Remove(NodeRecord n) { nodeRecords.Remove(n); }
        public NodeRecord SmallestElement()
        {
            nodeRecords.Sort();
            return nodeRecords[0];
        }
        public int Length()
        {
            return nodeRecords.Count;
        }

        public bool Contains(Node node)
        {
            foreach(NodeRecord n in nodeRecords)
            {
                if(n.node == node)
                {
                    return true;
                }
            }
            return false;
        }

        public NodeRecord Find ( Node node)
        {
            foreach (NodeRecord n in nodeRecords)
            {
                if(n.node == node)
                {
                    return n;
                }
            }

            return null;
        }
    }


    public static List<Connection> Pathfinding(Graph graph, Node start, Node goal)
    {
        NodeRecord startRecord = new NodeRecord();
        startRecord.node = start;
        startRecord.connection = null;
        startRecord.costSoFar = 0;

        PathfindingList open = new PathfindingList();
        open.Add(startRecord);
        PathfindingList closed = new PathfindingList();

        NodeRecord current = new NodeRecord();
        while(open.Length() > 0)
        {
            current = open.SmallestElement();

            if (current.node == goal)
                break;

            List<Connection> connections = graph.GetConnections(current.node);

            foreach (Connection connection in connections)
            {
                Node endNode = connection.GetToNode();
                float endNodeCost = current.costSoFar + connection.GetCost();

                NodeRecord endNodeRecord = new NodeRecord();

                if (closed.Contains(endNode))
                {
                    continue;
                }
                else if (open.Contains(endNode))
                {
                    endNodeRecord = open.Find(endNode);
                    if(endNodeRecord != null && endNodeRecord.costSoFar < endNodeCost)
                    {
                        continue;
                    }


                }
                else
                {
                    endNodeRecord = new NodeRecord();
                    endNodeRecord.node = endNode;
                }

                endNodeRecord.costSoFar = endNodeCost;
                endNodeRecord.connection = connection;

                if (!open.Contains(endNode))
                {
                    open.Add(endNodeRecord);
                }
            }


            open.Remove(current);
            closed.Add(current);


        }//While Bracket


        if(current.node != goal)
        {
            return null;
        }

        else
        {
            List<Connection> path = new List<Connection>();
            while(current.node != start)
            {
                path.Add(current.connection);
                Debug.Log(current.connection);
                Debug.Log(current.connection.GetFromNode());
                Node fromNode = current.connection.GetFromNode();
                current = closed.Find(fromNode);
            }

            path.Reverse();
            return path;
        }

    }
}
