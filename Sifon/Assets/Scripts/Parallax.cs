using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds;
    private Transform camTransform;
    private Vector3 previousCamPos;
    private Vector3 backgroundTargetPos;

    private float[] parallaxScale;
    private const float smoothing = 1f;
    private float parallax;
    private float backgroundTargetPosX;

    private void Start()
    {
        camTransform = Camera.main.transform;
        
        FillTransformArrays();  
    }

    private void Update()
    {

        if (camTransform == null)
        {
            camTransform = Camera.main.transform;
        }
        if (backgrounds == null)
        {
            FillTransformArrays();
        }

        CalculateParallax();
        previousCamPos = camTransform.position;
    }

    private void CalculateParallax()
    {
        
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallax = (previousCamPos.x - camTransform.position.x) * parallaxScale[i];//kameranin bir onceki karedeki konumu ve su an ki konumunun cikarilip derinlik ile carpilmasi
            backgroundTargetPosX = backgrounds[i].position.x + parallax; //kaydirilicak miktarin hesaplanmasi
            backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z); // arka planin , kameranin hareketine gore yeniden konumlanmasi icin gerekli vektor hesabi
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);// lineer interpolasyon ile su anki konumdan , gitmesi gereken konuma belli bir hiz ile gecisi
        }
    }

    private void FillTransformArrays()
    {
        
        previousCamPos = camTransform.position;
        parallaxScale = new float[backgrounds.Length];
        

        //tum arkaplan transformlarinin derinliklerinin(konum vektorunun z yonundeki degeri) bir diziye doldurulmasi
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScale[i] = backgrounds[i].position.z * -1;
        }
    }






}
