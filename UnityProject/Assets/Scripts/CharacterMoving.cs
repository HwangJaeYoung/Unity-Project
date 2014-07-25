using UnityEngine;
using System.Collections;
[RequireComponent (typeof(CharacterController))]

public class CharacterMoving : MonoBehaviour
{
    public float speed = 3.0F; // 이동속도
    public float jumpSpeed = 8.0F; // 점프속도
    public float gravity = 20.0F; // 중력
    private float idleTimeCheck = 0f; // idle의 시간체크
    private Vector3 moveDirection = Vector3.zero; // 방향벡터
    private bool jumpCheck = false; // 점프의 상태체크
    private bool runCheck = false; // 뛰기의 상태체크

    void Start()
    {
        idleTimeCheck = Time.time; // idle을 실행하기 위한 시작시간 할당
    }
    
    // 여기서 true, false가 많이쓰이는데 유니티에서는 수치로 정교하게 제어하기에는 어려움이 많다.
    void Update()
    {
        if (SkillExecute.magicAuraCheck != true && SkillExecute.fireRainCheck != true) // 힐 스킬이 끝나기 전까지 움직이지 않게 한다 false를 줌으로 인해서
        {
            CharacterController controller = GetComponent<CharacterController>();

            if (idleTimeCheck > 3.0f) // 3초가 넘으면 
            {
                animation.Play("idle"); // idle 애니메이션 실행
                idleTimeCheck = 0f; // 실행을 했으므로 0으로 초기화
            }

            else // 3초가 지나지 않았으므로
                idleTimeCheck += Time.deltaTime; // 시간을 계속 더한다.

            if (controller.isGrounded && SkillExecute.magicAuraCheck == false) // isGrounded가 지면(terrain)에 붙어있는지 아닌지를 판단해준다.
            {
                if (Input.GetKey("w")) // w는 여기서 앞으로 전진하는 키이다.
                {
                    moveDirection = new Vector3(0, 0, 1); // 로컬좌표계의 이동방향
                    runCheck = true; // 뛸거니까 true를 준다.
                }
                else
                    moveDirection = new Vector3(0, 0, 0); // 뛰지 않으므로 방향이 필요가 없다.
        
                moveDirection = transform.TransformDirection(moveDirection); // 로컬좌표계를 월드좌표계로 바꿔준다.
                moveDirection *= speed; // 속도를 준다.

                if (Input.GetKeyDown("space")) // 여기서 space키는 점프하는 키이다.
                {
                    idleTimeCheck = 0f; // 점프를 했으니까 idle은 다시 0으로 초기화
                    jumpCheck = true; // 점프를 했다.
                    moveDirection.y = jumpSpeed; // 점프의 속도를 부여  
                }
                // 스킬시전시에 무빙을 여기서 하는게 나을것 같다.
            }

            if (jumpCheck == true)
            {
                animation.Play("jump");
                StartCoroutine("timer"); // jumpCheck를 위한 코루틴 호출

            }
            else if (jumpCheck == false && runCheck == true)
            {
                idleTimeCheck = 0f; // 뛰는 행동을 했으니까 idle은 0이 되야한다.
                runCheck = false;
                animation.CrossFade("run");
            }
            moveDirection.y -= gravity * Time.deltaTime;
            /* 중력을 적용한다. 여기서 moveDirection.y는 계속 깍이는게 맞으나 충돌체끼리의 충돌로 인해
            CharacterController.Move( )가 뮤트를 이동시키지 않으므로 포지션의 위치 변화가 생기지 않는다. */

            controller.Move(moveDirection * Time.deltaTime); // 캐릭터를 이동시킨다. 이때는 충돌체크도 같이 할 수 있다.
        }
    }

    IEnumerator timer() // false를 늦게 주기위해 만든 타이머
    {
        yield return new WaitForSeconds(1f); // 1.5초 후에
        jumpCheck = false; // false값을 주게 되는데 이렇게 하지않으면 바로 false로 바껴서 jump애니메이션이 끝나기도 전에 run애니메이션이 실행된다.
    }
}