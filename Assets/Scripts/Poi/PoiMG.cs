using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiMG : MonoBehaviour
{
    public PoiMove mMove;
    public Chase mChase;

    /// <summary>
    /// ������
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// �X�V
    /// </summary>
    void Update()
    {
        mChase.ChaseUpdate();
        //mMove.MoveUpdate();
    }


    /// <summary>
    /// �R���C�_�[�ɓ�������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // �^�O���wPlayer�x�ł�������
        if (other.gameObject.tag == "Player")
        {
            // �^�[�Q�b�g�������_���ŕύX����
            mChase.target = mChase.Players[Random.Range(0, mChase.Players.Length)].transform;
        }
    }
}

