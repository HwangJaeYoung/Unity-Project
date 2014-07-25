using UnityEngine;
using System.Collections;

public class DemonHealth : MonoBehaviour
{
    public float DemonHealthPoint = 100; // 데몬의 최대 체력 
    private bool dieCheck = true; //  Dide를 한번만 실행하게끔 제어하기 위한 변수
    public bool die = false; // 데몬이 죽었다는 것을 DemonMoving에 알리기 위한 변수
    public GameObject Book; // 책 아이템
    public ParticleSystem darkAura; // 다크아우라
    public GameObject uiDemon; // 데몬의 정보를 표시하기위한 UI
    public UISprite uiProgress; // 데몬의 체력을 표시하는 레이블

    void Update()
    {
        if (DemonHealthPoint < 0 && dieCheck == true)
        {
            die = true; // 데몬이 죽었다는 것을 알려줘야 된다.
            uiDemon.SetActive(false); // 데몬이 죽으면 정보 UI를 없애버린다.
            Died();
        }
    }

    void Died()  // 데몬이 죽었을 때의 행동정의 메소드
    {
        dieCheck = false; // false로 바꾸는 이유는 여기서 바꿔야 다음 update에서 Died()를 실행하지 않는다.
        animation.Play("die");

        StartCoroutine("auraTime");
        Instantiate(darkAura, transform.position, transform.rotation);
    }

    IEnumerator auraTime()
    {
        yield return new WaitForSeconds(3); // 3초뒤에
        Instantiate(Book, transform.position, transform.rotation); // 책 아이템의 생성
        Destroy(gameObject); // 데몬 게임오브젝트의 삭제
    }

    void OnCollisionEnter(Collision col) // 데몬이 스킬과 충돌 발생시에
    {
        if (die == false)
        {
            // 각 스킬에 따라서 데미지를 주어 체력을 깍아 버린다.
            if (col.gameObject.tag == "FireBall") // 데미지 11
            {
                DemonHealthPoint -= 11;
            }

            else if (col.gameObject.tag == "IceBall") // 데미지 15
            {
                DemonHealthPoint -= 15;
            }

            else if (col.gameObject.tag == "LightBall") // 데미지 12
            {
                DemonHealthPoint -= 12;
            }

            uiProgress.fillAmount = DemonHealthPoint * 0.01f; // 데몬의 체력을 표시한다.
            uiDemon.SetActive(true); // 스킬에 맞았을 시에 데몬의 UI가 표시된다.
            StartCoroutine("activeFalse");
            gameObject.SendMessage("SkillAttack"); // 뮤트의 스킬이 맞았을때의 행동을 정의해논 SkillAttack메소드의 호출
        }
    }

    IEnumerator activeFalse() // 3초 후에 자동적으로 데몬 UI를 사라지게 하는 메소드
    {
        yield return new WaitForSeconds(3f);
        uiDemon.SetActive(false);
    }

    void OnTriggerEnter(Collider col) // FireRain스킬은 트리거 영억 안에 들어오면 다 받게 된다. 한번만...;;
    {
        DemonHealthPoint -= 10; // 데미지 10
        gameObject.SendMessage("SkillAttack"); // 뮤트의 스킬이 맞았을때의 행동을 정의해논 SkillAttack메소드의 호출 
    }
}