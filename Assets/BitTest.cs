using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags] // 어트리뷰트
public enum BIT_FLAG
{
    NONE = 0,   
    FLAG1 = 1<<1,
    FLAG2 = 1<<2,
    FLAG3 = 1<<4,
    FLAG4 = 1<<8,
    CUSTOMFLAGS = FLAG3|FLAG4|FLAG2,
}

public class BitTest : MonoBehaviour
{
    public BIT_FLAG flags =  BIT_FLAG.NONE;

    private void Start()
    {
        flags |= BIT_FLAG.FLAG1;
        flags |= BIT_FLAG.FLAG4;

        flags &= ~BIT_FLAG.FLAG1;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            // flags에 FLAG1을 켜준다.
            flags |= BIT_FLAG.FLAG1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            // flags에 FLAG4을 켜준다.
            flags |= BIT_FLAG.FLAG4;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // flags에 FLAG3을 토글(꺼져있으면 켜고, 켜져있으면 끈다)
            flags ^= BIT_FLAG.CUSTOMFLAGS;
        }        

        switch (flags)
        {
            case BIT_FLAG.FLAG1:
                break;
            case BIT_FLAG.FLAG2:
                break;
            case BIT_FLAG.FLAG3:
                break;
            case BIT_FLAG.FLAG4:
                break;
        }        
    }
}
