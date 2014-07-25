using UnityEngine;
using System.Collections;

public class QuestInfo : MonoBehaviour
{
    public GameObject questPanel; // ����Ʈ�����г��� �޾ƿ´�.
    public AudioClip sound; // Ŭ���ÿ� ����ȿ���� �޾ƿ´�.

    void Start()
    {
        questPanel.SetActive(false); ;
    }

    void questInfoClick() // ����Ʈ���� ��ư Ŭ��
    {
        audio.PlayOneShot(sound);
        PanelControl.exitCheck = true;// �� ���� ��ư�� �ϳ��� ������������ ǥ������
        PanelControl.keyPanel = false;// �� �߿��� ����Ʈ���� ��ư�� ���ȴٸ�
        PanelControl.questPanel = true;// �ٸ��͵��� false�� �ؼ� �����Ѵ�.
        PanelControl.noticePanel = false;
        questPanel.SetActive(true); // ����Ʈ���� �г��� Ȱ��ȭ ��Ų��.
    }

    void questExitClick() // �ݱ��ư Ŭ��
    {
        audio.PlayOneShot(sound);
        questPanel.SetActive(false); ; // ����Ʈ���� �г��� ��Ȱ��ȭ
        PanelControl.exitCheck = false; // �ݾҴٴ°��� ����͵� �������� ���� �����̴�.
    }
}