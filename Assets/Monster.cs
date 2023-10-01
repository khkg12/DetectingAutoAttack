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
            if(hp > value) // 현재 hp보다 지금 들어온 value가 작아졌다는 것이니까 대미지를 입었다, 즉 hp가 감소했다. 아래에서 대미지를 입었을때의 처리를 해줄수도 있을 것
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

    void Start() // 안쓰는 경우 지워줘야함. 빈것이여도 가져와서 호출하기 때문에 자원낭비이므로 아무것도 없을 때 지워줘야함
    {
        rb = GetComponent<Rigidbody>();
        hp = 10;
        maxHp = 10;
        atkRange = 5;
    }

    private void Update()
    {
        if (detectiveComponent.IsDection) // 적이 감지되었고
        {            
            Vector3 targetPos = (detectiveComponent.LastDetectivePos - transform.position).normalized;
            transform.forward = targetPos;
            rb.velocity = targetPos;            
            if (Vector3.Distance(transform.position, detectiveComponent.LastDetectivePos) <= atkRange) // 타겟위치와 거리가 가까워지면
            {
                Debug.Log("공격하라");
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
