using UnityEngine;
using System.Collections;

public class KingTrigger : MonoBehaviour
{
    // ŷ ���������� �ִ� Ʈ�����̸� �� Ʈ���Ÿ� ����ؾ� ����ǥ�ð� �߰Եȴ�.
    void OnTriggerEnter(Collider col)
    {
        TerrainTrigger.kingTrigger = true;
    }
}