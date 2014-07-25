using UnityEngine;
using System.Collections;

public class BookLabel : MonoBehaviour
{
    public static int bookCountKing = 0; // 스파르타킹을 처치하고 얻은 책의 수
    public static int bookCountDemon = 0;  // 데몬을 처치하고 얻은 책의 수
    public UILabel countKing; // Quest창에 있는 현재 획득 책 수를 표현하는 레이블
    public UILabel countDemon; // Quest창에 있는 현재 획득 책 수를 표현하는 레이블

    void Start()
    {
        bookCountDemon = 0;
        bookCountKing = 0;
    }

    // 레이블에 지속적으로 현재 획득한 책의 수를 업데이트 해준다.
    void Update()
    {
        countKing.text = "" + bookCountKing;
        countDemon.text = "" + bookCountDemon;
    }
}