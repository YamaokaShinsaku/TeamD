using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerStamina : MonoBehaviour
{
    //プレイヤー１のスタミナゲージ
    [SerializeField]
    Image image1;
    //プレイヤー２のスタミナゲージ
    [SerializeField]
    Image image2;

    //スタミナが増える量
    [SerializeField]
    float StaminaIncrease;
    //スタミナが減る量
    [SerializeField]
    float StaminaDiminish1;

    int LoseStaminaFlag;

    private void Awake()
    {
        LoseStaminaFlag =0;
    }

    // Start is called before the first frame update
    void Update()
    {

    }

    public void StaminaDown(float DownStamina, int PlayerNum)
    {

        
        //スタミナが減る処理をしていたらスタミナが減る
        //if (LoseStaminaFlag > 0)
        {
            //playerNumは攻撃を受けた側
            if (PlayerNum == 1)
            {
                //攻撃を受けたらスタミナが一定数減る
                image1.fillAmount -= DownStamina * Time.deltaTime;

            }
            else if (PlayerNum == 2)
            {
                image2.fillAmount -= DownStamina * Time.deltaTime;
            }

        }

    }

    public void StaminaUp(float UpStamina, int PlayerNum)
    {
        //スタミナが減る処理をしていなかったらスタミナが増える
        //if (!LoseStaminaFlag)
        {
            //playerNumは攻撃を受けた側
            if (PlayerNum == 1)
            {
                //攻撃を受けたらスタミナが一定数減る
                image1.fillAmount += UpStamina * Time.deltaTime;
            }
            else if (PlayerNum == 2)
            {
                image2.fillAmount += UpStamina * Time.deltaTime;
            }

        }


    }

}
