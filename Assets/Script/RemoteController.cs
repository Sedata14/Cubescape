using MenteBacata.ScivoloCharacterControllerDemo;
using System;
using System.Collections;

using UnityEngine;


public class RemoteController : MonoBehaviour
{
    [Header("LayerMask")]
    [SerializeField]
    LayerMask Remote;


    [Header("GameObject")]
    [SerializeField]
    GameObject RemoteHolder;
        
    public
    GameObject HaveRemote;


    [Header("Scripts")]
    [SerializeField]
    GrabSystem GrabSystem;

    [SerializeField]
    Grapin grapin;

    [SerializeField]
    SimpleCharacterController SCC;

    [SerializeField]
    UI ui;

    

    [Header("Floats")]
    [SerializeField]
    float xRoat, yRoat,xPos,yPos,LastSens;


    [SerializeField, HideInInspector]
    Vector3 TransformPositionOrigin;

    [Header("AudioClip")]
    [SerializeField]
    AudioClip ButtonClick,RemoteOn;

    [SerializeField, HideInInspector]
    bool isClicked, GrapinControll = false;



    void Start()
    {
        LastSens = GetComponent<OrbitingCamera>().sensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

       

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1.8f, Remote))
        {

            if (Input.GetMouseButton(0) && !HaveRemote && !GrabSystem.Cube)
            {
                HaveRemote = hit.transform.gameObject;
                StartCoroutine(GrabRemote(HaveRemote));
                
            }

        }

     
      



        if(HaveRemote) 
        
        {
            grapin = HaveRemote.GetComponent<RemoteGeneral>().Grapin;


            if (GrapinControll)
            {
                GetComponent<OrbitingCamera>().sensitivity = 0;
                if (Input.GetKeyDown(KeyCode.G))
                {
                    GetComponent<OrbitingCamera>().sensitivity = LastSens;
                    GrapinControll = false;
                    StartCoroutine(AssignRemote(HaveRemote));
                    HaveRemote.GetComponent<Animator>().Play("PressedButton_Reversed");
                    isClicked = false;

                    

                }
            }

            else
            {
              

                if (Input.GetKeyDown(KeyCode.G))
                {
                    
                    GrapinControll = false;
                    DropRemote(HaveRemote);
                    HaveRemote.GetComponent<Animator>().Play("PressedButton_Reversed");
                    isClicked = false;
                  //  HaveRemote.GetComponent<BoxCollider>().isTrigger = false;
                    HaveRemote = null;


                }

                StartCoroutine(RemoveActivation(HaveRemote));
            }

                


             



        }



        if (GrapinControll)
        {
            
            grapin.GrapinController();
            
            GetComponent<OrbitingCamera>().sensitivity = 0f;
            SCC.moveSpeed = 0f;

            // Change cameras
            GetComponent<OrbitingCamera>().target = null;
            if (HaveRemote)
            {
                GameObject Player = GameObject.FindGameObjectWithTag("Player").gameObject;
                transform.SetPositionAndRotation(HaveRemote.GetComponent<RemoteGeneral>().Camera.transform.position, HaveRemote.GetComponent<RemoteGeneral>().Camera.transform.rotation);
                HaveRemote.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

            }

        }

        else
        {

            
            SCC.moveSpeed = 7f ;
            GetComponent<OrbitingCamera>().target = GameObject.FindGameObjectWithTag("Player").transform;

            if(HaveRemote)
            {
                HaveRemote.transform.SetPositionAndRotation(new Vector3(RemoteHolder.transform.position.x - xPos, RemoteHolder.transform.position.y - yPos, RemoteHolder.transform.position.z), Quaternion.Euler(transform.eulerAngles.x - xRoat, transform.eulerAngles.y - yRoat, 0f));

            }
            // Change cameras


        }


    }

    

    IEnumerator RemoveActivation(GameObject remote)
    {
        if (remote)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                remote.GetComponent<Animator>().Play("PressedButton");

                
                if (!isClicked)
                {
                    
                    GetComponent<AudioSource>().PlayOneShot(ButtonClick);
                    yield return new WaitForSeconds(1);
                    GetComponent<AudioSource>().PlayOneShot(RemoteOn);
                    isClicked = true;
                    GrapinControll = true;
                    LastSens = GetComponent<OrbitingCamera>().sensitivity;

                }
            }
        }
    }
    IEnumerator GrabRemote(GameObject objecto)
    {


        yield return new WaitForSeconds(0f);
        objecto.GetComponent<BoxCollider>().isTrigger = true;




    }

    public void DropRemote(GameObject objecto)
    {
      
        objecto.GetComponent<BoxCollider>().isTrigger = false;
        objecto = null;

    }

    IEnumerator AssignRemote(GameObject remote)
    {
        yield return new WaitForSeconds(1f);

        remote.transform.SetPositionAndRotation(transform.position,transform.rotation);
      

       

    }
}

