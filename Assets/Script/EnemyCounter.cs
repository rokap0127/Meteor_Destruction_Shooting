using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public Text enemyText;
    private int enemyCounter = 0;
    GameObject[] enemy;
    float timer = 0.0f;
    float interval = 2.0f;
    void Start()
    {
        Check("enemy");
        enemyCounter = enemy.Length;
        enemyText.text = "エネミー : " + enemyCounter;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Check("enemy");
            timer = 0;

        }
        enemyCounter = enemy.Length;
        enemyText.text = "エネミー : " + enemyCounter;
        if (enemyCounter == 0)//||Score>10)
        {

        }
    }
    void Check(string tagname)
    {
        enemy = GameObject.FindGameObjectsWithTag("enemy");
        Debug.Log(enemy.Length); //tagObjects.Lengthはオブジェクトの数
        //if (enemy.Length == 0)
        //{
        //    Debug.Log(tagname + "タグがついたオブジェクトはありません");
        //}
    }
}
