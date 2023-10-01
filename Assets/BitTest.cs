using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags] // ��Ʈ����Ʈ
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
            // flags�� FLAG1�� ���ش�.
            flags |= BIT_FLAG.FLAG1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            // flags�� FLAG4�� ���ش�.
            flags |= BIT_FLAG.FLAG4;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // flags�� FLAG3�� ���(���������� �Ѱ�, ���������� ����)
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
