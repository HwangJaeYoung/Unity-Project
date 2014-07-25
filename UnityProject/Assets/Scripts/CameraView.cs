using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour
{
    private Vector2 startPos; // ���콺�� ��ġ�� �ޱ� ���� ����
    private GameObject target; // ����ĳ������ ��ġ ������ �ޱ� ���� ����
    public GUITexture mouseCursor;
    public Camera mainCam;

    void Start()
    {
        target = GameObject.Find("Mute"); // ��Ʈ�� �޾ƿ´�.
        mouseCursor.transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {

        
        float moveX = 0f; // x�� �̵���
        float moveY = 0f; // y�� �̵���

        if (Input.GetMouseButtonDown(1)) // ������ ���콺 ��ư�� ������ �־��� ��쿡 �߻�
            startPos = Input.mousePosition; // ó�� ���콺�� ��ġ�� ������
        else if (Input.GetMouseButton(1))
        {
            Vector2 currentPos = Input.mousePosition; // �̵� �� ���콺�� ��ǥ ���� ������ �ִ�.
            moveX = Mathf.Abs(currentPos.x - startPos.x); // ���� ���콺 ��ġ ���� ó���� ���콺 ��ġ�� ������ ���� ���
            moveY = Mathf.Abs(currentPos.y - startPos.y);

            // ���콺 �������� ��ũ���� �ٸ��� ��ǥ�� �������� ���� �ϴ��̴�.
            if (moveX > moveY) // ��ȭ���� X�� Y���� ū ���
            {
                if (Input.mousePosition.x > startPos.x) 
                    transform.RotateAround(target.transform.position, Vector3.up, -70 * Time.deltaTime); // �������� ȭ�� �̵�
                else if(Input.mousePosition.x < startPos.x)
                    transform.RotateAround(target.transform.position, Vector3.up, 70 * Time.deltaTime); // ���������� ȭ�� �̵�        
            }
            else if (moveX < moveY)
            {
                // �����¿��� ���������� �� ���� ������ �ξ���. eulerAngles.x
                if (Input.mousePosition.y > startPos.y && transform.rotation.eulerAngles.x > 300) // �������� ȭ�� �̵�
                {
                    transform.Rotate(new Vector3(-70 * Time.deltaTime, 0, 0), Space.Self);           
                }
                else if (Input.mousePosition.y < startPos.y && transform.rotation.eulerAngles.x < 358) // �Ʒ������� ȭ�� �̵�
                {
                    transform.Rotate(new Vector3(70 * Time.deltaTime, 0, 0), Space.Self);
                }              
            }         
        }
        else if (Input.GetMouseButtonUp(1)) // ���� ���콺 ��ư�� ������ �� �߻�
            startPos = Vector2.zero;
    }
}