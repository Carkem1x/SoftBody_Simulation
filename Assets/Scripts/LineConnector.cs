using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector : MonoBehaviour
{
    public Transform NextNodePosition;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(gameObject.transform.position, NextNodePosition.transform.position);
    }
}
