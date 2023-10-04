using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Scanner : MonoBehaviour
{
    public float scanRange; // 범위
    public LayerMask targetLayer; //레이어
    public RaycastHit2D[] targets; // 타겟
    public Transform nearestTarget; // 가장 가까운 타겟찾기


    void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer); //CircleCastAll 원형의 캐스트를 쏘고 모든 결과를 반환함
        nearestTarget = GetNearest();                                                                                        //캐스팅 시작위치 ,  원의 반지름,  캐스팅 방향 , 캐스팅 길이, 대상 레이어
    }

    Transform GetNearest() //가장 가까운것을 찾는 함수 
    {
        Transform result = null;
        float diff = 100;

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if (curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }


        return result;
    }
}
