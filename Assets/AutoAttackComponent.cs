using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    int Atk { get; }   
    void Attack(IHitable hitable);
}

public interface IHitable
{
    int Hp { get; set; }
    void Hit(IAttackable attackable);
}

public class AutoAttackComponent : MonoBehaviour, IAttackable
{
    /*
   몬스터나 타워가 탐지컴포넌트를 통해 적을 탐지하면(탐지컴포넌트가 가지고 있는 타겟)
   자동공격 컴포넌트에서 탐지한 타겟을 공격     

   컴포넌트로 만드는 이유 : 
   몬스터나 타워, 기타 장애물들은 자신의 타겟레이어를 가직 객체가 탐지되면 자동으로 공격
   따라서 위의 모든 스크립트에 그 기능을 작성하지 않고 하나의 컴포넌트로 나누어서 구현     
    */

    [SerializeField] int atk;
    public int Atk => atk;
    bool isAttack = true;
    public void Attack(IHitable hitable)
    {
        hitable.Hit(this);
    }    
    
    public void AttackTarget(Collider targetCol)
    {
        // 적은 플레이어가 타겟이고, 타워는 적이 타겟이면? 즉 각자의 타겟이 서로다를텐데 어떻게 대미지를 주나? 인터페이스로
        if(targetCol.gameObject.TryGetComponent(out IHitable hitable) && isAttack)
        {
            Attack(hitable);
            StartCoroutine(CoolTimeCo());
        }
    }     

    IEnumerator CoolTimeCo()
    {
        isAttack = false;
        yield return new WaitForSeconds(2);
        isAttack = true;
    }
}
