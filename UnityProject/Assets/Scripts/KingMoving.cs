using UnityEngine;
using System.Collections;

public class KingMoving : MonoBehaviour
{
    private CharacterController sparta; // ���ĸ�Ÿŷ�� CharacterController�� �����ͼ� .Move( )�� ����Ѵ�.
    public GameObject Target; // Ÿ���� ���ӿ�����Ʈ�� ��Ʈ�� �ȴ�.
    public GameObject wayPoint0; // ��������Ʈ0
    public GameObject wayPoint1; // ��������Ʈ1
    public UISprite healthBar; // ProgressBar�� ����Ʈ�� �ʷϻ� �κ�
    private KingHealth king; // die������ ���ؼ� KingHealth�� �̿��Ѵ�.
    private float attackTime; // ���ݽð��� ���
    private float maxTime = 1.7f; // ������ �ֱ��� �ִ�
    private bool attackCheck = false; // �������� ������ ������ ���� ������ ����
    private bool skillTargeting = false; // ���ĸ�Ÿŷ�� ��ų�� �¾��� ��쿡 true�� ����ȴ�.
	public float MoveSpeed = 1f; // �̵��ӵ�
	public float RotationSpeed = 2.0f; // ȸ���ӵ�
	bool isWayPoint = false; // ��ȯ���� ã�´�.
	bool isSearch = true; // �÷��̾��� �߰߿���

    void Start()
    {
        sparta = GetComponent<CharacterController>(); // ������Ʈ�� ���ĸ�Ÿŷ���� ���� �޾ƿ´�.
        king = gameObject.GetComponent<KingHealth>(); // KingHealth���� die���� ���� �����ϱ� ���� KingHealth�� �޴´�.
    }
    

    void Update()
    {
        if (skillTargeting == false) // ���ĸ�Ÿŷ�� ��ų�� ���� �ʾ��� ���
        {
            if (isSearch == true) // �÷��̾ �����Ÿ� �ȿ� ������ �ʾ��� ���
            {
                if (king.die == false) // ���ĸ�Ÿŷ�� ���� �ʾ��� ���
                {
                    animation.Play("walk");
                    WayPointMove();
                }
            }
            else // ��Ʈ�� �����Ÿ��ȿ� ���Դٸ�
            {
                if (king.die == false)
                {
                    attackRun(); // ������ �ϱ����� ������ ��� �Ÿ��� ������

                    // �ִ�ð��� ���� ����
                    attackTime -= Time.deltaTime; // �������� �ƴ� �ʴ����� �A�� ��ǻ�͸��� fps�� �ٸ��Ǹ�...
                    if (attackCheck == true && attackTime <= 0)
                    {
                        attackTime = maxTime; // �ִ�ð��� �ʱ�ȭ
                        Attack(); // ����!!
                    }
                }
            }
        }

        else // ���ĸ�Ÿŷ�� ��ų�� �¾��� ���
        {
            SkillAttack();
        }
    }

    void WayPointMove() // Waypoint�� ���� ĳ���͸� �̵���Ű�� ���� �޼ҵ�
    {
        Vector3 direction = transform.TransformDirection(new Vector3(0, 0, 1)); // ������ǥ�迡�� ������ǥ��� ������ �ٲ۴�.
       
        if (sparta.isGrounded) // CharacterController�� ��ǥ�鿡 �پ�������
        {
            if (isWayPoint == false)
            {
                // ���ĸ�Ÿŷ�� ��������Ʈ ������ ȸ���� ��Ű�� ���̸� ȸ���� ��Ű�� �̵��� .Move( )�ʿ��� �����Ѵ�.
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(wayPoint0.transform.position - transform.position), 1);
                direction.y -= 20 * Time.deltaTime; // ĳ������Ʈ�ѷ��� �߷��� �־�� ��������.
                sparta.Move(direction * Time.smoothDeltaTime * MoveSpeed);

                if (Vector3.Distance(transform.position, wayPoint0.transform.position) <= 0.5f) // ��������Ʈ�� 0.5���Ϸ� ��������� ��쿣
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
            Search(); // ��Ʈ�� �߰� ������(��Ʈ�� �����Ÿ��ȿ� ������ �Ǹ���)
        }

        else // CharacterController�� ��ǥ�鿡 �پ����� ������
        {
            direction.y -= 20 * Time.deltaTime; // �߷��� �־ ĳ���ʹ� �������� �Ѵ�.
            sparta.Move(direction * Time.smoothDeltaTime * MoveSpeed); // ĳ������ �̵�
        }
    }

