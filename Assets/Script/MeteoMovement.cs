using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoMovement : MonoBehaviour
{    
    public int meteoHp = 1;
    public float speed;
    public float rotationSpeed = 3.0f;
    public GameObject enemy;
    public int max;
    public int min = 1;

    GameObject boss;
    GameObject player;
    Rigidbody meteoRigidbody;
    Vector3 direction;
    IEnumerator bornEnemy;
    bool slowKey;

    // Start is called before the first frame update
    void Start()
    {
        meteoRigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("boss");
        rotationSpeed = Random.Range(-rotationSpeed, rotationSpeed);
    }


    // Update is called once per frame
    void Update()
    {
        if(meteoHp <= 0)
        {
            //if (boss == null)
            //{
            //    Instantiate(enemy, new Vector3(15, Random.Range(-8, 8), 0), transform.rotation);
            //}
            Generator.genepoint = Random.Range(min, max);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        meteoRigidbody.velocity = new Vector3(speed, 0, 0);
        transform.Rotate(rotationSpeed, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            meteoHp -= 1;
            StartCoroutine(Blinl());
        }
        if (other.gameObject.tag == "MeteoDestoryArea")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Blinl()
    {
        var renderComponent = GetComponent<Renderer>();
        renderComponent.enabled = !renderComponent.enabled;
        //yield return new WaitForSeconds(0.2f);
        yield return null;
        renderComponent.enabled = !renderComponent.enabled;
    }

}
