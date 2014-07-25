using UnityEngine;
using System.Collections;

public class CharacterRotate : MonoBehaviour
{
    private Vector2 startPos; // 클릭시에 마우스의 첫 좌표를 받기위한 변수
    
	void Update ()
    {
        float moveX = 0f; // x의 이동량

        if (Input.GetMouseButtonDown(0)) // 왼쪽 마우스 버튼을 누르고 있었을 경우에 발생
            startPos = Input.mousePosition; // 처음 마우스의 위치를 가져옴
        else if (Input.GetMouseButton(0))
        {
            moveX = Input.mousePosition.x - startPos.x; // 현재 마우스 위치에서 처음의 마우스 위치의 차이
            transform.Rotate(new Vector3(0, moveX, 0), Space.World); // y축을 기준으로 월드좌표계 기준 변경
            startPos = Input.mousePosition; // 이동한 마우스의 좌표를 저장하고 있다. 없으면 막 돌아감 그냥
        }
        else if (Input.GetMouseButtonUp(0)) // 왼쪽 마우스 버튼을 떼었을 때 발생
            startPos = Vector2.zero; // 마우스 좌표를 (0, 0)으로 바꿈
	}
}