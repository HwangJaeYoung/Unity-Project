using UnityEngine;
using System.Collections;

public class KingHealth : MonoBehaviour
{
    public float kingHealthPoint = 100; // ���ĸ�Ÿŷ�� �ִ� ü��
    private bool dieCheck = true; // Died�� �ѹ��� �����ϰԲ� �����ϱ� ���� ����
    public bool die = false; // ���ĸ�Ÿ ŷ�� �׾��ٴ� ���� KingMoving�� �˸��� ���� ����
    public GameObject Book; // å ������
    public ParticleSystem darkAura; // ��ũ�ƿ��
    public GameObject uiKing; // ŷ�� ������ ǥ���ϱ����� UI
    public UISprite uiProgress; // ŷ�� ü���� ǥ���ϴ� ���̺�

    void Update ()
    {
        if (kingHealthPoint < 0 && dieCheck == true)
        {
            die = true; // ���ĸ�Ÿ ŷ�� �׾��ٴ� ���� �˷���� �ȴ�.
            uiKing.SetActive(false); // ŷ�� ������ ���� UI�� ���ֹ�����.
            Died();        
        }
	}

    void Died() // ���ĸ�Ÿŷ�� �׾��� ���� �ൿ���� �޼ҵ�
    {
        dieCheck = false; // false�� �ٲٴ� ������ ���⼭ �ٲ�� ���� update���� Died()�� �������� �ʴ´�.
        
        // ������ �� ������ ���� �� �ϳ��� �������� ����ȴ�.
        if (Random.value > 0.5)
            animation.Play("diehard");
        else
            animation.Play("die");

 
        StartCoroutine("auraTime");
        Instantiate(darkAura, transform.position, transform.rotation); // ��ũ�ƿ���� ����
    }

    IEnumerator auraTime()
    {
        yield return new WaitForSeconds(3); // 3�ʵڿ�
        Instantiate(Book, transform.position, transform.rotation); // å ������ ����
        Destroy(gameObject); // ���ĸ�Ÿŷ ���ӿ�����Ʈ�� ����
    }

    void OnCollisionEnter(Collision col) // ���ĸ�Ÿŷ�� ��ų�� �浹 �߻��ÿ�
    {
        if (die == false)
        {
            // �� ��ų�� ���� �������� �־� ü���� ��� ������.
            if (col.gameObject.tag == "FireBall") // ������ 11
            {
                kingHealthPoint -= 11;
            }

            else if (col.gameObject.tag == "IceBall") // ������ 15
            {
                kingHealthPoint -= 15;
            }

            else if (col.gameObject.tag == "LightBall") // ������ 12
            {
                kingHealthPoint -= 12;
            }

            uiProgress.fillAmount = kingHealthPoint * 0.01f; // ŷ�� ü���� ǥ���Ѵ�.
            uiKing.SetActive(true); // ��ų�� �¾��� �ÿ� ŷ�� UI�� ǥ�õȴ�.
            StartCoroutine("activeFalse");
            gameObject.SendMessage("SkillAttack"); // ��Ʈ�� ��ų�� �¾������� �ൿ�� �����س� SkillAttack�޼ҵ��� ȣ��
        }
    }

    IEnumerator activeFalse( ) // 3�� �Ŀ� �ڵ������� ŷ UI�� ������� �ϴ� �޼ҵ�
    {
        yield return new WaitForSeconds(3f);
        uiKing.SetActive(false);
    }

    void OnTriggerEnter(Collider col) // FireRain��ų�� Ʈ���� ���� �ȿ� ������ �� �ް� �ȴ�. �ѹ���...;;
    {
        kingHealthPoint -= 10; // ������ 10
        gameObject.SendMessage("SkillAttack"); // ��Ʈ�� ��ų�� �¾������� �ൿ�� �����س� SkillAttack�޼ҵ��� ȣ�� 
    }
}