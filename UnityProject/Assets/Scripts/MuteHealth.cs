using UnityEngine;
using System.Collections;

public class MuteHealth : MonoBehaviour
{
    public static float playerHealth = 100; // 플레이어(뮤트)의 최대 체력
    public ParticleSystem muteDie; // 해골 파티클 시스템을 받기위한 변수
    public GameObject menuSet; // 죽었을 때의 UI를 가져옴
    public AudioClip sound; // 효과음ㅁ
    public GameObject dieTitle; // 죽었을 때의 정보표시
    public static bool playerLose = false;
    private bool execute = true; // 해골 파티클 시스템을 한번만 생성하게 제어 하기위한 변수

    void Start()
    {
        playerHealth = 100; // 컴파일때 체력 100이지 새로 컴파일할 필요가없음 그럼 체력은 1로 되있겟지
        playerLose = false; // esc키를 눌려서 생셩되는 메뉴를 표시하지 않게하기 위해 정의함. true면 활성화 불가
    }

    void Update()
    {
        if (playerHealth == 0) // 체력이 0밑으로 떨어지게 되면
        {            
            execute = false; 
            playerHealth = 1; // 한번만 실행되게 하기위해서 체력을 100으로 바꿔버린다. 0만 아니면 된다.
        }

        if (execute == false)
        {
            audio.PlayOneShot(sound);
            playerLose = true; // esc메뉴를 황성화 하지 못하게 막아버림
            Instantiate(muteDie, transform.position, transform.rotation); // 해골 파티클 시스템을 생성한다.
            execute = true;
            StartCoroutine("menu");
        }
    }

    IEnumerator menu()
    {
        // 패배했을시에 타이틀의 생성
        yield return new WaitForSeconds(1f);
        dieTitle.SetActive(true);
        menuSet.SetActive(true);
        Time.timeScale = 0; // 일시정지
    }
}