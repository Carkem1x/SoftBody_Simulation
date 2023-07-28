using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealisticSoftBodyNode : MonoBehaviour
{
    public float nodeMass = 1f;                 // Mass of node
    public float stiffness = 0.5f;              // SoftBody Stiffness
    public float damping = 0.5f;                // SoftBody Damping
    public float MaxDistance = 3f;
    public float MinDistance = 0;

    public List<GameObject> AdjecentNodes = new List<GameObject>();

    private void Start()
    {
        CreateSoftBody();
    }

    private void FixedUpdate()
    {
        ApplyForces();
    }

    private void CreateSoftBody()
    {
        ConnectNodes();
    }

    private void ConnectNodes()
    {
        foreach (GameObject _nodes in AdjecentNodes)
        {
            ConnectNodesWithSpring(this.transform, _nodes.transform);
        }
    }

    private void ConnectNodesWithSpring(Transform nodeA, Transform nodeB)
    {
        SpringJoint joint = nodeA.gameObject.AddComponent<SpringJoint>();
        joint.connectedBody = nodeB.GetComponent<Rigidbody>();
        joint.autoConfigureConnectedAnchor = true;
        joint.spring = stiffness;
        joint.damper = damping;
        joint.minDistance = MinDistance;
        joint.maxDistance = MaxDistance;
        joint.enableCollision = true;
    }

    private void ApplyForces()
    {
        var rb = this.GetComponent<Rigidbody>();
        Vector3 force = -stiffness * (this.transform.position - rb.position) - damping * rb.velocity;
        rb.AddForce(force, ForceMode.Force);
    }

    private void OnDrawGizmos()
    {
        foreach (GameObject _nodes in AdjecentNodes)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawLine(gameObject.transform.position, _nodes.transform.position);
        }
    }
}
