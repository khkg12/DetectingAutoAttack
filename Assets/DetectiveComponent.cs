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

    public Vector3 LastDetectivePos // 읽기전용 프로퍼티(자동구현 프로퍼티) 세팅은 이안에서만
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
        Collider[] cols = Physics.OverlapSphere(transform.position, radius, targetLayerMask); // ex) 수류탄을 터뜨렸을 때 딱 실행, OnCollison과의 차이
        isRangeDetection = (cols.Length > 0);

        if (isRangeDetection) // 검출되었다.
        {
            RaycastHit hit;
            Vector3 direction = ((cols[0].transform.position) - (transform.position)).normalized; // 거리는 제외하고 방향만 남기게 normalized     
            Debug.DrawLine(transform.position, transform.position + direction * maxDistance, Color.blue);            

            if (Physics.Raycast(transform.position, direction, out hit, maxDistance, targetLayerMask)) 
            {                
                isRayDetection = CheckInLayerMask(hit.collider.gameObject.layer);  // 내 타겟레이어를 충돌된 놈의 레이어를 비교했을 때 있을때만(플레이어일때만)
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
