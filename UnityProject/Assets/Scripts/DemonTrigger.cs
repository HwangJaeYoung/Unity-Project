using UnityEngine;
using System.Collections;

public class DemonTrigger : MonoBehaviour
{
    // ���� ���������� �ִ� Ʈ�����̸� �� Ʈ���Ÿ� ����ؾ� ����ǥ�ð� �߰Եȴ�.
    void OnTriggerEnter(Collider col)
    {
        TerrainTrigger.demonTrigger = true;
    }
}