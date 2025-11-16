using TMPro;
using UnityEngine;


public class Make_it : MonoBehaviour
{

    public string CollorAccepted, TypeOfPressurePlate;


    public GameObject GotCube;
    public GameObject[] Object;

    

    [SerializeField]
    string TimerPlate, NormalPlate;

    [SerializeField]
    PressurePlateGeneric PPG;

    [SerializeField]
    float TimeRemaining, DefaultTime;

    [SerializeField]
    bool Timer;

    [SerializeField]
    TextMeshProUGUI TimerText;

    [SerializeField]
    AudioClip GoodAnswer, MagicDoorOpen;

    [SerializeField,HideInInspector]
    AudioSource source;



    private void Start()
    {
       source = Camera.main.GetComponent<AudioSource>();    

        TimerPlate = "TimerPlate";
        NormalPlate = "NormalPlate";

        TypeOfPressurePlate = PPG._TypeOfPressurePlate;
    }




    public void ObjectCanMove()
    {
        for (int i = 0; i < Object.Length; i++)
        {
            Object[i].GetComponent<PropMovementGeneral>().CanMove = true;
        }
    }

    public void ObjectCantMove()
    {
        for (int i = 0; i < Object.Length; i++)
        {
            Object[i].GetComponent<PropMovementGeneral>().CanMove = false;
        }
    }

    private void Update()
    {

        if (TypeOfPressurePlate == TimerPlate)
        {
            if (Timer && !GotCube)
            {
                if (TimeRemaining > 0)
                {
                    TimeRemaining -= Time.deltaTime;
                 



                    TimerText.text = "" + Mathf.FloorToInt(TimeRemaining % 60); ;

                }

                else
                {
                    TimerText.text = " ";
                    Timer = false;


                }
            }

            else
            {
                TimerText.text = " ";
            }
        }


        
        if(GotCube)
        {
            ObjectCanMove();



        }

        else
        {
            if(TimeRemaining <= 0)
            {
                ObjectCantMove();
            }
            
        }



    }

    private void OnCollisionEnter(Collision collision)
    {

        try
        {
            if (collision.gameObject.GetComponent<CubeGeneral>().Color == CollorAccepted)
            {


                source.PlayOneShot(GoodAnswer);
                if (TypeOfPressurePlate == NormalPlate)
                {
                    GotCube = collision.gameObject;



                    collision.gameObject.GetComponent<CubeGeneral>().CubeHolder = transform.gameObject;
                    if (!collision.gameObject.GetComponent<CubeGeneral>().CubeHolder)
                    {
                        Debug.Log("Lol");
                    }



                }

                if (TypeOfPressurePlate == TimerPlate)
                {
                    GotCube = collision.gameObject;
                    Timer = false;
                    TimeRemaining = 0;
                }
            }

        }
        catch
        {

        }





    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Cube")
        {
            
          
            if (TypeOfPressurePlate == NormalPlate)
            {



                GotCube = null;



            }

            if (TypeOfPressurePlate == TimerPlate)
            {
                GotCube = null;
                TimeRemaining = DefaultTime;
                Timer = true;
            }
            
            collision.gameObject.GetComponent<CubeGeneral>().CubeHolder = null;
        }


        
        
    }

  





}
