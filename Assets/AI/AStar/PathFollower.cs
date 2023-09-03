using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : Mover
{
    //who are we following?
    public Transform target;

    //track all the nodes in the game world
    List<PathNode> nodes;

    //the current path to the target
    [HideInInspector]
    public List<PathNode> solvedPathNodes;

    //the node we want to find a path to using A-Star
    PathNode currentNodeClosestToTarget;

    //the node we are currently travelling towards
    PathNode nextNode;

    //find all the nodes, and then calculate a path to the target
    protected override void Start()
    {
        base.Start();

        GetAllNodes();
        UpdateTargetNodeIfNecessary();
    }

    void FixedUpdate()
    {
        //check to see if we need to take a different path to where we are currently going to get to the target
        if (target != null)
        {
            UpdateTargetNodeIfNecessary();
        }

        //if there is a path to follow
        if (solvedPathNodes != null && solvedPathNodes.Count > 0)
        {
            //seek the next node in the path
            nextNode = solvedPathNodes[0];
            MoveToNode(nextNode); //lerp function sets a velocity

            //if we have reached the next node, remove it from the path, so that we can begin seeking the next node
            if (DistanceBetween(nextNode, transform) < 0.5f)
            {
                RemoveFirstNodeInPath();
            }
        }
        //if there is no more path nodes left, then we need to keep on going toward the target
        else if (target != null)
        {
            MoveToTarget();
        }

        //call the mover base function so that we can still move
        base.Move();
    }

    //Moving functions (uses basic seek functionality for both node movement and target tracking)
    void MoveToNode(PathNode node)
    {
        MoveTo(node.transform);
    }
    void MoveToTarget()
    {
        MoveTo(target.transform);
    }
    void MoveTo(Transform other)
    { 
        //reuse the seek code here:
        var sep = other.transform.position - transform.position;
        desiredVelocity = sep.normalized * speed * Time.deltaTime;
    }

    //Find all the nodes in the world -- we only do this once, but in more complicated games the nodes may change during play
    void GetAllNodes()
    {
        nodes = new List<PathNode>();
        foreach (var node in FindObjectsOfType<PathNode>())
        {
            nodes.Add(node);
        }
    }

    //Work out which node is closest to the target. If we have a new node to track, we need to calculate a new path
    void UpdateTargetNodeIfNecessary()
    {
        var closestToTargetNow = GetClosestNodeToTarget();
        if (closestToTargetNow != currentNodeClosestToTarget)
        {
            currentNodeClosestToTarget = closestToTargetNow;
            FindPath(currentNodeClosestToTarget);
        }
    }

    //Use A-Star to find the shortest path between where we are now, and the node "to" (usually the currentNodeClosestToTarget)
    void FindPath(PathNode to)
    {
        //we need to find a path either from the node we are currently moving towards, or if such a node doesn't exist, the node closest to us
        var from = nextNode != null ? nextNode : GetClosestNodeToUs();

        //this is the line that actually calculates the path (feel free to explore the AStarHelper class)
        solvedPathNodes = AStarHelper.Calculate(from, to);
        /* //you can uncomment this to see the path that was generated
        if (solvedPathNodes != null)
        {
            Debug.Log("New path with " + solvedPathNodes.Count + " nodes");
            foreach (var node in solvedPathNodes)
            {
                Debug.Log(node.transform.position, node.gameObject);
            }
        }*/
    }

    //helper functions to find the nodes that are closest to various things
    PathNode GetClosestNodeToTarget()
    {
        return GetClosestNodeTo(target.transform);
    }
    PathNode GetClosestNodeToUs()
    {
        return GetClosestNodeTo(transform);
    }
    PathNode GetClosestNodeTo(Transform other)
    { 
        PathNode closestNode = null;
        float closestDistance = float.MaxValue;
        foreach (var node in nodes)
        {
            var distance = DistanceBetween(node, other);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestNode = node;
            }
        }
        return closestNode;
    }
    float DistanceBetween(PathNode node, Transform transform)
    {
        return (node.transform.position - transform.position).magnitude;
    }

    //helper function for removing the first node in the solved path
    void RemoveFirstNodeInPath()
    {
        if (solvedPathNodes != null) solvedPathNodes.RemoveAt(0);
    }
}
