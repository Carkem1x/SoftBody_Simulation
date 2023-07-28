using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This code only works for 2x2 cubes
public class MeshCreator2x2 : MonoBehaviour
{
    public GameObject[] vertexObjects;

    void CreateCube()
    {
        // Create the vertices of the cube
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(vertexObjects[0].transform.position.x,vertexObjects[0].transform.position.y,vertexObjects[0].transform.position.z),   // Vertex 0
            new Vector3(vertexObjects[1].transform.position.x,vertexObjects[1].transform.position.y,vertexObjects[1].transform.position.z),   // Vertex 1
            new Vector3(vertexObjects[2].transform.position.x,vertexObjects[2].transform.position.y,vertexObjects[2].transform.position.z),   // Vertex 2
            new Vector3(vertexObjects[3].transform.position.x,vertexObjects[3].transform.position.y,vertexObjects[3].transform.position.z),   // Vertex 3
            new Vector3(vertexObjects[4].transform.position.x,vertexObjects[4].transform.position.y,vertexObjects[4].transform.position.z),   // Vertex 4
            new Vector3(vertexObjects[5].transform.position.x,vertexObjects[5].transform.position.y,vertexObjects[5].transform.position.z),   // Vertex 5
            new Vector3(vertexObjects[6].transform.position.x,vertexObjects[6].transform.position.y,vertexObjects[6].transform.position.z),   // Vertex 6
            new Vector3(vertexObjects[7].transform.position.x,vertexObjects[7].transform.position.y,vertexObjects[7].transform.position.z)    // Vertex 7
        };

        // Create the cube triangles
        int[] triangles = new int[]
        {   
            
            0, 2, 1,   // Triangle 1
            2, 3, 1,   // Triangle 2
           
            4, 6, 0,   // Triangle 3
            6, 2, 0,   // Triangle 4
            
            5, 7, 4,   // Triangle 5
            7, 6, 4,   // Triangle 6
            
            1, 3, 5,   // Triangle 7
            3, 7, 5,   // Triangle 8

            3, 2, 7,   // Triangle 9
            2, 6, 7,   // Triangle 10
            
            0, 1, 4,   // Triangle 11
            1, 5, 4    // Triangle 12
        };

        // Create the mesh and assign the vertices and triangles
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Calculate the normals and assign them to the mesh to have a smooth appearance
        mesh.RecalculateNormals();

        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        // Add a MeshRenderer component to the cube
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();

        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
    }
    private void FixedUpdate()
    {
        CreateCube();
    }
}
