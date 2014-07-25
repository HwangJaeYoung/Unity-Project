using UnityEngine;
using System.Collections;

public class SkillGUI : MonoBehaviour
{
    public static bool fireEx, iceEx, lightEx, healEx, rainEx; // 해당 스킬이 사용되었는지 되지 않았는지를 표현해준다.
    public static float fireTime, iceTime, lightTime, healTime, rainTime; // 쿨타임의 최대시간(실제로 쿨타임이 적용된 것은 아니고 동작만 보여준다)
    public UISprite FireBallSprite, IceBallSprite, LightBallSprite, HealSprite, FireRainSprite; // 쿨타임표현에 쓰이는 파란색의 스프라이트이다.

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
        // 나머지 밑의 동작방식은 똑같다.
        if (fireEx == true) // 스킬을 사용했으면
        {      
            FireBallSprite.enabled = true; // 쿨타임 스프라이트 활성화
            
            if (fireTime > 0) // 해당시간동안
            {
                fireTime -= 50 * Time.deltaTime; // 시간을 감소시키면서
                FireBallSprite.fillAmount = fireTime * 0.01f; // 쿨타음을 표시한다.
            }

            else // 쿨타임 표시가 끝났으면
            {
                FireBallSprite.enabled = false; // 쿨타임 스프라이트를 비활성화 시켜서 없앤다.
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