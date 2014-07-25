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
        // ���� ����UI�� ó������ ��Ȱ��ȭ ��Ų��.
        kingState.SetActive(false);
        demonState.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) //���콺�� Ŭ�������� 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //���콺�� ȭ��� ��ġ�� ���� �߻�! 

            if (Physics.Raycast(ray, out hit, 100)) //���� ���̿� �ε����� 
            {
                if (hit.collider.tag == "King") //�ε��� ������Ʈ�� �±װ� "King"�̴�.
                {
                    GameObject kingObject = (GameObject)hit.collider.gameObject; // �ش� ���ĸ�Ÿ ŷ��
                    KingHealth kh = kingObject.GetComponent<KingHealth>(); // KingHealth ������Ʈ�� �޾ƿ´�.
                    bool die = kh.die;
                    float health = kh.kingHealthPoint; // ���ĸ�Ÿŷ�� ü���� ������

                    if (die == false) // ���� �ʾҴٸ�
                    {
                        uiKing.fillAmount = health * 0.01f;
                        // �ش� ������ UI�� �����ش�.
                        kingState.SetActive(true);
                        demonState.SetActive(false);
                        StartCoroutine("pause", 1);
                    }
                }

                else if (hit.collider.tag == "Demon") //�ε��� ������Ʈ�� �±װ� "Demon"�̴�.
                {
                    GameObject demonObject = (GameObject)hit.collider.gameObject; // �ش� ������
                    DemonHealth dh = demonObject.GetComponent<DemonHealth>(); // DemonHeanth ������Ʈ�� �޾ƿ´�.
                    bool die = dh.die;
                    float health = dh.DemonHealthPoint; // ������ ü���� ������

                    if (die == false) // ���� �ʾҴٸ�
                    {
                        uiDemon.fillAmount = health * 0.01f;
                        // �ش� ������ UI�� �����ش�.
                        kingState.SetActive(false);
                        demonState.SetActive(true);
                        StartCoroutine("pause", 2);
                    }
                }
            }
        }
    }

    IEnumerator pause(int check) // check�� �´� �ش� Ui�� 4���Ŀ� �ڵ����� ������� ���ش�.
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