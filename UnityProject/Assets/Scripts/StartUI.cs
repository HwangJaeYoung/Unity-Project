using UnityEngine;
using System.Collections;

public class StartUI : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject noticeInfo;
    public AudioClip sound;

    void Start()
    {
        noticeInfo.SetActive(false);
    }

    void Update( ) // 닫기 버튼 눌렸을 때와 똑같은 효과를 낸다.
    {
        if(Input.GetKeyDown("escape"))
        {
            exitButtonClick( );
        }
    }

    void startGame() // 게임 시작 버튼을 눌렸을 때
    {
        audio.PlayOneShot(sound);
        Application.LoadLevel("Playing");
    }

    void notice() // 공지버튼을 눌렸을 때
    {
        audio.PlayOneShot(sound);
        startPanel.SetActive(false);
        noticeInfo.SetActive(true);
    }

    void exitGame() // 게임종료
    {
        audio.PlayOneShot(sound);
        System.Diagnostics.Process.GetCurrentProcess().Kill(); // 프로세스 종료
    }

    // 공지버튼 클릭 후에 닫기 버튼을 눌렸을 때
    void exitButtonClick()
    {
        audio.PlayOneShot(sound);
        noticeInfo.SetActive(false);
        startPanel.SetActive(true);
    }
}