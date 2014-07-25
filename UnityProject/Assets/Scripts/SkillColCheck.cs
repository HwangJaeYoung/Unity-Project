using UnityEngine;
using System.Collections;

public class SkillColCheck : MonoBehaviour
{
    public ParticleSystem effect; // fireBall의 효과를 받아옴

    void OnCollisionEnter() // fireBall이 물체에 충돌 했을시에
    {
        Instantiate(effect, transform.position, transform.rotation); // 충돌위치에서 효과를 생성한다.
        Destroy(gameObject); // fireBall 삭제
    }
}