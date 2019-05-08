using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public Vector2 DirectionalInput { get; set; }
    public  bool JumpButtonDown { get; set; }

    private void Update()
    {
        DirectionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if (Input.GetButtonDown("Jump"))
        {
            JumpButtonDown = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            JumpButtonDown = false;
        }
    }

    public bool EscapeButtonDown()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            return true;
        }
        return false;
    }

    public bool LeftMouseButton()
    {
        if (Input.GetButton("Fire1"))
        {
            return true;
        }
        return false;
    }

    public bool LeftMouseButtonDown()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            return true;
        }
        return false;
    }

    public bool KButtonDown()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            return true;
        }
        return false;
    }

}

