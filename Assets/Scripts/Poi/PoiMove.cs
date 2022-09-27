using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiMove : MonoBehaviour
{
    //Animator��anim�Ƃ����ϐ��Œ�`����
    private Animator anim;
    private float mTime;
    private float mScoopTime;

    /// <summary>
    /// ������
    /// </summary>
    void Start()
    {
        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        anim = gameObject.GetComponent<Animator>();
        mTime = 0.0f;
        mScoopTime = 15.0f;
    }

    /// <summary>
    /// �X�V
    /// </summary>
    void Update()
    {
        mTime += Time.deltaTime;
        // ���Ԍo�߂�����
        if (mTime > mScoopTime)
        {
            // Bool�^�̃p�����[�^�[��True�ɂ���
            anim.SetBool("scoop", true);
            mTime = 0.0f;
            mScoopTime -= 1;
        }
        else
        {
            // bool�^�̃p�����[�^�[��false�ɂ���
            anim.SetBool("scoop", false);
        }
    }
}