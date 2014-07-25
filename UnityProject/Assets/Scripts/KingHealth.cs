using UnityEngine;
using System.Collections;

public class KingHealth : MonoBehaviour
{
    public float kingHealthPoint = 100; // 스파르타킹의 최대 체력
    private bool dieCheck = true; // Died를 한번만 실행하게끔 제어하기 위한 변수
    public bool die = false; // 스파르타 킹이 죽었다는 것을 KingMoving에 알리기 위한 변수
    public GameObject Book; // 책 아이템
    public ParticleSystem darkAura; // 다크아우라
    public GameObject uiKing; // 킹의 정보를 표시하기위한 UI
    public UISprite uiProgress; // 킹의 체력을 표시하는 레이블

    void Update ()
    {
        if (kingHealthPoint < 0 && dieCheck == true)
        {
            die = true; // 스파르타 킹이 죽었다는 것을 알려줘야 된다.
            uiKing.SetActive(false); // 킹이 죽으면 정보 UI를 없애버린다.
            Died();        
        }
	}

    void Died() // 스파르타킹이 죽었을 때의 행동정의 메소드
    {
        dieCheck = false; // false로 바꾸는 이유는 여기서 바꿔야 다음 update에서 Died()를 실행하지 않는다.
        
        // 죽을때 두 가지의 동작 중 하나가 랜덤으로 수행된다.
        if (Random.value > 0.5)
            animation.Play("diehard");
        else
            animation.Play("die");

 
        StartCoroutine("auraTime");
        Instantiate(darkAura, transform.position, transform.rotation); // 다크아우라의 생성
    }

    IEnumerator auraTime()
    {
        yield return new WaitForSeconds(3); // 3초뒤에
        Instantiate(Book, transform.position, transform.rotation); // 책 아이템 생성
        Destroy(gameObject); // 스파르타킹 게임오브젝트의 삭제
    }

    void OnCollisionEnter(Collision col) // 스파르타킹이 스킬과 충돌 발생시에
    {
        if (die == false)
        {
            // 각 스킬에 따라서 데미지를 주어 체력을 깍아 버린다.
            if (col.gameObject.tag == "FireBall") // 데미지 11
            {
                kingHealthPoint -= 11;
            }

            else if (col.gameObject.tag == "IceBall") // 데미지 15
            {
                kingHealthPoint -= 15;
            }

            else if (col.gameObject.tag == "LightBall") // 데미지 12
            {
                kingHealthPoint -= 12;
            }

            uiProgress.fillAmount = kingHealthPoint * 0.01f; // 킹의 체력을 표시한다.
            uiKing.SetActive(true); // 스킬에 맞았을 시에 킹의 UI가 표시된다.
            StartCoroutine("activeFalse");
            gameObject.SendMessage("SkillAttack"); // 뮤트의 스킬이 맞았을때의 행동을 정의해논 SkillAttack메소드의 호출
        }
    }

    IEnumerator activeFalse( ) // 3초 후에 자동적으로 킹 UI를 사라지게 하는 메소드
    {
        yield return new WaitForSeconds(3f);
        uiKing.SetActive(false);
    }

    void OnTriggerEnter(Collider col) // FireRain스킬은 트리거 영억 안에 들어오면 다 받게 된다. 한번만...;;
    {
        kingHealthPoint -= 10; // 데미지 10
        gameObject.SendMessage("SkillAttack"); // 뮤트의 스킬이 맞았을때의 행동을 정의해논 SkillAttack메소드의 호출 
    }
}