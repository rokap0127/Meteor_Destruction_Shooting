using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public int playerHp = 10;
    public float speed = 3f;
    public float attackInterval = 0.3f;
    public GameObject bullet;
    public GameObject rightBullet;
    public GameObject mainCamera;
    public GameObject emitter;
    public Slider slider;
    public GameObject recovery;
    bool aroundKey;
    int count;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        aroundKey = false;

        slider.value = playerHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");
        // 上・下
        float y = Input.GetAxisRaw("Vertical");
        // 移動する向きを求める
        Vector3 direction = new Vector3(x, y, 0).normalized;
        // 移動する向きとスピードを代入する
        playerRigidbody.velocity = direction * speed;
        //カメラの移動
        MainCamera(mainCamera);
        MainCamera(emitter);
        MainCamera(recovery);

        //MoveLimit(direction);
    }

    private void Update()
    {
        count++;
        if (Input.GetKeyDown(KeyCode.F))
        {
            aroundKey = !aroundKey;
        }
        if (aroundKey)
        {
            //if (Input.GetButtonDown("Jump"))
            //{
            //    //弾をプレイヤーと同じ位置 / 角度で作成
            //    Instantiate(rightBullet, transform.position, transform.rotation);
            //}
            if (Input.GetButton("Jump"))
            {
                if(count % attackInterval == 0)
                {
                    Instantiate(rightBullet, transform.position, transform.rotation);
                }
            }
        }
        else
        {
            //if (Input.GetButtonDown("Jump"))
            //{
            //    //弾をプレイヤーと同じ位置 / 角度で作成
            //    Instantiate(bullet, transform.position, transform.rotation);
            //}
            if (Input.GetButton("Jump"))
            {
                if (count % attackInterval == 0)
                {
                    Instantiate(bullet, transform.position, transform.rotation);
                }
            }
        }
        if(playerHp <= 0)
        {
            Destroy(gameObject);
        }
        slider.value = playerHp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemyBullet")
        {
            playerHp -= 2;
            StartCoroutine(Blinl());
        }
        if(other.gameObject.tag == "meteo")
        {
            playerHp -= 10;
            
        }
        if(other.gameObject.tag == "enemy")
        {
            playerHp -= 4;
            StartCoroutine(Blinl());
        }

        if (other.gameObject.tag == "bossBullet")
        {
            playerHp -= 4;
            StartCoroutine(Blinl());
        }
        if (other.gameObject.tag == "RecoveryItem")
        {
            if (playerHp <= 10)
            {
                playerHp += 3;
            }
            StartCoroutine(Blinl());
        }

    }

    IEnumerator Blinl()
    {
           var renderComponent = GetComponent<Renderer>();
        renderComponent.enabled = !renderComponent.enabled;
        yield return new WaitForSeconds(0.2f);
        renderComponent.enabled = !renderComponent.enabled;
    }

    //private void MoveLimit(Vector3 direction)
    //{
    //    Vector3 pos = transform.position;
    //    float distance = pos.z - Camera.main.transform.position.z;
    //    Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
    //    Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
    //    //pos += direction * speed * Time.deltaTime;
    //    pos.x = Mathf.Clamp(pos.x, min.x + 1.2f, max.x - 1.2f);
    //    pos.y = Mathf.Clamp(pos.y, min.y + 0.9f, max.y - 0.9f);
    //    transform.position = pos;
    //}

    //メインカメラ
    void MainCamera(GameObject mainCamera)
    {
        if (transform.position.x > -150)
        {
            if (transform.position.x < mainCamera.transform.position.x - 4)
            {
                Vector3 cameraPos = mainCamera.transform.position;

                cameraPos.x = transform.position.x + 4;

                mainCamera.transform.position = cameraPos;
            }
            if (transform.position.x > mainCamera.transform.position.x - 4)
            {
                Vector3 cameraPos = mainCamera.transform.position;

                cameraPos.x = transform.position.x + 4;

                mainCamera.transform.position = cameraPos;
            }
        }

    }

    void ObjMove(GameObject gameObj)
    {
        if (transform.position.x > -150)
        {
            if (transform.position.x < gameObj.transform.position.x - 4)
            {
                Vector3 objectPos = gameObj.transform.position;

                objectPos.x = transform.position.x + 4;

                gameObj.transform.position = objectPos;
            }
        }

    }
}
