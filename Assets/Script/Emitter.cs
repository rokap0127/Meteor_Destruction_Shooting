﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public GameObject[] waves;

    int currentWave;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //Waveが存在しなければコルーチンを終了する
        if(waves.Length == 0)
        {
            yield break;
        }

        while (true)
        {
            //Waveを作成する
            GameObject wave = Instantiate(waves[currentWave]
                ,transform.position, Quaternion.identity);

            //WaveをEmitterの子要素にする
            //wave.transform.parent = transform;

            //Waveの子要素のEnemyがすべて削除されるまで待機する
            while(wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            //Waveの削除
            Destroy(wave);

            //格納されてるwaveをすべて実行したらcurrentWaveを0にする
            //(最初から->ループ)
            if(waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
