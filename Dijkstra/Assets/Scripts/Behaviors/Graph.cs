using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph 
{
    List<Connection> mConnections;

    public List<Connection> GetConnections(Node fromNode)
    {
        List<Connection> connections = new List<Connection>();
        foreach(Connection c in mConnections)
        {
            if(c.GetFromNode() == fromNode)
            {
                connections.Add(c);
            }
        }

        return connections;
    }

    public void Build(GameObject character)
    {
        mConnections = new List<Connection>();

        Node[] nodes = GameObject.FindObjectsOfType<Node>();

        foreach (Node fromNode in nodes)
        {
            foreach (Node toNode in fromNode.ConnectsTo)
            {
                //float cost = 1;
                float cost = Random.Range(1, 20);
                Connection c = new Connection(cost, fromNode, toNode);
                mConnections.Add(c);
            }
        }
    }
}


public class Connection
{
    float cost;
    Node fromNode;
    Node toNode;

    public Connection(float cost, Node fromNode, Node toNode)
    {
        this.cost = cost;
        this.fromNode = fromNode;
        this.toNode = toNode;
    }
    public float GetCost() { return cost; }

   public Node GetFromNode() { return fromNode; }

    public Node GetToNode() { return toNode; }
}