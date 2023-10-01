using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    public bool isRotatePossible = true;
    public Vector3 dir;
    private const float maxSpeed = 10;
    private const float minSpeed = 0;

    [SerializeField] private float speed;
    public float Speed
    {
        get => speed;
        set
        {
            speed = value;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
            else if(speed < minSpeed)
            {
                speed = minSpeed;
            }            
        }
    }
    
    [SerializeField] Space space;
    
    void Update()
    {
        if (isRotatePossible)
        {
            transform.Rotate(dir, speed, space);
        }        
    }
}
