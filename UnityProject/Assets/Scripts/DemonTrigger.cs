using UnityEngine;
using System.Collections;

public class DemonTrigger : MonoBehaviour
{
    // 데몬 서식지역에 있는 트리거이며 이 트리거를 통과해야 지역표시가 뜨게된다.
    void OnTriggerEnter(Collider col)
    {
        TerrainTrigger.demonTrigger = true;
    }
}