using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSoftBody : MonoBehaviour
{
    public int numNodes = 10;                   // Number of nodes
    public float nodeMass = 1f;                 // Mass of Node
    public float stiffness = 0.5f;              // SoftBody Stiffness
    public float damping = 0.5f;                // SoftBody Damping
    public GameObject nodePrefab;               // SoftBody Node Prefab

    private GameObject[] nodes;                 
    private Rigidbody[] nodeRigidbodies;        

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
        nodes = new GameObject[numNodes];
        nodeRigidbodies = new Rigidbody[numNodes];

        for (int i = 0; i < numNodes; i++)
        {
            GameObject node = Instantiate(nodePrefab, transform.position + Vector3.up * i, Quaternion.identity);
            node.transform.parent = transform;

            Rigidbody rb = node.GetComponent<Rigidbody>();
            rb.mass = nodeMass;

            nodes[i] = node;
            nodeRigidbodies[i] = rb;
        }

        for (int i = 0; i < numNodes - 1; i++)
        {
            ConnectNodes(i, i + 1);
        }
    }

    //Create a fixedPoint constraint between two adjacent nodes to keep them connected. forming a rope
    private void ConnectNodes(int indexA, int indexB)
    {
        FixedJoint joint = nodes[indexA].AddComponent<FixedJoint>();
        joint.connectedBody = nodeRigidbodies[indexB];
        joint.enableCollision = false;
        joint.breakForce = Mathf.Infinity;
        joint.breakTorque = Mathf.Infinity;
    }

    //Calculate and apply the damping force
    private void ApplyForces()
    {
        for (int i = 0; i < numNodes; i++)
        {
            Vector3 force = -stiffness * (nodes[i].transform.position - nodeRigidbodies[i].position) - damping * nodeRigidbodies[i].velocity;
            nodeRigidbodies[i].AddForce(force, ForceMode.Force);
        }
    }

}
