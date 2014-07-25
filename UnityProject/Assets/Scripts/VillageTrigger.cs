using UnityEngine;
using System.Collections;

public class VillageTrigger : MonoBehaviour
{
    public GameObject title;
    public GameObject titleKing;
    public GameObject titleDemon;

    void Start()
    {
        title.SetActive(false); // ���� Ÿ��Ʋ ��Ȱ��ȭ
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            titleKing.SetActive(false); // ���ĸ�Ÿŷ �ֵ��� �޼��� ��Ȱ��ȭ
            titleDemon.SetActive(false); // ���󼭽��� �޼��� ��Ȱ��ȭ
            title.SetActive(true); // ���� �޽��� Ȱ��ȭ
            StartCoroutine("titleStop");
        }
    }

    IEnumerator titleStop( )
    {
        yield return new WaitForSeconds(4f); // 4�� �Ŀ�
        title.SetActive(false); // ���� ǥ�� �޼����� ������� �Ѵ�.
    }
}