using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public float speed = 3.0f;
    public float widthSpeed = 10.0f;
    public int Hp = 20; //Hp
    //public GameObject meteoGeneraito;
    public GameObject bossAttack1;
    public GameObject bossAttack2;
    public GameObject bossBullet;

    Rigidbody bossRigidbody;
    public int modeSwichTime = 10;//モードが変わる時間
    //public float interval = 0.5f;
    bool modeSwich; //モードのオンオフ
    bool attackSwich;　//攻撃のオンオフ
    int modeCount; //モード変更に使うカウント
    int AttackCount;
    int move1State; //上下移動
    int move2State;
    int moveTimerCount;

    // Start is called before the first frame update
    void Start()
    {
        modeSwich = false;
        modeCount = 0;
        AttackCount = 0;
        bossRigidbody = GetComponent<Rigidbody>();
        attackSwich = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Hp0以下になったら消す
        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
        //Hp50以下になったらモード変更
        if(Hp <= 50)
        {
            modeSwich = true;
        }
        if(Hp <= 25)
        {
            modeSwich = true;
        }
    }

    private void FixedUpdate()
    {
        //モード変更
        ModeSwich();

        //移動
        if (!modeSwich)
        {
            bossRigidbody.velocity = Vector3.zero;
            Move();
        }
        else if(modeSwich)
        {
            bossRigidbody.velocity = Vector3.zero;
            Move2();
        }
        //Bulletの間隔
        if (!modeSwich)
        {
            AttackCount++;
            //if(AttackCount % 600 == 0)
            //{
            //    attackSwich = !attackSwich;
            //}
            //if (attackSwich)
            //{
            if (AttackCount % 20 == 0)
                {
                    Instantiate(bossBullet, transform.position + new Vector3(-3, 0, 0), transform.rotation);
                }
            //}          
        }        
    }

    /// <summary>
    /// 当たり判定
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!modeSwich)
        {
            if (other.gameObject.tag == "bullet")
            {
                Hp -= 1;
                StartCoroutine(Blinl());
            }
        }   
    }

    /// <summary>
    /// 点滅
    /// </summary>
    /// <returns></returns>
    IEnumerator Blinl()
    {
        var renderComponent = GetComponent<Renderer>();
        renderComponent.enabled = !renderComponent.enabled;
        //yield return new WaitForSeconds(0.2f);
        yield return null;
        renderComponent.enabled = !renderComponent.enabled;
    }

    void ModeSwich()
    {
        //モード変更
        if (modeSwich)
        {
            //meteoGeneraito.SetActive(true);
            bossAttack1.SetActive(true);
            bossAttack2.SetActive(true);
            modeCount++;
            if (modeCount / 60 >= modeSwichTime)
            {
                modeSwich = false;
            }
        }
        if (!modeSwich)
        {
            //meteoGeneraito.SetActive(false);
            bossAttack1.SetActive(false);
            bossAttack2.SetActive(false);
        }
    }

    private void Move()
    {
        //float limitTimer = 1;
        moveTimerCount++;

        switch (move1State)
        {
            case 0:
                Vector3 direction = new Vector3(0, 1, 0).normalized;
                bossRigidbody.velocity = direction * speed;
                if (transform.position.y >= 13)
                {
                    move1State = 1;
                    moveTimerCount = 0;
                }
                break;
            case 1:
                direction = new Vector3(0, -1, 0).normalized;
                bossRigidbody.velocity = direction * speed;
                if (transform.position.y <= -13)
                {
                    move1State = 0;
                    moveTimerCount = 0;
                }
                break;
        }
    }
    private void Move2()
    {

        //float limitTimer = 1f;
        //float widthTimer = 0.7f;
        moveTimerCount++;

        switch (move2State)
        {
            case 0:
                //縦puls 0まで
                Vector3 direction = new Vector3(0, 1, 0).normalized;
                bossRigidbody.velocity = direction * speed;
                if (transform.position.y >= 1)
                {
                    move2State = 4;
                }
                break;
            case 1:
                //縦plus 13まで
                direction = new Vector3(0, 1, 0).normalized;
                bossRigidbody.velocity = direction * speed;
                if (transform.position.y >= 13)
                {
                    move2State = 4;
                }
                break;

            case 2:
                //縦マイナス　0まで
                direction = new Vector3(0, -1, 0).normalized;
                bossRigidbody.velocity = direction * speed;
                if (transform.position.y <= -1)
                {
                    move2State = 4;
                }
                break;

            case 3:
                //縦マイナス　-13まで
                direction = new Vector3(0, -1, 0).normalized;
                bossRigidbody.velocity = direction * speed;
                if (transform.position.y <= -13)
                {
                    move2State = 4;
                }
                break;
            case 4:
                //横マイナス
                direction = new Vector3(-1, 0, 0).normalized;
                bossRigidbody.velocity = direction * widthSpeed;
                if (transform.position.x <= -20)
                {
                    move2State = 5;
                }
                break;
            case 5:
                //横プラス
                direction = new Vector3(11, 0, 0).normalized;
                bossRigidbody.velocity = direction * widthSpeed;
                if (transform.position.x >= 20)
                {   
                    moveTimerCount = 0;
                    if(transform.position.y >= 12)
                    {
                        move2State = 2;
                    }
                    else if(transform.position.y <= 1.5 && transform.position.y >= 0){
                        move2State = 1;
                    }
                    else if (transform.position.y >= -1.5 && transform.position.y <= 0)
                    {
                        move2State = 3;
                    }
                    else if(transform.position.y <= -12)
                    {
                        move2State = 0;
                    }
                }
                break;
            
        }
    }
}
