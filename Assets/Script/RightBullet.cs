using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBullet : MonoBehaviour
{
    Rigidbody bulletRigidbody;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.right.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "meteo")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "destoryArea")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "boss")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "bossAttack")
        {
            Destroy(gameObject);
        }
    }
}
