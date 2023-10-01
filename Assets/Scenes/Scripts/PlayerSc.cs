using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWalkable
{
    void Walk();    
}

public class PlayerSc : MonoBehaviour, IWalkable, IHitable
{
    [SerializeField] float moveSpeed;

    [SerializeField] int hp;
    public int Hp { get => hp; set => hp = value; }

    private void Start()
    {
        Hp = 100;
        moveSpeed = 2f;
    }

    public void Walk()
    {
        Debug.Log("µÎ¹÷µÎ¹÷");    
    }

    private void Update()
    {
        Vector3 vec = Vector3.zero;
        if(Input.GetKey(KeyCode.A))
        {
            vec += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vec += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vec += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vec += Vector3.back;
        }

        transform.Translate(vec.normalized * moveSpeed * Time.deltaTime, Space.World);
    }

    public void Hit(IAttackable attackable)
    {
        Debug.Log("Ã¼·Â°¨¼Ò");
        Hp -= attackable.Atk;
    }
}
