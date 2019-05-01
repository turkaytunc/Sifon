using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float seedSpeed = 20f;
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(Vector3.up * seedSpeed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

    
}
