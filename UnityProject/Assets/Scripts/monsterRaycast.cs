using UnityEngine;
using System.Collections;

public class monsterRaycast : MonoBehaviour
{
    private RaycastHit hit;
    public GameObject kingState;
    public GameObject demonState;
    public UISprite uiKing;
    public UISprite uiDemon;

    void Start()
    {
        // 몬스터 정보UI를 처음에는 비활성화 시킨다.
        kingState.SetActive(false);
        demonState.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) //마우스를 클릭했을때 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스의 화면상 위치로 레이 발사! 

            if (Physics.Raycast(ray, out hit, 100)) //무언가 레이에 부딪혔다 
            {
                if (hit.collider.tag == "King") //부딪힌 오브젝트의 태그가 "King"이다.
                {
                    GameObject kingObject = (GameObject)hit.collider.gameObject; // 해당 스파르타 킹의
                    KingHealth kh = kingObject.GetComponent<KingHealth>(); // KingHealth 컴포넌트를 받아온다.
                    bool die = kh.die;
                    float health = kh.kingHealthPoint; // 스파르타킹의 체력을 가져옴

                    if (die == false) // 죽지 않았다면
                    {
                        uiKing.fillAmount = health * 0.01f;
                        // 해당 몬스터의 UI를 보여준다.
                        kingState.SetActive(true);
                        demonState.SetActive(false);
                        StartCoroutine("pause", 1);
                    }
                }

                else if (hit.collider.tag == "Demon") //부딪힌 오브젝트의 태그가 "Demon"이다.
                {
                    GameObject demonObject = (GameObject)hit.collider.gameObject; // 해당 데몬의
                    DemonHealth dh = demonObject.GetComponent<DemonHealth>(); // DemonHeanth 컴포넌트를 받아온다.
                    bool die = dh.die;
                    float health = dh.DemonHealthPoint; // 데몬의 체력을 가져옴

                    if (die == false) // 죽지 않았다면
                    {
                        uiDemon.fillAmount = health * 0.01f;
                        // 해당 몬스터의 UI를 보여준다.
                        kingState.SetActive(false);
                        demonState.SetActive(true);
                        StartCoroutine("pause", 2);
                    }
                }
            }
        }
    }

    IEnumerator pause(int check) // check에 맞는 해당 Ui를 4초후에 자동으로 사라지게 해준다.
    {
        yield return new WaitForSeconds(4f);

        if (check == 1)
        {
            kingState.SetActive(false);
        }
        else if (check == 2)
        {
            demonState.SetActive(false);
        }
    }
}