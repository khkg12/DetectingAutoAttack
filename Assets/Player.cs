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
    public LayerMask layerMask; // �̷��� ���������صθ� 1<<LayerMask.NameToLayer("Ground")�� �׳� �̰ŷ� ��ü ����, ���� �ν����Ϳ��� ���� �����ص�

    public int Atk => atk;

    void Start()
    {
        rb = GetComponent<Rigidbody>();        
         
        int layermaskOne = 0b1001; // 0b�� �������� ǥ���Ѵٴ� �ǹ�
        int layermaskTwo = 0b0011;
        int resultLayermask = layermaskOne | layermaskTwo;
        // ��� : 1011

        layermaskOne = ~layermaskOne; // ~�� �ݴ�� 0�� 1��, 1�� 0���� 
                
        atk = 5;

        Physics.OverlapSphere(transform.position, 5);
    }

    public void Jump()
    {
        if (isJumpable)
        {
            rb.AddRelativeForce(transform.up * 10, ForceMode.Impulse); // ������ǥ��
        }            
    }
    
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            // �츮�� �����ϱ� ����ϴ� Ground ���̾�� 7��, �� 1������ 7�� �������� �о���Ѵ�. 1<<7, �Ʒ��� �����ǥ�� Ground��� �̸��� ���̾ ������, �� 7�� ������
            isGround = Physics.Raycast(transform.position, -transform.up, out hit, maxDistance, 1 << LayerMask.NameToLayer("Ground")); // ���̾��ũ�� ���� int int�� 4����Ʈ = 32��Ʈ �� 7���̾�� 1000000, 1<<1 �� 1�� �������� ��ĭ �о��        
            isJumpable = isGround;
            Jump();
        }
        
        if (Input.GetKeyDown(KeyCode.V)) 
        {
            RaycastHit monsterHit;
            isHit = Physics.Raycast(transform.position, transform.forward, out monsterHit, maxDistance); // out�� ref�� �������� Ŭ������ �̹� ����Ÿ���̶� ref�� out�� ���ʿ䰡 ����, ���� out�� ��Ÿ�Կ����� ������
            Debug.DrawLine(transform.position, transform.position + transform.forward * maxDistance, Color.red);
            if (isHit && monsterHit.rigidbody.gameObject.TryGetComponent(out IHitable hitable)) // �ε��� ���� �����ϸ�, �׳��� Monster�� �����
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
