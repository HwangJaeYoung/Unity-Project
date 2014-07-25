using UnityEngine;
using System.Collections;

public class PlayerWin : MonoBehaviour
{
    public AudioClip sound;
    public GameObject menu;
    public GameObject message;
    public static bool playerWin = false;
    private bool check = false; // 두번 실행 못하게 방지하기 위해정의
    private int indexer = 0;

    void Start()
    {
        playerWin = false;
    }

    void Update()
    {
        if (BookLabel.bookCountDemon == 2 && BookLabel.bookCountKing == 2 && indexer == 0) // 각각 마법서를 두 개씩 획득했을 경우에
        {
            playerWin = true; // esc로 생성되는 메뉴UI를 생성하지 못하게 하기 위해서 정의
            check = true;
            indexer = 1; // 두번 실행 못하게 방지하기 위해정의
        }

        if(check == true)
        {

            audio.PlayOneShot(sound);
            message.SetActive(true);
            menu.SetActive(true);
            check = false;
            Time.timeScale = 0; // 일시정지
        }
    }
}