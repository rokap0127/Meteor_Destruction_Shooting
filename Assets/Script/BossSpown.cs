﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpown : MonoBehaviour
{
    public GameObject boss;
    GameObject wave;

    // Start is called before the first frame update
    void Start()
    {
        //wave = GameObject.FindGameObjectWithTag("wave");
        //wave = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            boss.SetActive(true);
            //Destroy(wave);
        }
    }
}
