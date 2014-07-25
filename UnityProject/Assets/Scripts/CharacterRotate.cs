using UnityEngine;
using System.Collections;

public class CharacterRotate : MonoBehaviour
{
    private Vector2 startPos; // Ŭ���ÿ� ���콺�� ù ��ǥ�� �ޱ����� ����
    
	void Update ()
    {
        float moveX = 0f; // x�� �̵���

        if (Input.GetMouseButtonDown(0)) // ���� ���콺 ��ư�� ������ �־��� ��쿡 �߻�
            startPos = Input.mousePosition; // ó�� ���콺�� ��ġ�� ������
        else if (Input.GetMouseButton(0))
        {
            moveX = Input.mousePosition.x - startPos.x; // ���� ���콺 ��ġ���� ó���� ���콺 ��ġ�� ����
            transform.Rotate(new Vector3(0, moveX, 0), Space.World); // y���� �������� ������ǥ�� ���� ����
            startPos = Input.mousePosition; // �̵��� ���콺�� ��ǥ�� �����ϰ� �ִ�. ������ �� ���ư� �׳�
        }
        else if (Input.GetMouseButtonUp(0)) // ���� ���콺 ��ư�� ������ �� �߻�
            startPos = Vector2.zero; // ���콺 ��ǥ�� (0, 0)���� �ٲ�
	}
}