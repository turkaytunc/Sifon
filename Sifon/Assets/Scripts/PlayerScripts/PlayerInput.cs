using UnityEngine;

[RequireComponent(typeof(PlayerMovementControl))]
public class PlayerInput : MonoBehaviour
{

    public Vector2 DirectionalInput { get; set; }

    private void Start()
    {
    }

    private void Update()
    {
        DirectionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }

    public bool EscapeButtonDown()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return true;
        }
        return false;
    }

    public bool JumpButtonDown()
    {
        if (Input.GetButtonDown("Jump"))
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

};

