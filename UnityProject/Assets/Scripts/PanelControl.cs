using UnityEngine;
using System.Collections;

public class PanelControl : MonoBehaviour
{
    public static bool keyPanel = false, questPanel = false, noticePanel = false;
    public static bool exitCheck = false;
    public GameObject key, quest, notice;

    void Update()
    {
        if (exitCheck == true) // true인 패널만 지속적으로 업데이트하여 표시를 해준다.
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

        else if(exitCheck == false) // 모든 정보 패널을 표시하지 않는다.
        {
            key.SetActive(false);
            quest.SetActive(false);
            notice.SetActive(false);
        }
    }
}