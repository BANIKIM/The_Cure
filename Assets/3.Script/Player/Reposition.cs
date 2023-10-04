using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>(); 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;
        

        Vector3 playerPos = GameManager.instance.player.transform.position; //플레이어 위치저장
        Vector3 myPos = transform.position;//내 포지션 저장

        float diffx =Mathf.Abs(playerPos.x - myPos.x);//Mathf.Abs 음수값이 아닌 양수값만 받음 
        float diffy = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;


        switch (transform.tag)
        {
            case "Ground":
                if(diffx > diffy)
                {
                    transform.Translate(Vector3.right* dirX * 40);
                }
                else if (diffx < diffy)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }

                break;
            case "Enemy":
                if(coll.enabled)//콜라이더가 활성화 되어있는지 확인 enabled
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f,3f), Random.Range(-3f, 3f),0));
                }
                    break;
        }

    }
}
