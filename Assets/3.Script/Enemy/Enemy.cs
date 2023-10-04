using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; // �ӵ� ����
    public float Hp;
    public float MaxHp;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target; // ��ǥ ����
    bool isLive; // ��� �ִ��� Ȯ��

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

        Vector2 dirVec = target.position - rigid.position; // ��ġ ���� = Ÿ�� ��ġ - ���� ��ġ
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime; //���� = ��ġ ������ ����ȭ(normalized)
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }


     void LateUpdate()
    {
        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x; // ���� �¿� �ٶ󺸴� ������ �����ϴ� �ڵ�
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
            //����
            Dead();
        }
 
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
