using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds;

    private GameObject[] backGroundArray;
    private Transform cam;
    private Vector3 previousCamPos;
    private Vector3 backgroundTargetPos;

    private float[] parallaxScale;
    private const float smoothing = 1f;
    private float parallax;
    private float backgroundTargetPosX;

    private void Start()
    {
        cam = Camera.main.transform;

        FillTransformArrays();  
    }

    private void Update()
    {
        if(cam == null)
        {
            cam = Camera.main.transform;
        }
        if(backgrounds[0] == null)
        {
            FillTransformArrays();
        }

        CalculateParallax();
        previousCamPos = cam.position;
    }

    private void CalculateParallax()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallax = (previousCamPos.x - cam.position.x) * parallaxScale[i];//kameranin bir onceki karedeki konumu ve su an ki konumunun cikarilip derinlik ile carpilmasi
            backgroundTargetPosX = backgrounds[i].position.x + parallax; //kaydirilicak miktarin hesaplanmasi
            backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z); // arka planin , kameranin hareketine gore yeniden konumlanmasi icin gerekli vektor hesabi
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);// lineer interpolasyon ile su anki konumdan , gitmesi gereken konuma belli bir hiz ile gecisi
        }
    }

    private void FillTransformArrays()
    {
        backGroundArray = GameObject.FindGameObjectsWithTag("Background");//background ismine sahip objelerin bulunup arraye alinmasi
        
        //bulunan tum background objelerinin transformlarinin arraye aktarilmasi
        for (int i = 0; i < backGroundArray.Length; i++)
        {
            backgrounds[i] = backGroundArray[i].transform;
        }

        previousCamPos = cam.position;
        parallaxScale = new float[backgrounds.Length];

        //arrayimizdeki tum transformlarin derinligini(z yonundeki vektor degeri) bir arraye doldurulmasi
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScale[i] = backgrounds[i].position.z * -1;
        }
    }






}
