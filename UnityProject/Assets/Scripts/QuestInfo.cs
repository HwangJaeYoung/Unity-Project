using UnityEngine;
using System.Collections;

public class QuestInfo : MonoBehaviour
{
    public GameObject questPanel; // 퀘스트정보패널을 받아온다.
    public AudioClip sound; // 클릭시에 음향효과를 받아온다.

    void Start()
    {
        questPanel.SetActive(false); ;
    }

    void questInfoClick() // 퀘스트정보 버튼 클릭
    {
        audio.PlayOneShot(sound);
        PanelControl.exitCheck = true;// 세 개의 버튼중 하나가 눌려져있음을 표시해줌
        PanelControl.keyPanel = false;// 그 중에서 퀘스트정보 버튼을 눌렸다면
        PanelControl.questPanel = true;// 다른것들은 false로 해서 꺼야한다.
        PanelControl.noticePanel = false;
        questPanel.SetActive(true); // 퀘스트정보 패널을 활성화 시킨다.
    }

    void questExitClick() // 닫기버튼 클릭
    {
        audio.PlayOneShot(sound);
        questPanel.SetActive(false); ; // 퀘스트정보 패널의 비활성화
        PanelControl.exitCheck = false; // 닫았다는것은 어느것도 눌려지지 않은 상태이다.
    }
}