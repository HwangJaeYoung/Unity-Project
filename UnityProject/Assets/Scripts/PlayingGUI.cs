using UnityEngine;
using System.Collections;

public class PlayingGUI : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject timer;
    public AudioClip sound;
    private UILabel time;
    private float timeCheck = 6f;
    private bool exit = false, res = false, set = false;
    
    void Start()
    {
        panel1.SetActive(false);
        timer.SetActive(false);
        time = timer.GetComponent<UILabel>();
    }

    void Update()
    {
        if(Input.GetKeyDown("escape") && PlayerWin.playerWin == false && MuteHealth.playerLose == false)
        {
            Time.timeScale = 0;
            audio.PlayOneShot(sound);
            panel1.SetActive(true);
        }

        if (res == true && timeCheck > 0)
        {
            timer.SetActive(true);
            time.text = "[00ff00]" + (int)timeCheck + "[-]" + " �� �� ������ ����� �˴ϴ�...";
            timeCheck -= Time.deltaTime;
        }

        else if (exit == true && timeCheck > 0)
        {
            timer.SetActive(true);
            time.text = "[00ff00]" + (int)timeCheck + "[-]" + " �� �� ������ ���� �˴ϴ�...";
            timeCheck -= Time.deltaTime;
        }

        else if (set == true && timeCheck > 0)
        {
            timer.SetActive(true);
            time.text = "[00ff00]" + (int)timeCheck + "[-]" + " �� �� ó�� ȭ������ ���ư��ϴ�...";
            timeCheck -= Time.deltaTime;
        }
    }

    void setGame() // ó������
    {
        Time.timeScale = 1; // �Ͻ�����
        audio.PlayOneShot(sound); // ȿ���� ����
        set = true;
        StartCoroutine("reGame", 0);
    }

    void continueGame() // ����ϱ�
    {
        Time.timeScale = 1;
        audio.PlayOneShot(sound);
        panel1.SetActive(false);
    }

    void restartGame() // �ٽ��ϱ�
    {
        Time.timeScale = 1;
        audio.PlayOneShot(sound);
        res = true;
        StartCoroutine("reGame", 1);
    }

    void exitGame() // �����ϱ�
    {
        Time.timeScale = 1;
        audio.PlayOneShot(sound);
        exit = true;
        StartCoroutine("reGame", 2);
    }

    IEnumerator reGame(int check) // 5�� �Ŀ� �ൿ�� �����س��� �޼ҵ�
    {
        yield return new WaitForSeconds(5f);

        if (check == 0) // ó������
        {
            PanelControl.exitCheck = false; // escŬ�� �޴��� �������� ���ϰ� ����
            set = false;
            Application.LoadLevel("Start");
        }
        
        if (check == 1) // �ٽ��ϱ�
        {
            PanelControl.exitCheck = false; // escŬ�� �޴��� �������� ���ϰ� ����
            res = false;
            Application.LoadLevel("Playing");
        }

        else if (check == 2) // �����ϱ�
        {
            exit = false;
            System.Diagnostics.Process.GetCurrentProcess().Kill(); // ���μ��� ����
        }
    }
}