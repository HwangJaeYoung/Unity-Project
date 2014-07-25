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

    void Update( ) // �ݱ� ��ư ������ ���� �Ȱ��� ȿ���� ����.
    {
        if(Input.GetKeyDown("escape"))
        {
            exitButtonClick( );
        }
    }

    void startGame() // ���� ���� ��ư�� ������ ��
    {
        audio.PlayOneShot(sound);
        Application.LoadLevel("Playing");
    }

    void notice() // ������ư�� ������ ��
    {
        audio.PlayOneShot(sound);
        startPanel.SetActive(false);
        noticeInfo.SetActive(true);
    }

    void exitGame() // ��������
    {
        audio.PlayOneShot(sound);
        System.Diagnostics.Process.GetCurrentProcess().Kill(); // ���μ��� ����
    }

    // ������ư Ŭ�� �Ŀ� �ݱ� ��ư�� ������ ��
    void exitButtonClick()
    {
        audio.PlayOneShot(sound);
        noticeInfo.SetActive(false);
        startPanel.SetActive(true);
    }
}