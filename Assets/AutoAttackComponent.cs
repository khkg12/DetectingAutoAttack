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
   ���ͳ� Ÿ���� Ž��������Ʈ�� ���� ���� Ž���ϸ�(Ž��������Ʈ�� ������ �ִ� Ÿ��)
   �ڵ����� ������Ʈ���� Ž���� Ÿ���� ����     

   ������Ʈ�� ����� ���� : 
   ���ͳ� Ÿ��, ��Ÿ ��ֹ����� �ڽ��� Ÿ�ٷ��̾ ���� ��ü�� Ž���Ǹ� �ڵ����� ����
   ���� ���� ��� ��ũ��Ʈ�� �� ����� �ۼ����� �ʰ� �ϳ��� ������Ʈ�� ����� ����     
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
        // ���� �÷��̾ Ÿ���̰�, Ÿ���� ���� Ÿ���̸�? �� ������ Ÿ���� ���δٸ��ٵ� ��� ������� �ֳ�? �������̽���
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
