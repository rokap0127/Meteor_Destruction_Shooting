using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteoCounter : MonoBehaviour
{
    public Text meteoText;
    private int meteoCounter = 0;
    GameObject[] meteo;
    float timer = 0.0f;
    float interval = 2.0f;
    void Start()
    {
        Check("meteo");
        meteoCounter = meteo.Length;
        meteoText.text = "隕石 : " + meteoCounter;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Check("meteo");
            timer = 0;

        }
        meteoCounter = meteo.Length;
        meteoText.text = "隕石 : " + meteoCounter;
        if (meteoCounter == 0)//||Score>10)
        {

        }
    }
    void Check(string tagname)
    {
        meteo = GameObject.FindGameObjectsWithTag("meteo");
        Debug.Log(meteo.Length); //tagObjects.Lengthはオブジェクトの数
        //if (enemy.Length == 0)
        //{
        //    Debug.Log(tagname + "タグがついたオブジェクトはありません");
        //}
    }
}
