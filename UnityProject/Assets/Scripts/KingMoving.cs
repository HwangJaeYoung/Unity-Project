using UnityEngine;
using System.Collections;

public class KingMoving : MonoBehaviour
{
    private CharacterController sparta; // 스파르타킹의 CharacterController를 가져와서 .Move( )를 사용한다.
    public GameObject Target; // 타겟은 게임오브젝트인 뮤트가 된다.
    public GameObject wayPoint0; // 웨이포인트0
    public GameObject wayPoint1; // 웨이포인트1
    public UISprite healthBar; // ProgressBar의 프론트인 초록색 부분
    private KingHealth king; // die변수를 위해서 KingHealth를 이용한다.
    private float attackTime; // 공격시간의 계산
    private float maxTime = 1.7f; // 공격의 주기의 최댓값
    private bool attackCheck = false; // 연속적은 공격의 방지를 위해 선언한 변수
    private bool skillTargeting = false; // 스파르타킹이 스킬에 맞았을 경우에 true로 변경된다.
	public float MoveSpeed = 1f; // 이동속도
	public float RotationSpeed = 2.0f; // 회전속도
	bool isWayPoint = false; // 전환점을 찾는다.
	bool isSearch = true; // 플레이어의 발견여부

    void Start()
    {
        sparta = GetComponent<CharacterController>(); // 컴포넌트를 스파르타킹으로 부터 받아온다.
        king = gameObject.GetComponent<KingHealth>(); // KingHealth에서 die변수 값을 참조하기 위해 KingHealth를 받는다.
    }
    

    void Update()
    {
        if (skillTargeting == false) // 스파르타킹이 스킬에 맞지 않았을 경우
        {
            if (isSearch == true) // 플레이어가 사정거리 안에 들어오지 않았을 경우
            {
                if (king.die == false) // 스파르타킹이 죽지 않았을 경우
                {
                    animation.Play("walk");
                    WayPointMove();
                }
            }
            else // 뮤트가 사정거리안에 들어왔다면
            {
                if (king.die == false)
                {
                    attackRun(); // 공격을 하기위해 방향을 잡고 거리를 좁힌다

                    // 최대시간에 따른 공격
                    attackTime -= Time.deltaTime; // 프레임이 아닌 초단위로 뺸다 컴퓨터마다 fps가 다르므르...
                    if (attackCheck == true && attackTime <= 0)
                    {
                        attackTime = maxTime; // 최대시간의 초기화
                        Attack(); // 공격!!
                    }
                }
            }
        }

        else // 스파르타킹이 스킬에 맞았을 경우
        {
            SkillAttack();
        }
    }

    void WayPointMove() // Waypoint에 따라 캐릭터를 이동시키기 위한 메소드
    {
        Vector3 direction = transform.TransformDirection(new Vector3(0, 0, 1)); // 로컬좌표계에서 월드좌표계로 방향을 바꾼다.
       
        if (sparta.isGrounded) // CharacterController가 지표면에 붙어있으면
        {
            if (isWayPoint == false)
            {
                // 스파르타킹을 웨이포인트 쪽으로 회전을 시키는 것이며 회전만 시키지 이동은 .Move( )쪽에서 시행한다.
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(wayPoint0.transform.position - transform.position), 1);
                direction.y -= 20 * Time.deltaTime; // 캐릭터컨트롤러는 중력이 있어야 내려간다.
                sparta.Move(direction * Time.smoothDeltaTime * MoveSpeed);

                if (Vector3.Distance(transform.position, wayPoint0.transform.position) <= 0.5f) // 웨이포인트에 0.5이하로 가까워졌을 경우엔
                {
                    isWayPoint = true;
                }
            }

            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(wayPoint1.transform.position - transform.position), Time.smoothDeltaTime * RotationSpeed);
                direction.y -= 20 * Time.deltaTime;
                sparta.Move(direction * Time.smoothDeltaTime * MoveSpeed);

