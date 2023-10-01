using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public RotateComponent rc;
    void Start()
    {
        rc = GetComponent<RotateComponent>();   
        rc.isRotatePossible = false;
        rc.Speed = 3;
        OnTrap();

    }

    public void OnTrap()
    {
        rc.isRotatePossible = true; 
    }
}
