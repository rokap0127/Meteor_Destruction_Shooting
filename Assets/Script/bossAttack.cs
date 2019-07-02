using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack : MonoBehaviour
{
    public float rotationSpeed = 10;
    Rigidbody bossAttackRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bossAttackRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}
