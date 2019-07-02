using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject recovery;
    public static int genepoint;
    

    void Awake()
    {
        genepoint = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        switch (genepoint)
        {
            case 0:
                break;
            case 1:
                Instantiate(enemy, new Vector3(pos.x+15, Random.Range(pos.y - 8, pos.y + 8), 0), transform.rotation);
                Instantiate(recovery, new Vector3(Random.Range(pos.x - 5, pos.x+8), Random.Range(pos.y - 8, pos.y + 8), 0), transform.rotation);
                genepoint = 0;
                break;
            case 2:
                Instantiate(enemy, new Vector3(pos.x + 15, Random.Range(pos.y - 8, pos.y + 8), 0), transform.rotation);
                genepoint = 0;
                break;
            case 3:
                Instantiate(recovery, new Vector3(Random.Range(pos.x - 5, pos.x + 8), Random.Range(pos.y - 8, pos.y + 8), 0), transform.rotation);
                genepoint = 0;
                break;
            default:
                genepoint = 0;
                break;
        }
    }
}
