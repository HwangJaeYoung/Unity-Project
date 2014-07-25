using UnityEngine;
using System.Collections;

public class KingItem : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // å�� ȸ�� �ӵ�

    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0)); // å�� �־��� ȸ���ӵ��� �°� ȸ����Ų��.
    }

    void OnTriggerEnter(Collider col) // �÷��̾�(��Ʈ)�� å�� �������� ��쿡
    {
        if (col.gameObject.tag == "Player" && MuteHealth.playerLose != true)
        {
            if (BookLabel.bookCountKing < 2) // 3�� �̻��̸� �� �̻� ī��Ʈ�� ���� �ʴ´�. ����Ʈ������ 2���� ������ �Ǳ� ������
                BookLabel.bookCountKing += 1;
            Destroy(gameObject); // å �������� ����
        }
    }
}