using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float seedSpeed = 20f;

    void Update()
    {
        transform.Translate(Vector3.up * seedSpeed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

    public void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }

}
