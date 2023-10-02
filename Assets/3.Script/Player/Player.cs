using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float MoveSpeed=0;
    public Vector2 inputVec;

    Rigidbody2D rigid;//ĳ���� �������� ���ؼ� ����
    SpriteRenderer spriter; //�¿� �������� ����� ���ؼ� ����
    Animator anim; //�ִϸ޿��� ���� ������ �ϱ� ����
    

     void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        //GetAxis - �̲����� / GetAxisRaw - �̲������� ����
        inputVec.x = Input.GetAxisRaw("Horizontal"); //�¿�
        inputVec.y = Input.GetAxisRaw("Vertical"); // ����
    }

     void FixedUpdate()
    {
        //���� �ش�. ���������� ���� �е��� �и���.
        //rigid.AddForce(inputVec);
        //�ӵ����� �Ϲ� �̵�ó�� �����̵�
        //rigid.velocity = inputVec;
        //��ġ �̵�  - �����ð����� ���� ����� ��ġ �̵� �ӵ��� �ʹ� ������..
        Vector2 Moveto = inputVec.normalized * MoveSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position+ Moveto);
    }


     void LateUpdate()
    {
        
        anim.SetFloat("Speed", inputVec.magnitude); //magnitude �����ϰ� ũ�⸸ ������ �ִ� ��
        //SetFloat Float�� ���� ������ �� ���� ���� ""�� �ִϸ����Ϳ� ����� �̸��� ���� , ���� ���� �������� �����ϸ��

        if (inputVec.x != 0)//�̵�Ű�� �Է��� �Ǹ�
        {
            spriter.flipX = inputVec.x < 0; //�񱳿������� ����� �ٷ� ���� �� ���� ũ�� true�� �ǰ� ������ false�� �ȴ�.
        }
    }
}
