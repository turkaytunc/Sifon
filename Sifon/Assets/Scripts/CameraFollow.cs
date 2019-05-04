using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 cameraFollowPosition;
    private PlayerMovementControl playerMovement;
    private Vector3 cameraDirection;
    private float objectDistance;
    private const float cameraFocusSpeed = 2.5f;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementControl>();
    }

    //Tum fizik ve veri girisi hesaplamalarinin ardinda lateupdate cagrilir
    void LateUpdate()
    {
        cameraFollowPosition = playerMovement.transform.position;
        ChangeCameraPositioning();      
    }

    
    //Kamera pozisyonunun ayarlanmasi
    private void ChangeCameraPositioning()
    {
        cameraFollowPosition.z = transform.position.z;//kameranin z koorinatindaki konumu surekli koru     
        cameraDirection = (cameraFollowPosition - transform.position).normalized;//

        objectDistance = Vector3.Distance(cameraFollowPosition, transform.position);
        transform.position = transform.position + objectDistance * cameraFocusSpeed * cameraDirection * Time.deltaTime;
    }


}
