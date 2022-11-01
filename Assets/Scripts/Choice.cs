using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Choice : MonoBehaviour
{

    //　最初にフォーカスするゲームオブジェクト
    [SerializeField]
    private GameObject firstSelect;

    public GameObject button;
    public GameObject button2;

    private EventSystem mES;

    void Start()
    {
        mES = GetComponent<EventSystem>();
        //ボタンが選択された状態になる
        //button.Select();
        EventSystem.current.SetSelectedGameObject(button);
    }

    private void Update()
    {
        // ゲームパッドのスティックの傾けた時の値を取得
        float y = Input.GetAxis("Vertical1");

        // 傾きが1の時（↑に倒しているとき）
        if (/*Input.GetKeyDown(KeyCode.UpArrow)*/ y >= 1)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);
        }
        // 傾きが-1の時（↓に倒しているとき）
        if (/*Input.GetKeyDown(KeyCode.DownArrow)*/ y <= -1)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button2);
        }
    }
}
