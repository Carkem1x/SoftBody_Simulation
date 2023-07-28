using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FixedJoint))]
[RequireComponent(typeof(Rigidbody))]
public class Node : MonoBehaviour
{
    /// <summary>
    /// list of adjacent nodes
    /// </summary>
    public List<GameObject> AdjecentNodes = new List<GameObject>();
    public float stiffness = 0.5f;              // SoftBody Stiffness
    public float damping = 0.5f;                // SoftBody Damping

    private void Start()
    {
        ConnectNodes();
    }

    private void FixedUpdate()
    {
        ApplyForces();
    }

    /// <summary>
    /// Connect each node to the nodes in the list with a FixedJoint component
    /// </summary> 
    private void ConnectNodes()
    {

        foreach (GameObject _nodes in AdjecentNodes)
        {
            ConnectNodesWithSpring(this.transform, _nodes.transform);
        }
       
    }
    private void ConnectNodesWithSpring(Transform nodeA, Transform nodeB)
    {
        FixedJoint joint = nodeA.gameObject.GetComponent<FixedJoint>();
        
            joint.connectedBody = nodeB.GetComponent<Rigidbody>();
            joint.enableCollision = false;
            joint.breakForce = Mathf.Infinity;
            joint.breakTorque = Mathf.Infinity;
        
    }

    /// <summary>
    /// Calculate and apply the damping force
    /// </summary>
    private void ApplyForces()
    {
        foreach (GameObject _nodes in AdjecentNodes)
        {
            var rbnodes = _nodes.GetComponent<Rigidbody>();
            Vector3 force = -stiffness * (_nodes.transform.position - rbnodes.position) - damping * rbnodes.velocity;
            rbnodes.AddForce(force, ForceMode.Force);
        }
    }

    private void OnDrawGizmos()
    {
        foreach (GameObject _nodes in AdjecentNodes)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(gameObject.transform.position, _nodes.transform.position);
        }
    }
}
