using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds;
    public  float smoothing = 1f;

    private GameObject[] backGroundArray;
    private float[] parallaxScale;
    private Transform cam;
    private Vector3 previousCamPos;
    private float parallax;
    private Vector3 backgroundTargetPos;
    private float backgroundTargetPosX;

    private void Start()
    {
        cam = Camera.main.transform;

        backGroundArray = GameObject.FindGameObjectsWithTag("Background");

        for (int i = 0; i < backGroundArray.Length; i++)
        {
            backgrounds[i] = backGroundArray[i].transform;
        }

        previousCamPos = cam.position;

        parallaxScale = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScale[i] = backgrounds[i].position.z * -1;
        }
    }

    private void Update()
    {
        if(cam == null)
        {
            cam = Camera.main.transform;
        }
        if(backgrounds[0] == null)
        {
            backGroundArray = GameObject.FindGameObjectsWithTag("Background");

            for (int i = 0; i < backGroundArray.Length; i++)
            {
                backgrounds[i] = backGroundArray[i].transform;
            }

            previousCamPos = cam.position;

            parallaxScale = new float[backgrounds.Length];

            for (int i = 0; i < backgrounds.Length; i++)
            {
                parallaxScale[i] = backgrounds[i].position.z * -1;
            }
        }
        

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallax = (previousCamPos.x - cam.position.x) * parallaxScale[i];

            backgroundTargetPosX = backgrounds[i].position.x + parallax;

            backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }






}
