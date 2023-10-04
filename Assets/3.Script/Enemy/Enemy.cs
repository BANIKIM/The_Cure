using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; // 속도 설정
    public float Hp;
    public float MaxHp;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target; // 목표 설정
    bool isLive; // 살아 있는지 확인

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;

     void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position; // 위치 차이 = 타겟 위치 - 나의 위치
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime; //방향 = 위치 차이의 정규화(normalized)
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }


     void LateUpdate()
    {
        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x; // 적의 좌우 바라보는 방향을 변경하는 코드
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        Hp = MaxHp;
    }


    public void Init(SpawData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        MaxHp = data.Hp;
        Hp = data.Hp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;


        Hp -= collision.GetComponent<Bullet>().damage;

        if(Hp >0)
        {
            // hit
        }
        else
        {
            //죽음
            Dead();
        }
 
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
