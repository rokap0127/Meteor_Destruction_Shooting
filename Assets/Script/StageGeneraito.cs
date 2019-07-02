using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGeneraito : MonoBehaviour
{
    //waveの間隔
    public float interval;
    //MeteoのPrahabを格納する
    public GameObject[] meteos;
    //現在のMeteo
    int currentMeteo;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
