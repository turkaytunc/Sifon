using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float moveHorizontal;

    void Start()
    {
        
    }
    
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
    }
}
