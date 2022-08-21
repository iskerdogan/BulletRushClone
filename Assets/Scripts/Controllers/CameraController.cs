using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Vector3 offset;

    private void Awake() 
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate() 
    {
        transform.position = target.transform.position + offset;    
    }
}
