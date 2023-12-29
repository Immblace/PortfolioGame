using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float Damage;
    private float BulletSpeed = 7f;



    private void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        transform.Translate(Vector3.up * BulletSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
