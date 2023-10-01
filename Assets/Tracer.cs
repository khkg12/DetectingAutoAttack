using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{        
    Stack<Vector3> stk = new Stack<Vector3>();
    int max = 1000;
    bool isMove;
    
    void Update()
    {
        if (stk.Count < max && isMove == false) // isMove�� �̵����� ��, �� �����Ҷ��� ���ÿ� ���� �����ֱ� ������ �װ��� �����ִ� �뵵
        {            
            stk.Push(transform.position);            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(stk.Count > 0)
            {
                StartCoroutine(moveCo());
            }            
        }
        
    }

    IEnumerator moveCo()
    {
        isMove = true;
        while (stk.Count > 0)
        {
            yield return null;
            transform.position = stk.Pop();
        }
        stk.Clear();
        isMove = false; 
    }

    //bool isCool;
    //IEnumerator CoolTimeCo()
    //{
    //    while (true)
    //    {
    //        if (isCool)
    //        {
    //            yield return new WaitForSeconds(3);
    //            isCool = false;
    //        }
    //        yield return null;
    //    }
    //}
    
}
