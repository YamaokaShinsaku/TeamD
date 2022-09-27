using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poiColor : MonoBehaviour
{
    public GameObject mPoi;
    public Material m1PColor;
    public Material m2PColor;

    /// <summary>
    /// ポイの色を変更
    /// </summary>
    /// <param name="_target">追う対象</param>
    /// <param name="_1PObj">1P</param>
    /// <param name="_2PObj">2P</param>
    public void ColorUpdate(Transform _target, GameObject _1PObj, GameObject _2PObj)
    {
        // targetが1Pであったら
        if(_target == _1PObj.transform)
        {
            mPoi.gameObject.GetComponent<Renderer>().material.color = m1PColor.color;
        }
        // targetが2Pであったら
        if (_target == _2PObj.transform)
        {
            mPoi.gameObject.GetComponent<Renderer>().material.color = m2PColor.color;
        }
    }
}
