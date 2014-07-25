using UnityEngine;
using System.Collections;

public class PanelControl : MonoBehaviour
{
    public static bool keyPanel = false, questPanel = false, noticePanel = false;
    public static bool exitCheck = false;
    public GameObject key, quest, notice;

    void Update()
    {
        if (exitCheck == true) // true�� �гθ� ���������� ������Ʈ�Ͽ� ǥ�ø� ���ش�.
        {
            if (keyPanel == true)
            {
                key.SetActive(true);
                quest.SetActive(false);
                notice.SetActive(false);
            }

            else if (questPanel == true)
            {
                key.SetActive(false);
                quest.SetActive(true);
                notice.SetActive(false);
            }

            else if (noticePanel == true)
            {
                key.SetActive(false);
                quest.SetActive(false);
                notice.SetActive(true);
            }
        }

        else if(exitCheck == false) // ��� ���� �г��� ǥ������ �ʴ´�.
        {
            key.SetActive(false);
            quest.SetActive(false);
            notice.SetActive(false);
        }
    }
}