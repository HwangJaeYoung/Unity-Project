using UnityEngine;
using System.Collections;

public class NoticeInfo : MonoBehaviour
{
    public GameObject noticePanel; // �����г��� �޾ƿ´�.
    public AudioClip sound; // Ŭ���ÿ� ����ȿ���� �޾ƿ´�.

    void Start()
    {
        noticePanel.SetActive(false);
    }

    void noticeInfoClick() // ������ư Ŭ��
    {
        audio.PlayOneShot(sound);
        PanelControl.exitCheck = true;// �� ���� ��ư�� �ϳ��� ������������ ǥ������
        PanelControl.keyPanel = false;// �� �߿��� ���� ��ư�� ���ȴٸ�
        PanelControl.questPanel = false;// �ٸ� �͵��� false�� �ؼ� �����Ѵ�.
        PanelControl.noticePanel = true;
        noticePanel.SetActive(true); // �������� �г��� Ȱ��ȭ ��Ų��.
    }

    void noticeExitClick() // �ݱ��ư Ŭ��
    {
        audio.PlayOneShot(sound);
        noticePanel.SetActive(false); // �����г��� ��Ȱ��ȭ
        PanelControl.exitCheck = false; // �ݾҴٴ°��� ����͵� �������� ���� �����̴�.
    }
}