using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : Kinematic
{
    public Node start;
    public Node goal;
    Graph myGraph;

    GameObject[] myPath;

    Path myMoveType;
    LookWhereGoing myRotateType;

    private void Start()
    {
        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;

        Graph myGraph = new Graph();
        myGraph.Build(this.gameObject);
        List<Connection> path = PathFindDijkstra.Pathfinding(myGraph, start, goal);


        myPath = new GameObject[path.Count + 1];
        int i = 0;
        foreach(Connection c in path)
        {
            myPath[i] = c.GetFromNode().gameObject;
            i++;
        }
        myPath[i] = goal.gameObject;

        myMoveType = new Path();
        myMoveType.character = this;
        myMoveType.PathCheckPoints = myPath;
    }

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.angular = myRotateType.getSteering().angular;
        steeringUpdate.linear = myMoveType.getSteering().linear;
        base.Update();
    }
}
