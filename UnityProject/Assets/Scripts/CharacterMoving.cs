using UnityEngine;
using System.Collections;
[RequireComponent (typeof(CharacterController))]

public class CharacterMoving : MonoBehaviour
{
    public float speed = 3.0F; // �̵��ӵ�
    public float jumpSpeed = 8.0F; // �����ӵ�
    public float gravity = 20.0F; // �߷�
    private float idleTimeCheck = 0f; // idle�� �ð�üũ
    private Vector3 moveDirection = Vector3.zero; // ���⺤��
    private bool jumpCheck = false; // ������ ����üũ
    private bool runCheck = false; // �ٱ��� ����üũ

    void Start()
    {
        idleTimeCheck = Time.time; // idle�� �����ϱ� ���� ���۽ð� �Ҵ�
    }
    
    // ���⼭ true, false�� ���̾��̴µ� ����Ƽ������ ��ġ�� �����ϰ� �����ϱ⿡�� ������� ����.
    void Update()
    {
        if (SkillExecute.magicAuraCheck != true && SkillExecute.fireRainCheck != true) // �� ��ų�� ������ ������ �������� �ʰ� �Ѵ� false�� ������ ���ؼ�
        {
            CharacterController controller = GetComponent<CharacterController>();

            if (idleTimeCheck > 3.0f) // 3�ʰ� ������ 
            {
                animation.Play("idle"); // idle �ִϸ��̼� ����
                idleTimeCheck = 0f; // ������ �����Ƿ� 0���� �ʱ�ȭ
            }

            else // 3�ʰ� ������ �ʾ����Ƿ�
                idleTimeCheck += Time.deltaTime; // �ð��� ��� ���Ѵ�.

            if (controller.isGrounded && SkillExecute.magicAuraCheck == false) // isGrounded�� ����(terrain)�� �پ��ִ��� �ƴ����� �Ǵ����ش�.
            {
                if (Input.GetKey("w")) // w�� ���⼭ ������ �����ϴ� Ű�̴�.
                {
                    moveDirection = new Vector3(0, 0, 1); // ������ǥ���� �̵�����
                    runCheck = true; // �۰Ŵϱ� true�� �ش�.
                }
                else
                    moveDirection = new Vector3(0, 0, 0); // ���� �����Ƿ� ������ �ʿ䰡 ����.
        
                moveDirection = transform.TransformDirection(moveDirection); // ������ǥ�踦 ������ǥ��� �ٲ��ش�.
                moveDirection *= speed; // �ӵ��� �ش�.

                if (Input.GetKeyDown("space")) // ���⼭ spaceŰ�� �����ϴ� Ű�̴�.
                {
                    idleTimeCheck = 0f; // ������ �����ϱ� idle�� �ٽ� 0���� �ʱ�ȭ
                    jumpCheck = true; // ������ �ߴ�.
                    moveDirection.y = jumpSpeed; // ������ �ӵ��� �ο�  
                }
                // ��ų�����ÿ� ������ ���⼭ �ϴ°� ������ ����.
            }

            if (jumpCheck == true)
            {
                animation.Play("jump");
                StartCoroutine("timer"); // jumpCheck�� ���� �ڷ�ƾ ȣ��

            }
            else if (jumpCheck == false && runCheck == true)
            {
                idleTimeCheck = 0f; // �ٴ� �ൿ�� �����ϱ� idle�� 0�� �Ǿ��Ѵ�.
                runCheck = false;
                animation.CrossFade("run");
            }
            moveDirection.y -= gravity * Time.deltaTime;
            /* �߷��� �����Ѵ�. ���⼭ moveDirection.y�� ��� ���̴°� ������ �浹ü������ �浹�� ����
            CharacterController.Move( )�� ��Ʈ�� �̵���Ű�� �����Ƿ� �������� ��ġ ��ȭ�� ������ �ʴ´�. */

            controller.Move(moveDirection * Time.deltaTime); // ĳ���͸� �̵���Ų��. �̶��� �浹üũ�� ���� �� �� �ִ�.
        }
    }

    IEnumerator timer() // false�� �ʰ� �ֱ����� ���� Ÿ�̸�
    {
        yield return new WaitForSeconds(1f); // 1.5�� �Ŀ�
        jumpCheck = false; // false���� �ְ� �Ǵµ� �̷��� ���������� �ٷ� false�� �ٲ��� jump�ִϸ��̼��� �����⵵ ���� run�ִϸ��̼��� ����ȴ�.
    }
}