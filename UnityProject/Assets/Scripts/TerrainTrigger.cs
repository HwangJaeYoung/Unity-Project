using UnityEngine;
using System.Collections;

public class TerrainTrigger : MonoBehaviour
{
    public GameObject kingTitle;
    public GameObject demonTitle;
    public GameObject villageTitle;
    public static bool demonTrigger, kingTrigger;
    private bool triggerEnter;

    void Start()
    {
        // 킹과 데몬메세지 처음에는 비활성화
        kingTitle.SetActive(false);
        demonTitle.SetActive(false);
    }

    void OnTriggerExit(Collider col)
    {
        triggerEnter = true;

        if ( (col.gameObject.tag == "Player") && kingTrigger == true && triggerEnter) // 킹 메시지 활성화 부분
        {
            villageTitle.SetActive(false);
            kingTitle.SetActive(true);
            StartCoroutine("titleStop", 1);
        }

        else if ((col.gameObject.tag == "Player") && demonTrigger == true && triggerEnter) // 데몬 메세지 활성화 부분
        {
            villageTitle.SetActive(false);
            demonTitle.SetActive(true);
            StartCoroutine("titleStop", 2);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            triggerEnter = false;
        }
    }

    IEnumerator titleStop(int check)
    {
        yield return new WaitForSeconds(4f); // 4초 후에
        
        if (check == 1)
        {
            kingTitle.SetActive(false); // 킹 메세지 비활성화
            kingTrigger = false;
        }
        else if (check == 2)
        {
            demonTitle.SetActive(false); // 데몬 메세지 비활성화
            demonTrigger = false;
        }
    }
}