using UnityEngine;
using System.Collections;

public class VillageTrigger : MonoBehaviour
{
    public GameObject title;
    public GameObject titleKing;
    public GameObject titleDemon;

    void Start()
    {
        title.SetActive(false); // 마을 타이틀 비활성화
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            titleKing.SetActive(false); // 스파르타킹 주둔지 메세지 비활성화
            titleDemon.SetActive(false); // 데몬서식지 메세지 비활성화
            title.SetActive(true); // 마을 메시지 활성화
            StartCoroutine("titleStop");
        }
    }

    IEnumerator titleStop( )
    {
        yield return new WaitForSeconds(4f); // 4초 후에
        title.SetActive(false); // 마을 표시 메세지가 사라지게 한다.
    }
}