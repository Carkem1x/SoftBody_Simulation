using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShapeCreator : MonoBehaviour
{
    public GameObject prefab;               // Prefab of nodes
    public int gridSize = 3;                // Tamaño del cubo en la rejilla
    public float spacing = 1f;              // Space between nodes

    public float stiffness = 0.5f;              // SoftBody Stiffness
    public float damping = 0.5f;                // SoftBody Damping

    private GameObject[,,] cubeGrid;        // Matrix of nodes

    private void Start()
    {
        BuildCube();
    }
    private void FixedUpdate()
    {
        ApplyForces();
    }

    private void BuildCube()
    {
        cubeGrid = new GameObject[gridSize, gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    Vector3 position = new Vector3(x * spacing, y * spacing, z * spacing);
                    GameObject cube = Instantiate(prefab, position, Quaternion.identity);
                    cube.name = x + "," + y + "," + z;
                    cubeGrid[x, y, z] = cube;
                }
            }
        }

        ConnectCubes();
    }

    private void ConnectCubes()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    GameObject cube = cubeGrid[x, y, z];

                    //Conection Right
                    if (x < gridSize - 1)
                    {
                        GameObject rightNeighbor = cubeGrid[x + 1, y, z];
                        ConnectNodes(cube, rightNeighbor);
                    }

                    //Conection Top
                    if (y < gridSize - 1)
                    {
                        GameObject topNeighbor = cubeGrid[x, y + 1, z];
                        ConnectNodes(cube, topNeighbor);
                    }

                    //Conection Front
                    if (z < gridSize - 1)
                    {
                        GameObject frontNeighbor = cubeGrid[x, y, z + 1];
                        ConnectNodes(cube, frontNeighbor);
                    }
                }
            }
        }
    }

    private void ConnectNodes(GameObject indexA, GameObject indexB)
    {
        FixedJoint jointAtoB = indexA.GetComponent<FixedJoint>();
        jointAtoB.connectedBody = indexB.GetComponent<Rigidbody>();
        jointAtoB.enableCollision = false;
        jointAtoB.breakForce = Mathf.Infinity;
        jointAtoB.breakTorque = Mathf.Infinity;

        FixedJoint jointBtoA = indexB.GetComponent<FixedJoint>();
        jointBtoA.connectedBody = indexA.GetComponent<Rigidbody>();
        jointBtoA.enableCollision = false;
        jointBtoA.breakForce = Mathf.Infinity;
        jointBtoA.breakTorque = Mathf.Infinity;
    }

    private void ApplyForces()
    {
        foreach (GameObject _nodes in cubeGrid)
        {
            var rbnodes = _nodes.GetComponent<Rigidbody>();
            Vector3 force = -stiffness * (_nodes.transform.position - rbnodes.position) - damping * rbnodes.velocity;
            rbnodes.AddForce(force, ForceMode.Force);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    GameObject cube = cubeGrid[x, y, z];

                    //Conection Right
                    if (x < gridSize - 1)
                    {
                        GameObject rightNeighbor = cubeGrid[x + 1, y, z];
                        Gizmos.DrawLine(cube.transform.position, rightNeighbor.transform.position);
                    }

                    // Conection Top
                    if (y < gridSize - 1)
                    {
                        GameObject topNeighbor = cubeGrid[x, y + 1, z];
                        Gizmos.DrawLine(cube.transform.position, topNeighbor.transform.position);
                    }

                    // Conection Front
                    if (z < gridSize - 1)
                    {
                        GameObject frontNeighbor = cubeGrid[x, y, z + 1];
                        Gizmos.DrawLine(cube.transform.position, frontNeighbor.transform.position);
                    }
                }
            }
        }
    }
}
