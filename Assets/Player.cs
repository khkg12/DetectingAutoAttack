using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IAttackable
{
    [SerializeField] private float maxDistance;    
    Rigidbody rb;
    int atk;
    

    public bool isGround;
    public bool isHit;
    public bool isJumpable;
    public LayerMask layerMask; // 이렇게 변수지정해두면 1<<LayerMask.NameToLayer("Ground")를 그냥 이거로 대체 가능, 물론 인스펙터에서 값을 정해준뒤

    public int Atk => atk;

    void Start()
    {
        rb = GetComponent<Rigidbody>();        
         
        int layermaskOne = 0b1001; // 0b는 이진수로 표현한다는 의미
        int layermaskTwo = 0b0011;
        int resultLayermask = layermaskOne | layermaskTwo;
        // 결과 : 1011

        layermaskOne = ~layermaskOne; // ~는 반대로 0은 1로, 1은 0으로 
                
        atk = 5;

        Physics.OverlapSphere(transform.position, 5);
    }

    public void Jump()
    {
        if (isJumpable)
        {
            rb.AddRelativeForce(transform.up * 10, ForceMode.Impulse); // 로컬좌표로
        }            
    }
    
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            // 우리가 검출하길 희망하는 Ground 레이어는 7번, 즉 1번에서 7번 왼쪽으로 밀어야한다. 1<<7, 아래는 명시적표현 Ground라는 이름의 레이어를 가져옴, 즉 7을 가져옴
            isGround = Physics.Raycast(transform.position, -transform.up, out hit, maxDistance, 1 << LayerMask.NameToLayer("Ground")); // 레이어마스크의 값은 int int는 4바이트 = 32비트 즉 7레이어면 1000000, 1<<1 은 1을 왼쪽으로 한칸 밀어라        
            isJumpable = isGround;
            Jump();
        }
        
        if (Input.GetKeyDown(KeyCode.V)) 
        {
            RaycastHit monsterHit;
            isHit = Physics.Raycast(transform.position, transform.forward, out monsterHit, maxDistance); // out은 ref의 사촌으로 클래스는 이미 참조타입이라 ref나 out을 쓸필요가 없음, 따라서 out은 값타입에서만 보통사용
            Debug.DrawLine(transform.position, transform.position + transform.forward * maxDistance, Color.red);
            if (isHit && monsterHit.rigidbody.gameObject.TryGetComponent(out IHitable hitable)) // 부딪힌 놈이 존재하며, 그놈이 Monster일 경우라면
            {
                Attack(hitable);
            }                        
        }                
    }

    public void Attack(IHitable hitable)
    {
        hitable.Hit(this);
    }
}
