using UnityEngine;
using System.Collections;

public class SkillColCheck : MonoBehaviour
{
    public ParticleSystem effect; // fireBall�� ȿ���� �޾ƿ�

    void OnCollisionEnter() // fireBall�� ��ü�� �浹 �����ÿ�
    {
        Instantiate(effect, transform.position, transform.rotation); // �浹��ġ���� ȿ���� �����Ѵ�.
        Destroy(gameObject); // fireBall ����
    }
}