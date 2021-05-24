using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePhyBird : Bird
{ 
     //이거 아까 유니티 끄,ㅡㄹ때 저거
     //   새로만든 새 다시 만든건데
     //   저장안되어있어서
     //   다시
     //   만들었어요
   new private void Start()
    { 
        base.Start();
        // 인스펙터에서 했으면 이거 안적어도 됨
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        rigidbody2D.useFullKinematicContacts = true;
    }

    public float gravity = -9.8f;
    public float acceleration;

    void Update()
    {
        // 중력에 의한 낙하 구현
        acceleration += gravity * Time.deltaTime; // acceleration = acceleration + (gravity * Time.deltaTime)



        // y값 변경.
        transform.Translate(0, acceleration, 0);


        // 터치 했을때 위로 날아오르는 힘 주기
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (Time.time>0.7f)
            {
                acceleration = forceY;
                // 날개 펄럭 애니메이션
                animator.Play("Flap", 0, 0);
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDie(collision);

        // 물리를 다시 살리자
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        enabled = false; // Update 함수를 비활성 시키자
        GameManager.instace.scrollSpeedXMultiply = 0;
    }
}