                if (Vector3.Distance(transform.position, wayPoint1.transform.position) <= 0.5f)
                {
                    isWayPoint = false;
                }
            }
            Search(); // 뮤트를 발견 했으면(뮤트가 사정거리안에 들어오게 되면은)
        }

        else // CharacterController가 지표면에 붙어있지 않으면
        {
            direction.y -= 20 * Time.deltaTime; // 중력을 주어서 캐릭터는 내려가게 한다.
            sparta.Move(direction * Time.smoothDeltaTime * MoveSpeed); // 캐릭터의 이동
        }
    }

    void Search() // 플레이어(뮤트)의 위치를 파악하는데 사용되는 메소드
    {
        float distance = Vector3.Distance(Target.transform.position, transform.position);
        
        if (distance < 5) 
        {
            isSearch = false;
        }
    }
    
    void Attack() // 공격하는 행동을 취하게 하는 메소드
    {
        animation.Play("attack");
        attackCheck = false; // 이 부분을 선언하지 않으면 계속적으로 공격을 하게 된다.
        if(PlayerWin.playerWin != true)
            MuteHealth.playerHealth -= 10.0f; // 한 번 공격당 플레이어 체력을 10씩 깍는다
        healthBar.fillAmount = MuteHealth.playerHealth * 0.01f; // ProgressBar의 체력을 표시하는 방법
    }

    void attackRun() // 스킬에 맞은것이 아니라 플레이어가 지나가다가 자신의 행동반경안에 들어왔을 때의 정의
    {
        Vector3 direction = transform.TransformDirection(new Vector3(0, 0, 1)); // 로컬좌표계에서 월드좌표계로 방향을 바꾼다

        float distance = Vector3.Distance(Target.transform.position, transform.position);

        if (distance > 5) // 플레이어(뮤트)가 스파르타킹의 공격범위 내에서 밖으로 나가버렸을 때
        {
            isSearch = true;
        }

        if (distance < 1) // 플레이어(뮤트)가 스파르타킹의 공격범위내에 있을 떄
        {
            attackCheck = true; // 공격을 할 수 있도록 허용을 해주는 부분
            // 0.5 빼준거는 공격방향을 수정하려고 빼준 것 지우면 위로 공격함
            Vector3 reDirect = new Vector3(Target.transform.position.x, Target.transform.position.y - 0.5f, Target.transform.position.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(reDirect - transform.position), Time.smoothDeltaTime * RotationSpeed);   
        }

        else // 5이하 1이상의 범위에서의 행동정의 메소드
        {
            animation.Play("run");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), Time.smoothDeltaTime * RotationSpeed);
            direction.y -= 20 * Time.deltaTime;
            sparta.Move(direction * Time.smoothDeltaTime * 2f);
        }
    }

    void SkillAttack() // 스파르타킹이 스킬에 맞았을때의 행동 정의 메소드(스킬에 맞았을 경우에 플레이어를 쫓아옴)
    {
        skillTargeting = true; // 스킬에 맞았다는걸 알려준다. 이 값에 따라 호출 메소드가 약간 달라지게 된다.

        Vector3 direction = transform.TransformDirection(new Vector3(0, 0, 1)); // 로컬좌표계에서 월드좌표계로 방향을 바꾼다
        float distance = Vector3.Distance(Target.transform.position, transform.position);

        if (distance > 4.7f) 
        {
            animation.Play("run");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), Time.smoothDeltaTime * RotationSpeed);
            direction.y -= 20 * Time.deltaTime;
            sparta.Move(direction * Time.smoothDeltaTime * 2f);
        }

        /* 스킬에 맞게 되고 그에 따른 행동을 정의 한 것인데 4.7이상의 거리이면 계속해서 스파르타킹이 플레이어(뮤트)를 추적하게하고
           그 이하로 떨어지면 SkillAttack( )메소드를 떠나서 제어를 WayPointMove( )메소드로 주기위해서 false를 주어서 더이상
           SkillAttack( )메소드가 호출되지 않게 함으로써 코드의 양을 줄였다. */
        else
            skillTargeting = false;
    }
}