using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResultPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject firstSelect;     //　最初にフォーカスするゲームオブジェクト

    public GameObject button;   // ボタン

    private EventSystem mES;    // EventSystemを取得

    [SerializeField]
    Text buttonText;        // ボタンのText

    [Header("1ループの長さ(秒単位)")]
    [SerializeField]
    [Range(0.1f, 10.0f)]
    float duration = 1.0f;

    [Header("ループ開始時の色")]
    [SerializeField]
    Color32 startColor = new Color32(255, 255, 255, 255);

    [Header("ループ終了時の色")]
    [SerializeField]
    Color32 endColor = new Color32(255, 255, 255, 64);


    // Start is called before the first frame update
    void Start()
    {
        // Textコンポーネントを持っていないとき
        if (buttonText == null)
        {
            buttonText = GetComponent<Text>();
        }

        mES = GetComponent<EventSystem>();
        //ボタンが選択された状態になる
        //button.Select();
        EventSystem.current.SetSelectedGameObject(button);
    }

    // Update is called once per frame
    void Update()
    {
        // ボタンテキストの色を点滅させる
        buttonText.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));

        //EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
}
