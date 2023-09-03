using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathNode : MonoBehaviour, IPathNode<PathNode>
{
    public List<PathNode> connections;

    public static int pnIndex;

    public Color nodeColor = new Color(0.05f, 0.3f, 0.05f, 0.5f);
    public float nodeGizmoSize = 1f;

    public bool invalid;
    public bool Invalid
    {
        //get { return (this == null); }
        get { return invalid; }
    }

    public bool generateTwoWayConnections = true;
    
    [HideInInspector]
    public bool wasGenerated = false;

    public List<PathNode> Connections
    {
        get { return connections; }
    }

    public Vector3 Position
    {
        get
        {

            return transform.position;
        }
    }

    //public void Update()
    void OnDrawGizmos()
    {
        if (wasGenerated && connections.Count == 0) return;

        var inPath = pathFollower != null && pathFollower.solvedPathNodes != null && pathFollower.solvedPathNodes.Contains(this);
        //DrawHelper.DrawCube(transform.position, Vector3.one * nodeGizmoSize, inPath ? Color.red : nodeColor);
        DrawHelper.DrawCircle(transform.position, nodeGizmoSize, inPath ? Color.red : nodeColor);
        if (connections == null)
            return;
        for (int i = 0; i < connections.Count; i++)
        {
            if (connections[i] == null)
                continue;
            Debug.DrawLine(transform.position, connections[i].Position, nodeColor);
        }
    }

    PathFollower pathFollower;
    public void Awake()
    {
        pathFollower = FindObjectOfType<PathFollower>();

        if (connections == null)
            connections = new List<PathNode>();

        if (generateTwoWayConnections)
        {
            foreach (var connection in connections)
            {
                var otherConnections = connection.connections;
                if (otherConnections == null)
                    otherConnections = new List<PathNode>();
                otherConnections.Add(this);
            }
        }
    }

    
}