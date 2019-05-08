﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float seedSpeed = 15f;

    void Update()
    {
        transform.Translate(Vector3.up * seedSpeed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

    //dusmanla etkilesime girdiginde kendini yok et
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
