using UnityEngine;
using System.Collections;

public class MouseHoverSkill : MonoBehaviour
{
    // ��ų�� ������� �� ��ų���� ǥ�����ش�.
    public GameObject fireInfo;
    public GameObject iceInfo;
    public GameObject lightInfo;
    public GameObject healInfo;
    public GameObject rainInfo;

    void Start()
    {
        fireInfo.SetActive(false);
        iceInfo.SetActive(false);
        lightInfo.SetActive(false);
        healInfo.SetActive(false);
        rainInfo.SetActive(false);
    }
    
    // ȭ������ Ȱ��ȭ ��Ű�� �������� Ȱ��ȭ ��Ű�� �ʴ´�.
    void fireMouseOver()
    {
        fireInfo.SetActive(true);
        iceInfo.SetActive(false);
        lightInfo.SetActive(false);
        healInfo.SetActive(false);
        rainInfo.SetActive(false);
        StartCoroutine("delete", 1);
    }

    void iceMouseOver()
    {
        fireInfo.SetActive(false);
        iceInfo.SetActive(true);
        lightInfo.SetActive(false);
        healInfo.SetActive(false);
        rainInfo.SetActive(false);
        StartCoroutine("delete", 2);
    }

    void lightMouseOver()
    {
        fireInfo.SetActive(false);
        iceInfo.SetActive(false);
        lightInfo.SetActive(true);
        healInfo.SetActive(false);
        rainInfo.SetActive(false);
        StartCoroutine("delete", 3);
    }

    void healMouseOver()
    {
        fireInfo.SetActive(false);
        iceInfo.SetActive(false);
        lightInfo.SetActive(false);
        healInfo.SetActive(true);
        rainInfo.SetActive(false);
        StartCoroutine("delete", 4);
    }

    void rainMouseOver()
    {
        fireInfo.SetActive(false);
        iceInfo.SetActive(false);
        lightInfo.SetActive(false);
        healInfo.SetActive(false);
        rainInfo.SetActive(true);
        StartCoroutine("delete", 5);
    }

    // 2���Ŀ� Ȱ��ȭ �� ��ų������ ��Ȱ��ȭ �����ش�.
    IEnumerator delete(int check)
    {
        yield return new WaitForSeconds(2f);

        if (check == 1)
            fireInfo.SetActive(false);
        else if (check == 2)
            iceInfo.SetActive(false);
        else if (check == 3)
            lightInfo.SetActive(false);
        else if (check == 4)
            healInfo.SetActive(false);
        else if (check == 5)
            rainInfo.SetActive(false);
    }
}