using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    //[SerializeField]
    //[Tooltip("分")]
    //private int minute;

    //[SerializeField]
    //[Tooltip("秒")]
    //private float seconds;

    //[SerializeField]
    //[Tooltip("時間表示用テキスト")]
    //private Text timeText;

    [SerializeField]
    private GameObject ResultPanel;

    [SerializeField]
    private AudioSource GameBGM;

    [SerializeField]
    private AudioSource ResultBGM;

    //private float totalTime;
    //private float oldSeconds;
    public bool finFlag;

    // Start is called before the first frame update
    void Start()
    {
        //totalTime = minute * 60 + seconds;
        //oldSeconds = 0.0f;
        ResultPanel.SetActive(false);
        finFlag = false;
        ResultBGM.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        ////　制限時間が0秒以下なら何もしない
        //if (totalTime <= 0f)
        //{
        //    return;
        //}

        ////　トータルの制限時間を計測；
        //totalTime = minute * 60 + seconds;
        //totalTime -= Time.deltaTime;

        ////　時間を再設定
        //minute = (int)totalTime / 60;
        //seconds = totalTime - minute * 60;

        //// 時間を表示
        //if ((int)seconds != (int)oldSeconds)
        //{
        //    timeText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        //}

        //oldSeconds = seconds;

        //// ０秒以下になったら終了
        //if (totalTime <= 0.0f)
        //{
        //    Debug.Log("終了");
        //    ResultPanel.SetActive(true);
        //    timeText.enabled = false;
        //    finFlag = true;
        //}

        if (finFlag == true)
        {
            GameBGM.Stop();
            ResultPanel.SetActive(true);
            ResultBGM.Play();

            // ResultBGMの再生の不具合が出たので、治すための応急処置
            finFlag = false;
        }
    }
}