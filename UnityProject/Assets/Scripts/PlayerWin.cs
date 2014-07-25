using UnityEngine;
using System.Collections;

public class PlayerWin : MonoBehaviour
{
    public AudioClip sound;
    public GameObject menu;
    public GameObject message;
    public static bool playerWin = false;
    private bool check = false; // �ι� ���� ���ϰ� �����ϱ� ��������
    private int indexer = 0;

    void Start()
    {
        playerWin = false;
    }

    void Update()
    {
        if (BookLabel.bookCountDemon == 2 && BookLabel.bookCountKing == 2 && indexer == 0) // ���� �������� �� ���� ȹ������ ��쿡
        {
            playerWin = true; // esc�� �����Ǵ� �޴�UI�� �������� ���ϰ� �ϱ� ���ؼ� ����
            check = true;
            indexer = 1; // �ι� ���� ���ϰ� �����ϱ� ��������
        }

        if(check == true)
        {

            audio.PlayOneShot(sound);
            message.SetActive(true);
            menu.SetActive(true);
            check = false;
            Time.timeScale = 0; // �Ͻ�����
        }
    }
}