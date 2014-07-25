using UnityEngine;
using System.Collections;

public class SkillGUI : MonoBehaviour
{
    public static bool fireEx, iceEx, lightEx, healEx, rainEx; // �ش� ��ų�� ���Ǿ����� ���� �ʾҴ����� ǥ�����ش�.
    public static float fireTime, iceTime, lightTime, healTime, rainTime; // ��Ÿ���� �ִ�ð�(������ ��Ÿ���� ����� ���� �ƴϰ� ���۸� �����ش�)
    public UISprite FireBallSprite, IceBallSprite, LightBallSprite, HealSprite, FireRainSprite; // ��Ÿ��ǥ���� ���̴� �Ķ����� ��������Ʈ�̴�.

    void Start()
    {
        FireBallSprite.enabled = false;
        IceBallSprite.enabled = false;
        LightBallSprite.enabled = false;
        HealSprite.enabled = false;
        FireRainSprite.enabled = false;
    }

    void Update()
    {
        // ������ ���� ���۹���� �Ȱ���.
        if (fireEx == true) // ��ų�� ���������
        {      
            FireBallSprite.enabled = true; // ��Ÿ�� ��������Ʈ Ȱ��ȭ
            
            if (fireTime > 0) // �ش�ð�����
            {
                fireTime -= 50 * Time.deltaTime; // �ð��� ���ҽ�Ű�鼭
                FireBallSprite.fillAmount = fireTime * 0.01f; // ��Ÿ���� ǥ���Ѵ�.
            }

            else // ��Ÿ�� ǥ�ð� ��������
            {
                FireBallSprite.enabled = false; // ��Ÿ�� ��������Ʈ�� ��Ȱ��ȭ ���Ѽ� ���ش�.
                fireEx = false;
            }
        }

        if (iceEx == true)
        {
            IceBallSprite.enabled = true;

            if (iceTime > 0)
            {
                iceTime -= 50 * Time.deltaTime;
                IceBallSprite.fillAmount = iceTime * 0.01f;
            }
            else
            {
                IceBallSprite.enabled = false;
                iceEx = false;
            }
        }

        if (lightEx == true)
        {
            LightBallSprite.enabled = true;

            if (lightTime > 0)
            {
                lightTime -= 50 * Time.deltaTime;
                LightBallSprite.fillAmount = lightTime * 0.01f;
            }
            else
            {
                LightBallSprite.enabled = false;
                lightEx = false;
            }
        }

        if (healEx == true)
        {
            HealSprite.enabled = true;

            if (healTime > 0)
            {
                healTime -= 50 * Time.deltaTime;
                HealSprite.fillAmount = healTime * 0.01f;
            }
            else
            {
                HealSprite.enabled = false;
                healEx = false;
            }
        }

        if (rainEx == true)
        {
            FireRainSprite.enabled = true;

            if (rainTime > 0)
            {
                rainTime -= 30f * Time.deltaTime;
                FireRainSprite.fillAmount = rainTime * 0.01f;
            }
            else
            {
                FireRainSprite.enabled = false;
                rainEx = false;
            }
        }
    }
}