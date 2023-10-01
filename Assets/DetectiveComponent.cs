using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveComponent : MonoBehaviour
{
    [SerializeField] LayerMask targetLayerMask;    
    [SerializeField] float radius;
    [SerializeField] float maxDistance;
    [SerializeField] bool isRangeDetection;
    [SerializeField] bool isRayDetection;
    public Collider targetCol;

    public Vector3 LastDetectivePos // �б����� ������Ƽ(�ڵ����� ������Ƽ) ������ �̾ȿ�����
    {
        get;
        private set;
    }

    public bool IsDection
    {
        get
        {
            return isRayDetection && isRangeDetection;
        }
    }

    bool CheckInLayerMask(int index)
    {
        return ((targetLayerMask & (1 << index)) != 0);
    }   

    void Update()
    {        
        Collider[] cols = Physics.OverlapSphere(transform.position, radius, targetLayerMask); // ex) ����ź�� �Ͷ߷��� �� �� ����, OnCollison���� ����
        isRangeDetection = (cols.Length > 0);

        if (isRangeDetection) // ����Ǿ���.
        {
            RaycastHit hit;
            Vector3 direction = ((cols[0].transform.position) - (transform.position)).normalized; // �Ÿ��� �����ϰ� ���⸸ ����� normalized     
            Debug.DrawLine(transform.position, transform.position + direction * maxDistance, Color.blue);            

            if (Physics.Raycast(transform.position, direction, out hit, maxDistance, targetLayerMask)) 
            {                
                isRayDetection = CheckInLayerMask(hit.collider.gameObject.layer);  // �� Ÿ�ٷ��̾ �浹�� ���� ���̾ ������ �� ��������(�÷��̾��϶���)
                if (isRayDetection)
                {
                    LastDetectivePos = hit.transform.position;
                    targetCol = cols[0];
                    Debug.DrawLine(transform.position, transform.position + direction * maxDistance, Color.red);
                }
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;        
        Gizmos.DrawWireSphere(transform.position, radius);        
    }
}
