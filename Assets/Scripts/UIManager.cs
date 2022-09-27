using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //[SerializeField]
    //Image image1;

    GameObject StaminaGauge;

    void Start()
    {
        this.StaminaGauge = GameObject.Find("StaminaGauge");
    }
    public void DecreaseStamina()
    {
        this.StaminaGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
}
