using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPet : MonoBehaviour
{
    Queue<Vector3> playerPosQueue = new Queue<Vector3>();
    public Transform playerTr;   
    
    void Update()
    {
        if((playerTr.position - transform.position).magnitude >= 0.1f) playerPosQueue.Enqueue(playerTr.position);
        if (playerPosQueue.Count > 0){
            Vector3 pos = playerPosQueue.Dequeue();
            transform.position = Vector3.MoveTowards(transform.position, pos, 0.1f);            
        }        
    }

    //IEnumerator FollowCo()
    //{
    //    while (true)
    //    {
    //        if ((playerTr.position - transform.position).magnitude >= 0.1f) playerPosQueue.Enqueue(playerTr.position);
    //        yield return null;
    //    }
    //}
}
