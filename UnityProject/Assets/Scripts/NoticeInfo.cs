using UnityEngine;
using System.Collections;

public class NoticeInfo : MonoBehaviour
{
    public GameObject noticePanel; // 공지패널을 받아온다.
    public AudioClip sound; // 클릭시에 음향효과를 받아온다.

    void Start()
    {
        noticePanel.SetActive(false);
    }

    void noticeInfoClick() // 공지버튼 클릭
    {
        audio.PlayOneShot(sound);
        PanelControl.exitCheck = true;// 세 개의 버튼중 하나가 눌려져있음을 표시해줌
        PanelControl.keyPanel = false;// 그 중에서 공지 버튼을 눌렸다면
        PanelControl.questPanel = false;// 다른 것들은 false로 해서 꺼야한다.
        PanelControl.noticePanel = true;
        noticePanel.SetActive(true); // 공지정보 패널을 활성화 시킨다.
    }

    void noticeExitClick() // 닫기버튼 클릭
    {
        audio.PlayOneShot(sound);
        noticePanel.SetActive(false); // 공지패널의 비활성화
        PanelControl.exitCheck = false; // 닫았다는것은 어느것도 눌려지지 않은 상태이다.
    }
}