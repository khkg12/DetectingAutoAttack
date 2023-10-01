using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Monster : MonoBehaviour, IHitable
{
    public DetectiveComponent detectiveComponent;
    public AutoAttackComponent autoAttackComponent;
    Rigidbody rb;
    public int Hp
    { 
        get => hp;
        set
        {
            hp = value;
            if(hp > value) // ���� hp���� ���� ���� value�� �۾����ٴ� ���̴ϱ� ������� �Ծ���, �� hp�� �����ߴ�. �Ʒ����� ������� �Ծ������� ó���� ���ټ��� ���� ��
            {

            }
            if(hp > maxHp)
            {
                hp = maxHp;
            }
            if (hp <= 0)
            {
                Die();
            }                    
        }
    }
    protected int hp;
    float atkRange;
    
    int maxHp;

    void Start() // �Ⱦ��� ��� ���������. ����̿��� �����ͼ� ȣ���ϱ� ������ �ڿ������̹Ƿ� �ƹ��͵� ���� �� ���������
    {
        rb = GetComponent<Rigidbody>();
        hp = 10;
        maxHp = 10;
        atkRange = 5;
    }

    private void Update()
    {
        if (detectiveComponent.IsDection) // ���� �����Ǿ���
        {            
            Vector3 targetPos = (detectiveComponent.LastDetectivePos - transform.position).normalized;
            transform.forward = targetPos;
            rb.velocity = targetPos;            
            if (Vector3.Distance(transform.position, detectiveComponent.LastDetectivePos) <= atkRange) // Ÿ����ġ�� �Ÿ��� ���������
            {
                Debug.Log("�����϶�");
                autoAttackComponent.AttackTarget(detectiveComponent.targetCol);
            }
        }
    }
   
    public void Die()
    {
        Destroy(gameObject);    
    }
    
    public void Hit(IAttackable attackable)
    {
        Hp -= attackable.Atk;
    }
}
