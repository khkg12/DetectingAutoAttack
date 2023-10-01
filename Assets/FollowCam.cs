using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform Target;
    Transform tr;
    void Start()
    {
        tr = transform;
    }
    
    void Update()
    {
        tr.position = new Vector3(Target.position.x, Target.position.y + 20, Target.position.z);
        transform.LookAt(Target.position);
    }
}
