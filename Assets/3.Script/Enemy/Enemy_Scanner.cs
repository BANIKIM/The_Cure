using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Scanner : MonoBehaviour
{
    public float scanRange; // ����
    public LayerMask targetLayer; //���̾�
    public RaycastHit2D[] targets; // Ÿ��
    public Transform nearestTarget; // ���� ����� Ÿ��ã��


    void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer); //CircleCastAll ������ ĳ��Ʈ�� ��� ��� ����� ��ȯ��
        nearestTarget = GetNearest();                                                                                        //ĳ���� ������ġ ,  ���� ������,  ĳ���� ���� , ĳ���� ����, ��� ���̾�
    }

    Transform GetNearest() //���� �������� ã�� �Լ� 
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
