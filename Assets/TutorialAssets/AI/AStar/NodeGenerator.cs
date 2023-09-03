using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject nodePrefab;
    List<PathNode> nodes;

    public int cols = 10;
    public int rows = 10;
    public float horizontalSpacing = 1;
    public float verticalSpacing = 1;

	// Use this for initialization
	void Awake ()
    {
        nodes = new List<PathNode>();
	    for (var y = -rows/2; y < rows/2; y++)
        {
            for (var x = -cols/2; x < cols/2; x++)
            {
                var point = (Vector2)transform.position + new Vector2(x * horizontalSpacing, y * verticalSpacing);
                //only place a node if there is no collider in the area
                var hit = Physics2D.OverlapCircle(point, 0.25f, layerMask);

                if (hit == null)
                {
                    var go = GameObject.Instantiate(nodePrefab, point, Quaternion.identity);
                    var node = go.GetComponent<PathNode>();
                    node.wasGenerated = true;
                    nodes.Add(node);
                }
            }
        }

        for (var i = 0; i < nodes.Count; i++)
        {
            nodes[i].connections = new List<PathNode>();
            for (var j = 0; j < nodes.Count; j++)
            {
                //only bother if this node is near us
                var distanceBetween = (nodes[i].transform.position - nodes[j].transform.position).magnitude;
                if (distanceBetween < 2)
                {
                    var hit = Physics2D.Raycast(nodes[i].transform.position, nodes[j].transform.position - nodes[i].transform.position, 1, layerMask:layerMask);
                    if (hit.collider == null)
                    {
                        nodes[i].connections.Add(nodes[j]);
                    }
                }
            }
        }
	}
}