    void Search() // �÷��̾�(��Ʈ)�� ��ġ�� �ľ��ϴµ� ���Ǵ� �޼ҵ�
    {
        float distance = Vector3.Distance(Target.transform.position, transform.position);
        
        if (distance < 5) 
        {
            isSearch = false;
        }
    }
    
    void Attack() // �����ϴ� �ൿ�� ���ϰ� �ϴ� �޼ҵ�
    {
        animation.Play("attack");
        attackCheck = false; // �� �κ��� �������� ������ ��������� ������ �ϰ� �ȴ�.
        if(PlayerWin.playerWin != true)
            MuteHealth.playerHealth -= 10.0f; // �� �� ���ݴ� �÷��̾� ü���� 10�� ��´�
        healthBar.fillAmount = MuteHealth.playerHealth * 0.01f; // ProgressBar�� ü���� ǥ���ϴ� ���
    }

    void attackRun() // ��ų�� �������� �ƴ϶� �÷��̾ �������ٰ� �ڽ��� �ൿ�ݰ�ȿ� ������ ���� ����
    {
        Vector3 direction = transform.TransformDirection(new Vector3(0, 0, 1)); // ������ǥ�迡�� ������ǥ��� ������ �ٲ۴�

        float distance = Vector3.Distance(Target.transform.position, transform.position);

        if (distance > 5) // �÷��̾�(��Ʈ)�� ���ĸ�Ÿŷ�� ���ݹ��� ������ ������ ���������� ��
        {
            isSearch = true;
        }

        if (distance < 1) // �÷��̾�(��Ʈ)�� ���ĸ�Ÿŷ�� ���ݹ������� ���� ��
        {
            attackCheck = true; // ������ �� �� �ֵ��� ����� ���ִ� �κ�
            // 0.5 ���ذŴ� ���ݹ����� �����Ϸ��� ���� �� ����� ���� ������
            Vector3 reDirect = new Vector3(Target.transform.position.x, Target.transform.position.y - 0.5f, Target.transform.position.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(reDirect - transform.position), Time.smoothDeltaTime * RotationSpeed);   
        }

        else // 5���� 1�̻��� ���������� �ൿ���� �޼ҵ�
        {
            animation.Play("run");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), Time.smoothDeltaTime * RotationSpeed);
            direction.y -= 20 * Time.deltaTime;
            sparta.Move(direction * Time.smoothDeltaTime * 2f);
        }
    }

    void SkillAttack() // ���ĸ�Ÿŷ�� ��ų�� �¾������� �ൿ ���� �޼ҵ�(��ų�� �¾��� ��쿡 �÷��̾ �Ѿƿ�)
    {
        skillTargeting = true; // ��ų�� �¾Ҵٴ°� �˷��ش�. �� ���� ���� ȣ�� �޼ҵ尡 �ణ �޶����� �ȴ�.

        Vector3 direction = transform.TransformDirection(new Vector3(0, 0, 1)); // ������ǥ�迡�� ������ǥ��� ������ �ٲ۴�
        float distance = Vector3.Distance(Target.transform.position, transform.position);

        if (distance > 4.7f) 
        {
            animation.Play("run");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), Time.smoothDeltaTime * RotationSpeed);
            direction.y -= 20 * Time.deltaTime;
            sparta.Move(direction * Time.smoothDeltaTime * 2f);
        }

        /* ��ų�� �°� �ǰ� �׿� ���� �ൿ�� ���� �� ���ε� 4.7�̻��� �Ÿ��̸� ����ؼ� ���ĸ�Ÿŷ�� �÷��̾�(��Ʈ)�� �����ϰ��ϰ�
           �� ���Ϸ� �������� SkillAttack( )�޼ҵ带 ������ ��� WayPointMove( )�޼ҵ�� �ֱ����ؼ� false�� �־ ���̻�
           SkillAttack( )�޼ҵ尡 ȣ����� �ʰ� �����ν� �ڵ��� ���� �ٿ���. */
        else
            skillTargeting = false;
    }
}