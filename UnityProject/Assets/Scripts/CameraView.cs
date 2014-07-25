using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour
{
    private Vector2 startPos; // 마우스의 위치를 받기 위한 변수
    private GameObject target; // 게임캐릭터의 위치 정보를 받기 위한 변수
    public GUITexture mouseCursor;
    public Camera mainCam;

    void Start()
    {
        target = GameObject.Find("Mute"); // 뮤트를 받아온다.
        mouseCursor.transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {

        
        float moveX = 0f; // x의 이동량
        float moveY = 0f; // y의 이동량

        if (Input.GetMouseButtonDown(1)) // 오른쪽 마우스 버튼을 누르고 있었을 경우에 발생
            startPos = Input.mousePosition; // 처음 마우스의 위치를 가져옴
        else if (Input.GetMouseButton(1))
        {
            Vector2 currentPos = Input.mousePosition; // 이동 된 마우스의 좌표 값을 가지고 있다.
            moveX = Mathf.Abs(currentPos.x - startPos.x); // 현재 마우스 위치 에서 처음의 마우스 위치의 차이의 절댓값 계산
            moveY = Mathf.Abs(currentPos.y - startPos.y);

            // 마우스 포지션은 스크린과 다르게 좌표계 기준축이 왼쪽 하단이다.
            if (moveX > moveY) // 변화량이 X가 Y보다 큰 경우
            {
                if (Input.mousePosition.x > startPos.x) 
                    transform.RotateAround(target.transform.position, Vector3.up, -70 * Time.deltaTime); // 왼쪽으로 화면 이동
                else if(Input.mousePosition.x < startPos.x)
                    transform.RotateAround(target.transform.position, Vector3.up, 70 * Time.deltaTime); // 오른쪽으로 화면 이동        
            }
            else if (moveX < moveY)
            {
                // 상하좌우의 시점변경할 때 각의 제한을 두었다. eulerAngles.x
                if (Input.mousePosition.y > startPos.y && transform.rotation.eulerAngles.x > 300) // 위쪽으로 화면 이동
                {
                    transform.Rotate(new Vector3(-70 * Time.deltaTime, 0, 0), Space.Self);           
                }
                else if (Input.mousePosition.y < startPos.y && transform.rotation.eulerAngles.x < 358) // 아래쪽으로 화면 이동
                {
                    transform.Rotate(new Vector3(70 * Time.deltaTime, 0, 0), Space.Self);
                }              
            }         
        }
        else if (Input.GetMouseButtonUp(1)) // 왼쪽 마우스 버튼을 떼었을 때 발생
            startPos = Vector2.zero;
    }
}