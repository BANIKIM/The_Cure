using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float MoveSpeed=0;
    public Vector2 inputVec;

    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        //GetAxis - �̲����� / GetAxisRaw - �̲������� ����
        inputVec.x = Input.GetAxisRaw("Horizontal"); //�¿�
        inputVec.y = Input.GetAxisRaw("Vertical"); // ����
    }

    private void FixedUpdate()
    {
        //���� �ش�. ���������� ���� �е��� �и���.
        //rigid.AddForce(inputVec);
        //�ӵ����� �Ϲ� �̵�ó�� �����̵�
        //rigid.velocity = inputVec;
        //��ġ �̵�  - �����ð����� ���� ����� ��ġ �̵� �ӵ��� �ʹ� ������..
        Vector2 Moveto = inputVec.normalized * MoveSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position+ Moveto);
    }
}
