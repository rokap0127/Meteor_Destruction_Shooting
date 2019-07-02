using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody enemyRigidbody;
    public GameObject enemyBullet;
    public float interval;
    public float speed = 3f;
    public float limitTimer = 2.0f;
    public int enemyHp = 2;

    int state;
    int timerCount;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        state = 0;
        timerCount = 0;
        enemyRigidbody = GetComponent<Rigidbody>();
        while (true)
        {
            Instantiate(enemyBullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
        {
        timerCount++;
            switch (state)
            {
                case 0:
                    Vector3 direction = new Vector3(0, 1, 0).normalized;
                    enemyRigidbody.velocity = direction * speed;
                    if (timerCount > 60 * limitTimer)
                    {
                        state = 1;
                        timerCount = 0;
                    }
                    break;
                case 1:
                    direction = new Vector3(0, -1, 0).normalized;
                    enemyRigidbody.velocity = direction * speed;
                    if (timerCount > 60 * limitTimer)
                    {
                        state = 0;
                        timerCount = 0;
                    }
                    break;
            }
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            enemyHp -= 1;
            StartCoroutine(Blinl());
            if (enemyHp <= 0)
            {
                Destroy(gameObject);
            }
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
