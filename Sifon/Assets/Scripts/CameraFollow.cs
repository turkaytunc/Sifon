using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 cameraFollowPosition;
    private Vector3 cameraDirection;
    private float objectDistance;
    private const float cameraFocusSpeed = 2.5f;

    //Tum fizik ve veri girisi hesaplamalarinin ardinda lateupdate cagrilir
    void LateUpdate()
    {
        ChangeCameraPositioning();      
    }

    //hangi obje takip edilecek ise onun konumunun set edilmesi
    public Vector3 CameraFollowPosition
    {
        set
        {
            cameraFollowPosition = value;
        }
    }
    //Kamera pozisyonunun ayarlanmasi
    private void ChangeCameraPositioning()
    {
        cameraFollowPosition.z = transform.position.z;       
        cameraDirection = (cameraFollowPosition - transform.position).normalized;

        objectDistance = Vector3.Distance(cameraFollowPosition, transform.position);
        transform.position = transform.position + objectDistance * cameraFocusSpeed * cameraDirection * Time.deltaTime;
    }


}
