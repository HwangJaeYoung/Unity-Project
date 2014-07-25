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
        // ŷ�� ����޼��� ó������ ��Ȱ��ȭ
        kingTitle.SetActive(false);
        demonTitle.SetActive(false);
    }

    void OnTriggerExit(Collider col)
    {
        triggerEnter = true;

        if ( (col.gameObject.tag == "Player") && kingTrigger == true && triggerEnter) // ŷ �޽��� Ȱ��ȭ �κ�
        {
            villageTitle.SetActive(false);
            kingTitle.SetActive(true);
            StartCoroutine("titleStop", 1);
        }

        else if ((col.gameObject.tag == "Player") && demonTrigger == true && triggerEnter) // ���� �޼��� Ȱ��ȭ �κ�
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
        yield return new WaitForSeconds(4f); // 4�� �Ŀ�
        
        if (check == 1)
        {
            kingTitle.SetActive(false); // ŷ �޼��� ��Ȱ��ȭ
            kingTrigger = false;
        }
        else if (check == 2)
        {
            demonTitle.SetActive(false); // ���� �޼��� ��Ȱ��ȭ
            demonTrigger = false;
        }
    }
}