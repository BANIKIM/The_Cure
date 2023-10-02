using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float MoveSpeed=0;
    public Vector2 inputVec;

    Rigidbody2D rigid;//캐릭터 움직임을 위해서 선언
    SpriteRenderer spriter; //좌우 변경모션을 만들기 위해서 선언
    Animator anim; //애니메에션 값을 변경을 하기 위해
    

     void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        //GetAxis - 미끄러짐 / GetAxisRaw - 미끄러지지 않음
        inputVec.x = Input.GetAxisRaw("Horizontal"); //좌우
        inputVec.y = Input.GetAxisRaw("Vertical"); // 상하
    }

     void FixedUpdate()
    {
        //힘을 준다. 얼음판위에 돌을 밀듯이 밀린다.
        //rigid.AddForce(inputVec);
        //속도제어 일반 이동처럼 구현이됨
        //rigid.velocity = inputVec;
        //위치 이동  - 수업시간에서 많이 사용한 위치 이동 속도가 너무 빠르고..
        Vector2 Moveto = inputVec.normalized * MoveSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position+ Moveto);
    }


     void LateUpdate()
    {
        
        anim.SetFloat("Speed", inputVec.magnitude); //magnitude 순수하게 크기만 가지고 있는 값
        //SetFloat Float의 값을 변경할 수 있음 앞의 ""은 애니메이터에 선언된 이름을 적고 , 뒤의 값은 넣을값을 대입하면됨

        if (inputVec.x != 0)//이동키가 입력이 되면
        {
            spriter.flipX = inputVec.x < 0; //비교연산자의 결과를 바로 넣을 수 있음 크면 true가 되고 작으면 false가 된다.
        }
    }
}
