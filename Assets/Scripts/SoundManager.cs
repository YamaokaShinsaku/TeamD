using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource GameBGM;

    [SerializeField]
    private AudioSource ResultBGM;

    public TimeCount timeCount;


    // Start is called before the first frame update
    void Start()
    {
        //timeCount.GetComponent<TimeCount>();
    }

    // Update is called once per frame
    void Update()
    {

        if(timeCount.finFlag == true)
        {
            GameBGM.Stop();

            ResultBGM.Play();
        }
    }
}
