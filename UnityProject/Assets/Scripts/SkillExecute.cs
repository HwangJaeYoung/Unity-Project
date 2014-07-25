using UnityEngine;
using System.Collections;

public class SkillExecute : MonoBehaviour
{
    // ��ų���� �����ϱ� ���� �������� �޾ƿ´�.
    private GameObject Character;
    private CharacterController cController;
    public static bool magicAuraCheck; // �����ƿ���� ��뿩�� �Ǵ��ϴ� ����
    public static bool fireRainCheck;
    private BoxCollider trigger;
    public UISprite healthBar;
    public Rigidbody fireBall;
    public Rigidbody iceBall;
    public Rigidbody lightBall;
    public ParticleSystem magicAura;
    public ParticleSystem fireRain;

    void Start()
    {
        Character = GameObject.Find("Mute"); // ���� ������Ʈ�� �޾ƿ´�.
        cController = Character.GetComponent<CharacterController>(); // �ٴڿ� �پ����� Ȯ���ϱ� ���� CharacterController ������Ʈ�� ������
        trigger = GameObject.Find("RainTrigger").GetComponent<BoxCollider>();
        magicAuraCheck = false; // ������ �����Ѵ�. �׸��˶�
        fireRainCheck = false;
    }

    void Update()
    {
        // 1 ~ 5��Ű�� �����ϹǷ� 1���� �ּ��� ����ϰڴ�. �� �ణ �ٸ��κ��� �ּ��� ����ؾ���
        // �Ȱ��� �ڵ� �ݺ��ϴ°� ���߿� ���׸����� �ٿ�������... �ڵ� ��������...
        if (Input.GetKeyDown("1")) // FireBall 
        {
            if (cController.isGrounded && magicAuraCheck == false && fireRainCheck == false)
            {
                Character.animation.Play("attack"); // ���ݾִϸ��̼��� �����Ѵ�.
                SkillGUI.fireEx = true; // ���ų�� ���Ǿ����� ���� ��ų��ȣ�� �Ѱ��ش�.
                SkillGUI.fireTime = 100; // ��Ÿ�� �ð��� �ʱ�ȭ ���ش�.
                Rigidbody fireball = (Rigidbody)Instantiate(fireBall, transform.position, transform.rotation);
                fireball.name = "Fire"; // �����Ǵ� �̸��� �ٲپ��ش�. ���ϸ� (Clone)�� �ٰԵȴ�.
                fireball.velocity = transform.TransformDirection(new Vector3(0, -1, 0)) * 10; // ���ù����� ����������� �ٲپ��ش�.
                StartCoroutine("stop", "Fire"); // ��ų �Ҹ�ñ⸦ �����ϴ� �ڷ�ƾ ����
            }
        }

        else if (Input.GetKeyDown("2")) // IceBall
        {
            if (cController.isGrounded && magicAuraCheck == false && fireRainCheck == false)
            {
                Character.animation.Play("attack");
                SkillGUI.iceEx = true; // ���ų�� ���Ǿ����� ���� ��ų��ȣ�� �Ѱ��ش�.
                SkillGUI.iceTime = 100; // ��Ÿ�� �ð��� �ʱ�ȭ ���ش�.
                Rigidbody iceball = (Rigidbody)Instantiate(iceBall, transform.position, transform.rotation);
                iceball.name = "Ice";
                iceball.velocity = transform.TransformDirection(new Vector3(0, -1, 0)) * 10;
                StartCoroutine("stop", "Ice");
            }
        }

        else if (Input.GetKeyDown("3") && magicAuraCheck == false && fireRainCheck == false) // LightBall
        {
            if (cController.isGrounded)
            {
                Character.animation.Play("attack");
                SkillGUI.lightEx = true; // ���ų�� ���Ǿ����� ���� ��ų��ȣ�� �Ѱ��ش�.
                SkillGUI.lightTime = 100; // ��Ÿ�� �ð��� �ʱ�ȭ ���ش�.
                Rigidbody lightball = (Rigidbody)Instantiate(lightBall, transform.position, transform.rotation);
                lightball.name = "Light";
                lightball.velocity = transform.TransformDirection(new Vector3(0, -1, 0)) * 10;
                StartCoroutine("stop", "Light");
            }
        }

        else if (Input.GetKeyDown("4") && fireRainCheck == false) // Heal
        {
            if (cController.isGrounded)
            {
                magicAuraCheck = true;
                Character.animation.Play("attack");
                Vector3 cPos = Character.transform.position;
                cPos.y -= 0.2f; // ��ų���� ��ġ�� ���� �Ʒ��� �������� ����
                SkillGUI.healEx = true; // ���ų�� ���Ǿ����� ���� ��ų��ȣ�� �Ѱ��ش�.
                SkillGUI.healTime = 100; // ��Ÿ�� �ð��� �ʱ�ȭ ���ش�.
                ParticleSystem magicaura = (ParticleSystem)Instantiate(magicAura, cPos, Quaternion.identity);
                magicaura.name = "MagicAura";

                //�÷��̾��� ü���� ä��� �κ��̸� ProgressBar�� ���̰� �þ�� �ȴ�.
                if (MuteHealth.playerHealth < 96) // ü���� 96�̸��̸�
                {
                    MuteHealth.playerHealth += 5; // ü���� 5��ŭ ä���
                    healthBar.fillAmount = MuteHealth.playerHealth * 0.01f; // ProgressBar���¸� �����Ѵ�.
                }

                StartCoroutine("stop", "MagicAura");
                // �����ƿ��� �˾Ƽ� �Ҹ�ǹǷ� ���� �ڷ�ƾ�� ȣ�� �� �ʿ䰡 ����
            }
        }

        else if (Input.GetKeyDown("5") && magicAuraCheck == false) // FireRain, Raycast��ߵǴµ� �ð��̾���...���...���߿�....
        {
            if (cController.isGrounded)
            {
                trigger.enabled = true;
                fireRainCheck = true;
                Vector3 rainPoint = GameObject.Find("RainPoint").transform.position; // ��ų�� �ߵ��� ��ġ�� ��ǥ���� �޾ƿ´�.
                Character.animation.Play("attack");
                SkillGUI.rainEx = true; // ���ų�� ���Ǿ����� ���� ��ų��ȣ�� �Ѱ��ش�.
                SkillGUI.rainTime = 100; // ��Ÿ�� �ð��� �ʱ�ȭ ���ش�.
                ParticleSystem firerain = (ParticleSystem)Instantiate(fireRain, rainPoint, transform.rotation);
                firerain.name = "FireRain";
                StartCoroutine("stop", "FireRain");
            }
        }
    }

    IEnumerator stop(string skillName)
    {
        if (skillName == "FireRain") // ��ų �̸��� FireRain�� ��쿡
        {
            yield return new WaitForSeconds(5f); // 5�� �ڿ� ��ų�� �Ҹ�ȴ�.
            fireRainCheck = false;
            trigger.enabled = false;
            Destroy(GameObject.Find(skillName));
        }
        else if (skillName == "MagicAura") // 3.3�ʵڿ� ��ų�� �Ҹ�Ǹ鼭
        {
            yield return new WaitForSeconds(3.3f);
            magicAuraCheck = false; // false�� �ٲپ ĳ���Ͱ� �̵� �� �� �ְ� �Ѵ�.
        }
        else
        {
            yield return new WaitForSeconds(1.5f); // 1.5�� �ڿ� ��ų�� �Ҹ�ȴ�.
            Destroy(GameObject.Find(skillName)); // skillName�� �ش��ϴ� ��ų�� ã�Ƽ� ��ų�� �Ҹ� ��Ų��.
        }
    }
}