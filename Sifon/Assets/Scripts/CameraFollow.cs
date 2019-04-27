using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 cameraFollowPosition;
    private Vector3 cameraDirection;
    private float objectDistance;
    private float cameraFocusSpeed = 2f;



    
   
    void Update()
    {
        cameraFollowPosition.z = transform.position.z;

        cameraDirection = (cameraFollowPosition - transform.position).normalized;

        objectDistance = Vector3.Distance(cameraFollowPosition, transform.position);
        

        transform.position = transform.position + objectDistance * cameraFocusSpeed * cameraDirection * Time.deltaTime;
        
    }


    public Vector3 CameraFollowPosition
    {
        get
        {
            return cameraFollowPosition;
        }

        set
        {
            cameraFollowPosition = value;
        }
    }


}
