using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSE : MonoBehaviour
{
    //SE関連
    public AudioClip SelectSound; //セレクトサウンド
    public AudioClip HitSound; //攻撃ヒットサウンド
    public AudioClip DashSound; //ダッシュサウンド
    public AudioClip JumpSound; //ジャンプサウンド
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //-----------------------------
        //セレクト処理に追加
        //-----------------------------
        //セレクトサウンドを再生する
        audioSource.clip = SelectSound;
        audioSource.Play();


        //-----------------------------
        //攻撃処理に追加
        //-----------------------------
        //攻撃ヒットサウンドを再生する
        audioSource.clip = HitSound;
        audioSource.Play();

        //-----------------------------
        //ダッシュ処理に追加
        //-----------------------------
        //ダッシュサウンドを再生する
        audioSource.clip = DashSound;
        audioSource.Play();


        //-----------------------------
        //ジャンプ処理に追加
        //-----------------------------
        //ジャンプサウンドを再生する
        audioSource.clip = JumpSound;
        audioSource.Play();

    }
}
