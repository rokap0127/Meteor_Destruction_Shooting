using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoGenerate : MonoBehaviour
{
    public GameObject meteo;
    public GameObject meteos;
    public float interval = 1.0f;

    IEnumerator Start()
    {
        while (true)
        {
           GameObject meteoGeneraito = Instantiate(meteo, new Vector3(-25, Random.Range(8, -8)), transform.rotation) as GameObject;
            //Instantiate(meteo, new Vector3(0, Random.Range(8, -8)), transform.rotation);
            meteoGeneraito.transform.parent = meteos.transform;
            yield return new WaitForSeconds(interval);
        }
    }
}
