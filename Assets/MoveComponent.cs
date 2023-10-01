using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{    
    // 이동 속도
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
    private float speed;
    private float maxSpeed = 10;
    private float minSpeed = 0;

    // 이동 방향
    public Vector3 moveVec;
    
    [SerializeField] private float holdTime;
    [SerializeField] private float moveTime;

    private void Start()
    {
        Speed = 10;
        StartCoroutine(MoveCo());
    }    

    IEnumerator MoveCo()
    {
        while (true)
        {
            float time = 0;
            while (time < moveTime)
            {
                time += Time.deltaTime;
                transform.Translate(moveVec * Speed * Time.deltaTime, Space.World);
                yield return null;
            }
            yield return new WaitForSeconds(holdTime);
            moveVec *= -1;
        }
    }
}
