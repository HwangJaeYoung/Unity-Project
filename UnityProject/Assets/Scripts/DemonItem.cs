using UnityEngine;
using System.Collections;

public class DemonItem : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // 책의 회전 속도

    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0)); // 책을 주어진 회전속도에 맞게 회전시킨다.
    }

    void OnTriggerEnter(Collider col) // 플레이어(뮤트)가 책에 접근했을 경우에
    {
        if (col.gameObject.tag == "Player" && MuteHealth.playerLose != true)
        {
            if(BookLabel.bookCountDemon < 2) // 3개 이상이면 더 이상 카운트를 하지 않는다. 퀘스트에서는 2개만 있으면 되기 때문에
                BookLabel.bookCountDemon += 1;
            Destroy(gameObject); // 책 아이템의 삭제
        }
    }
}