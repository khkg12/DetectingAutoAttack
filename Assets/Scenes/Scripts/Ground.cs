using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ground : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.TryGetComponent(out IWalkable walkable))
        {
            walkable.Walk();
        }
    }
}
