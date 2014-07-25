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
            time.text = "[00ff00]" + (int)timeCheck + "[-]" + " 초 후 게임이 재시작 됩니다...";
            timeCheck -= Time.deltaTime;
        }

        else if (exit == true && timeCheck > 0)
        {
            timer.SetActive(true);
            time.text = "[00ff00]" + (int)timeCheck + "[-]" + " 초 후 게임이 종료 됩니다...";
            timeCheck -= Time.deltaTime;
        }

        else if (set == true && timeCheck > 0)
        {
            timer.SetActive(true);
            time.text = "[00ff00]" + (int)timeCheck + "[-]" + " 초 후 처음 화면으로 돌아갑니다...";
            timeCheck -= Time.deltaTime;
        }
    }

    void setGame() // 처음으로
    {
        Time.timeScale = 1; // 일시정지
        audio.PlayOneShot(sound); // 효과음 생성
        set = true;
        StartCoroutine("reGame", 0);
    }

    void continueGame() // 계속하기
    {
        Time.timeScale = 1;
        audio.PlayOneShot(sound);
        panel1.SetActive(false);
    }

    void restartGame() // 다시하기
    {
        Time.timeScale = 1;
        audio.PlayOneShot(sound);
        res = true;
        StartCoroutine("reGame", 1);
    }

    void exitGame() // 종료하기
    {
        Time.timeScale = 1;
        audio.PlayOneShot(sound);
        exit = true;
        StartCoroutine("reGame", 2);
    }

    IEnumerator reGame(int check) // 5초 후에 행동을 정의해놓은 메소드
    {
        yield return new WaitForSeconds(5f);

        if (check == 0) // 처음으로
        {
            PanelControl.exitCheck = false; // esc클릭 메뉴를 생성하지 못하게 막음
            set = false;
            Application.LoadLevel("Start");
        }
        
        if (check == 1) // 다시하기
        {
            PanelControl.exitCheck = false; // esc클릭 메뉴를 생성하지 못하게 막음
            res = false;
            Application.LoadLevel("Playing");
        }

        else if (check == 2) // 종료하기
        {
            exit = false;
            System.Diagnostics.Process.GetCurrentProcess().Kill(); // 프로세스 종료
        }
    }
}