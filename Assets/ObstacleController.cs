using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float holdTime;
    [SerializeField] private float moveTime;
    Vector3 vec;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vec = moveSpeed * transform.up;
        StartCoroutine(OpenDoorCo());
    }
        
    IEnumerator OpenDoorCo()
    {
        while (true)
        {
            float time = 0;
            while (time < moveTime)
            {
                time += Time.deltaTime;                
                transform.Translate(vec);
                yield return null;
            }
            yield return new WaitForSeconds(holdTime);
            vec *= -1;
        }    
    }
}
