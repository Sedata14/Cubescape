using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class Grapin : MonoBehaviour
{
    [SerializeField]
    float Xspeed, Zspeed, ScaleLength, ScaleLimit, GravityLenght;

    [SerializeField]
    GameObject Main,Cable,Camera, Left_Limit, Right_Limit,Gravity;


    [SerializeField]
    float NumberToStop = 0.1f;

    [Header("X and Y Values")]
    [SerializeField]
    string xmovement_string, zmovement_string;

    [SerializeField]
    bool Move1, Move2;

    public GameObject fdp;
    private void Start()
    {
        


    }
    void Update()
    {

       
    }

    public void GrapinController()
    {
        Vector3 CableVec = Cable.transform.position;

        Vector3 ScaleVec = Cable.transform.localScale;

        Vector3 GravityVec = transform.localScale;

        Vector3 Vec = transform.position;

        Vector3 CameraVec = Camera.transform.position;





        // the movements
        float xmovement = Input.GetAxis(xmovement_string) * Xspeed * Time.deltaTime;

        float zmovement = Input.GetAxis(zmovement_string) * Zspeed * Time.deltaTime;

        float GravityLength = Input.GetAxis(xmovement_string) * GravityLenght* Time.deltaTime;

        // the scale
        float ScaleValue = Input.GetAxis(xmovement_string) * ScaleLength * Time.deltaTime;



        float RightDistance = Vector3.Distance(transform.position, Right_Limit.transform.position);

        float LeftDistance = Vector3.Distance(transform.position, Left_Limit.transform.position);

        try
        {
            float JustePourVoir = Vector3.Distance(transform.position, fdp.GetComponent<Grue>().fdp);
        }
        catch
        {
            
        }


        Debug.Log(ScaleValue);

     
        if (Move1)
        {
            if (RightDistance <= NumberToStop && zmovement > 0)
                    
            {
                zmovement = 0;
            }

            else if (LeftDistance <= NumberToStop && zmovement < 0)
            {
                zmovement = 0;
            }
        }

        if (Move2)
        {
            if (RightDistance <= NumberToStop && zmovement < 0)
            {
                zmovement = 0;
            }

            else if (LeftDistance <= NumberToStop && zmovement > 0)
            {
                zmovement = 0;
            }
        }


        if (ScaleVec.x <= 1 && ScaleValue > 0)
        {
            ScaleValue = 0;
            xmovement = 0;

        }

        if (ScaleVec.x >= ScaleLimit && ScaleValue < 0)
        {
            ScaleValue = 0;
            xmovement = 0;


        }


        
        if (Move1)
        {
            CableVec.z += zmovement;

            CameraVec.z += zmovement;

            CableVec.y += xmovement;

            Vec.z += zmovement;

            GravityVec.z += GravityLenght/1000 -1;


            
        }

        if (Move2)
        {
            CableVec.x += zmovement;

            CameraVec.x += zmovement;

            CableVec.y += xmovement;

            Vec.x += zmovement;
        }

        CameraVec.y += xmovement;

        ScaleVec.x -= ScaleValue;


  
        transform.position = Vec;
        Main.transform.position = new Vector3(CableVec.x + ScaleValue, CableVec.y, CableVec.z);
        Cable.transform.localScale = ScaleVec;
        Cable.transform.position = CableVec;
        Camera.transform.position = CameraVec;
        Gravity.transform.localScale = GravityVec;
        
    }
}
