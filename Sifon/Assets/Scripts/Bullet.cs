using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float seedSpeed = 20f;

    void Update()
    {
        transform.Translate(Vector3.up * seedSpeed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

}
