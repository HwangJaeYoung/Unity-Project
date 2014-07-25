using UnityEngine;
using System.Collections;

public class MouseHoverSkill : MonoBehaviour
{
    // 스킬을 사용했을 때 스킬정보 표시해준다.
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
    
    // 화염구만 활성화 시키고 나머지는 활성화 시키지 않는다.
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

    // 2초후에 활성화 된 스킬정보를 비활성화 시켜준다.
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