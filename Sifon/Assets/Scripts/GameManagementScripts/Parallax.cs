using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject[] gameObjects;
    public Transform[] backgrounds;
    private Transform camTransform;
    private Vector3 previousCamPos;
    private Vector3 backgroundTargetPos;
    public GameObject game;

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
        if (backgrounds[0] == null)
        {
            FillTransformArrays();
        }

        CalculateParallax();
        previousCamPos = camTransform.position;
    }

    private void CalculateParallax()
    {
        if(backgrounds != null)
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                parallax = (previousCamPos.x - camTransform.position.x) * parallaxScale[i];//kameranin bir onceki karedeki konumu ve su an ki konumunun cikarilip derinlik ile carpilmasi
                backgroundTargetPosX = backgrounds[i].position.x + parallax; //kaydirilicak miktarin hesaplanmasi
                backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z); // arka planin , kameranin hareketine gore yeniden konumlanmasi icin gerekli vektor hesabi
                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);// lineer interpolasyon ile su anki konumdan , gitmesi gereken konuma belli bir hiz ile gecisi
            }

        }
        
       
    }

    private void FillTransformArrays()
    {
        camTransform = Camera.main.transform;
        if (GameObject.FindGameObjectWithTag("Background") == null)
        {
            Instantiate(game, transform.position, Quaternion.identity);
        }
        gameObjects = new GameObject[3];
        gameObjects = GameObject.FindGameObjectsWithTag("Background");
        backgrounds = new Transform[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            backgrounds[i] = gameObjects[i].transform;
        }

        previousCamPos = camTransform.position;
        parallaxScale = new float[backgrounds.Length];
        

        //tum arkaplan transformlarinin derinliklerinin(konum vektorunun z yonundeki degeri) bir diziye doldurulmasi
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScale[i] = backgrounds[i].position.z * -1;
        }
    }






}
