using UnityEngine;
using System.Collections;

public class keyInfo : MonoBehaviour
{
    public GameObject keyPanel; // Ű�����г��� �޾ƿ´�.
    public AudioClip sound; // Ŭ���ÿ� ����ȿ���� �޾ƿ´�.

    void Start()
    {
        keyPanel.SetActive(false);
    }

    void keyInfoClick() // Ű���� ��ư Ŭ��
    {
        audio.PlayOneShot(sound);
        PanelControl.exitCheck = true; // �� ���� ��ư�� �ϳ��� ������������ ǥ������
        PanelControl.keyPanel = true; // �� �߿��� Ű���� ��ư�� ���ȴٸ�
        PanelControl.questPanel = false; // �ٸ��͵��� false�� �ؼ� �����Ѵ�.
        PanelControl.noticePanel = false;
        keyPanel.SetActive(true); // Ű���� �г��� Ȱ��ȭ ��Ų��.
    }

    void keyExitClick() // �ݱ��ư Ŭ��
    {
        audio.PlayOneShot(sound);
        keyPanel.SetActive(false); // Ű���� �г��� ��Ȱ��ȭ
        PanelControl.exitCheck = false; // �ݾҴٴ°��� ����͵� �������� ���� �����̴�.
    }
}