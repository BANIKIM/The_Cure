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
        //GetAxis - 미끄러짐 / GetAxisRaw - 미끄러지지 않음
        inputVec.x = Input.GetAxisRaw("Horizontal"); //좌우
        inputVec.y = Input.GetAxisRaw("Vertical"); // 상하
    }

    private void FixedUpdate()
    {
        //힘을 준다. 얼음판위에 돌을 밀듯이 밀린다.
        //rigid.AddForce(inputVec);
        //속도제어 일반 이동처럼 구현이됨
        //rigid.velocity = inputVec;
        //위치 이동  - 수업시간에서 많이 사용한 위치 이동 속도가 너무 빠르고..
        Vector2 Moveto = inputVec.normalized * MoveSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position+ Moveto);
    }
}
