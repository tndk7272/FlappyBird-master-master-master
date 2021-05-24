using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    new public Rigidbody2D rigidbody2D;
    public Animator animator;
    public float forceY = 300;

    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // 새가 충돌 한당
        animator = GetComponent<Animator>(); // 애니메이션 넣었따
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 클릭 또는 스페이스바 눌렀을 떄
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            Vector2 force;
            force.x = 0;
            force.y = forceY;
            rigidbody2D.AddForce(force);

            // 날개 펄럭 애니메이션
            animator.Play("Flap", 0, 0);
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDie(collision);
    }
    protected void OnDie(Collision2D collision)
    {
        Debug.LogWarning(collision);
        // 새 죽음
        // 죽는 애니메이션


        // 게임 오버 UI 표시
        GameManager.instace.SetGameOver();

        // 죽는 애니메이션
        animator.Play("Die", 0, 0);

        // 스크롤 하는것들 다 멈추기
        GameManager.instace.scrollSpeedXMultiply = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instace.AddScore();
    }
}
