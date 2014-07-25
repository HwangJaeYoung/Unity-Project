using UnityEngine;
using System.Collections;

public class BookLabel : MonoBehaviour
{
    public static int bookCountKing = 0; // ���ĸ�Ÿŷ�� óġ�ϰ� ���� å�� ��
    public static int bookCountDemon = 0;  // ������ óġ�ϰ� ���� å�� ��
    public UILabel countKing; // Questâ�� �ִ� ���� ȹ�� å ���� ǥ���ϴ� ���̺�
    public UILabel countDemon; // Questâ�� �ִ� ���� ȹ�� å ���� ǥ���ϴ� ���̺�

    void Start()
    {
        bookCountDemon = 0;
        bookCountKing = 0;
    }

    // ���̺� ���������� ���� ȹ���� å�� ���� ������Ʈ ���ش�.
    void Update()
    {
        countKing.text = "" + bookCountKing;
        countDemon.text = "" + bookCountDemon;
    }
}