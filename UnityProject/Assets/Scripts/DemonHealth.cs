using UnityEngine;
using System.Collections;

public class DemonHealth : MonoBehaviour
{
    public float DemonHealthPoint = 100; // ������ �ִ� ü�� 
    private bool dieCheck = true; //  Dide�� �ѹ��� �����ϰԲ� �����ϱ� ���� ����
    public bool die = false; // ������ �׾��ٴ� ���� DemonMoving�� �˸��� ���� ����
    public GameObject Book; // å ������
    public ParticleSystem darkAura; // ��ũ�ƿ��
    public GameObject uiDemon; // ������ ������ ǥ���ϱ����� UI
    public UISprite uiProgress; // ������ ü���� ǥ���ϴ� ���̺�

    void Update()
    {
        if (DemonHealthPoint < 0 && dieCheck == true)
        {
            die = true; // ������ �׾��ٴ� ���� �˷���� �ȴ�.
            uiDemon.SetActive(false); // ������ ������ ���� UI�� ���ֹ�����.
            Died();
        }
    }

    void Died()  // ������ �׾��� ���� �ൿ���� �޼ҵ�
    {
        dieCheck = false; // false�� �ٲٴ� ������ ���⼭ �ٲ�� ���� update���� Died()�� �������� �ʴ´�.
        animation.Play("die");

        StartCoroutine("auraTime");
        Instantiate(darkAura, transform.position, transform.rotation);
    }

    IEnumerator auraTime()
    {
        yield return new WaitForSeconds(3); // 3�ʵڿ�
        Instantiate(Book, transform.position, transform.rotation); // å �������� ����
        Destroy(gameObject); // ���� ���ӿ�����Ʈ�� ����
    }

    void OnCollisionEnter(Collision col) // ������ ��ų�� �浹 �߻��ÿ�
    {
        if (die == false)
        {
            // �� ��ų�� ���� �������� �־� ü���� ��� ������.
            if (col.gameObject.tag == "FireBall") // ������ 11
            {
                DemonHealthPoint -= 11;
            }

            else if (col.gameObject.tag == "IceBall") // ������ 15
            {
                DemonHealthPoint -= 15;
            }

            else if (col.gameObject.tag == "LightBall") // ������ 12
            {
                DemonHealthPoint -= 12;
            }

            uiProgress.fillAmount = DemonHealthPoint * 0.01f; // ������ ü���� ǥ���Ѵ�.
            uiDemon.SetActive(true); // ��ų�� �¾��� �ÿ� ������ UI�� ǥ�õȴ�.
            StartCoroutine("activeFalse");
            gameObject.SendMessage("SkillAttack"); // ��Ʈ�� ��ų�� �¾������� �ൿ�� �����س� SkillAttack�޼ҵ��� ȣ��
        }
    }

    IEnumerator activeFalse() // 3�� �Ŀ� �ڵ������� ���� UI�� ������� �ϴ� �޼ҵ�
    {
        yield return new WaitForSeconds(3f);
        uiDemon.SetActive(false);
    }

    void OnTriggerEnter(Collider col) // FireRain��ų�� Ʈ���� ���� �ȿ� ������ �� �ް� �ȴ�. �ѹ���...;;
    {
        DemonHealthPoint -= 10; // ������ 10
        gameObject.SendMessage("SkillAttack"); // ��Ʈ�� ��ų�� �¾������� �ൿ�� �����س� SkillAttack�޼ҵ��� ȣ�� 
    }
}