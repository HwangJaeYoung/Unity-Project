using UnityEngine;
using System.Collections;

public class SkillExecute : MonoBehaviour
{
    // 스킬들을 생성하기 위한 프리팹을 받아온다.
    private GameObject Character;
    private CharacterController cController;
    public static bool magicAuraCheck; // 매직아우라의 사용여부 판단하는 변수
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
        Character = GameObject.Find("Mute"); // 게임 오브젝트를 받아온다.
        cController = Character.GetComponent<CharacterController>(); // 바닥에 붙었는지 확인하기 위해 CharacterController 컴포넌트를 가져옴
        trigger = GameObject.Find("RainTrigger").GetComponent<BoxCollider>();
        magicAuraCheck = false; // 아직은 사용안한다. 그리알라
        fireRainCheck = false;
    }

    void Update()
    {
        // 1 ~ 5번키는 유사하므로 1번만 주석을 명시하겠다. 또 약간 다른부분은 주석을 명시해야지
        // 똑같은 코드 반복하는걸 나중에 제네릭으로 줄여보던지... 코드 개더러움...
        if (Input.GetKeyDown("1")) // FireBall 
        {
            if (cController.isGrounded && magicAuraCheck == false && fireRainCheck == false)
            {
                Character.animation.Play("attack"); // 공격애니메이션을 실행한다.
                SkillGUI.fireEx = true; // 어떤스킬이 사용되었는지 사용된 스킬번호를 넘겨준다.
                SkillGUI.fireTime = 100; // 쿨타임 시간을 초기화 해준다.
                Rigidbody fireball = (Rigidbody)Instantiate(fireBall, transform.position, transform.rotation);
                fireball.name = "Fire"; // 생성되는 이름을 바꾸어준다. 안하면 (Clone)이 붙게된다.
                fireball.velocity = transform.TransformDirection(new Vector3(0, -1, 0)) * 10; // 로컬방향을 월드방향으로 바꾸어준다.
                StartCoroutine("stop", "Fire"); // 스킬 소멸시기를 관리하는 코루틴 생성
            }
        }

        else if (Input.GetKeyDown("2")) // IceBall
        {
            if (cController.isGrounded && magicAuraCheck == false && fireRainCheck == false)
            {
                Character.animation.Play("attack");
                SkillGUI.iceEx = true; // 어떤스킬이 사용되었는지 사용된 스킬번호를 넘겨준다.
                SkillGUI.iceTime = 100; // 쿨타임 시간을 초기화 해준다.
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
                SkillGUI.lightEx = true; // 어떤스킬이 사용되었는지 사용된 스킬번호를 넘겨준다.
                SkillGUI.lightTime = 100; // 쿨타임 시간을 초기화 해준다.
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
                cPos.y -= 0.2f; // 스킬시전 위치를 조금 아래로 내리려고 빼줌
                SkillGUI.healEx = true; // 어떤스킬이 사용되었는지 사용된 스킬번호를 넘겨준다.
                SkillGUI.healTime = 100; // 쿨타임 시간을 초기화 해준다.
                ParticleSystem magicaura = (ParticleSystem)Instantiate(magicAura, cPos, Quaternion.identity);
                magicaura.name = "MagicAura";

                //플레이어의 체력을 채우는 부분이며 ProgressBar의 길이가 늘어나게 된다.
                if (MuteHealth.playerHealth < 96) // 체력이 96미만이면
                {
                    MuteHealth.playerHealth += 5; // 체력을 5만큼 채우고
                    healthBar.fillAmount = MuteHealth.playerHealth * 0.01f; // ProgressBar상태를 수정한다.
                }

                StartCoroutine("stop", "MagicAura");
                // 매직아우라는 알아서 소멸되므로 굳이 코루틴을 호출 할 필요가 없음
            }
        }

        else if (Input.GetKeyDown("5") && magicAuraCheck == false) // FireRain, Raycast써야되는데 시간이없다...노답...나중에....
        {
            if (cController.isGrounded)
            {
                trigger.enabled = true;
                fireRainCheck = true;
                Vector3 rainPoint = GameObject.Find("RainPoint").transform.position; // 스킬이 발동할 위치의 좌표값을 받아온다.
                Character.animation.Play("attack");
                SkillGUI.rainEx = true; // 어떤스킬이 사용되었는지 사용된 스킬번호를 넘겨준다.
                SkillGUI.rainTime = 100; // 쿨타임 시간을 초기화 해준다.
                ParticleSystem firerain = (ParticleSystem)Instantiate(fireRain, rainPoint, transform.rotation);
                firerain.name = "FireRain";
                StartCoroutine("stop", "FireRain");
            }
        }
    }

    IEnumerator stop(string skillName)
    {
        if (skillName == "FireRain") // 스킬 이름이 FireRain일 경우에
        {
            yield return new WaitForSeconds(5f); // 5초 뒤에 스킬이 소멸된다.
            fireRainCheck = false;
            trigger.enabled = false;
            Destroy(GameObject.Find(skillName));
        }
        else if (skillName == "MagicAura") // 3.3초뒤에 스킬이 소멸되면서
        {
            yield return new WaitForSeconds(3.3f);
            magicAuraCheck = false; // false로 바꾸어서 캐릭터가 이동 할 수 있게 한다.
        }
        else
        {
            yield return new WaitForSeconds(1.5f); // 1.5초 뒤에 스킬이 소멸된다.
            Destroy(GameObject.Find(skillName)); // skillName에 해당하는 스킬을 찾아서 스킬을 소멸 시킨다.
        }
    }
}