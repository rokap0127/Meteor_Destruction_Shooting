using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBullet : MonoBehaviour
{
    Rigidbody bulletRigidbody;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = new Vector3(-1, 0, 0).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "meteo")
        {
            if(gameObject.tag != "enemyBullet" && gameObject.tag != "bossBullet")
            {
                Destroy(gameObject);
            }
          
        }
        if(other.gameObject.tag == "destoryArea")
        {
            Destroy(gameObject);
        }

        if(gameObject.tag != "bullet")
        {
            if (other.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
       
    }
}
