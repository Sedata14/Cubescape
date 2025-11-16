using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grue : MonoBehaviour
{

    [SerializeField]
    LayerMask Cube,Remote;


    [SerializeField]
    GameObject HoldZone;
        
    public GameObject CubeObject;

    public RaycastHit hit, Hitpoint;

    public Vector3 fdp;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        

        if(Physics.Raycast(transform.position,-transform.up * 1,out hit,1.8f,Cube))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                CubeObject = hit.transform.gameObject;
            }

            
        }
        

        if (Physics.Raycast(transform.position, -transform.up * 1, out hit,1.8f, Remote))
        {

            if(Input.GetKeyDown(KeyCode.E))
            {
                CubeObject = hit.transform.gameObject;
            }

        }



        if (Physics.Raycast(transform.position, -transform.up * 100, out Hitpoint, 100f))
        {
            fdp = Hitpoint.point;
        }






            if (CubeObject)
            {
                CubeObject.transform.position = HoldZone.transform.position;

            try
            {
                CubeObject.GetComponent<CubeGeneral>().Truc = transform.gameObject;
            }
            catch
            {


                CubeObject.GetComponent<RemoteGeneral>().Truc = transform.gameObject;
            }
            try
            {
                CubeObject.GetComponent<CubeGeneral>().CubeHolder.GetComponent<Make_it>().GotCube = null;
                for (int i = 0; i < CubeObject.GetComponent<CubeGeneral>().CubeHolder.GetComponent<Make_it>().Object.Length; i++)
                {
                    CubeObject.GetComponent<CubeGeneral>().CubeHolder.GetComponent<Make_it>().Object[i].GetComponent<PropMovementGeneral>().CanMove = false;
                }
                
                CubeObject.GetComponent<CubeGeneral>().CubeHolder = null;

            }
            catch
            {
                
            }
            

            if (Input.GetKeyDown(KeyCode.Q))
            {
                
                Dropit();
                    
                }
            }
        }
        
        public void Dropit()
    {
        try
        {
            CubeObject.GetComponent<CubeGeneral>().Truc = null;
        }
        catch
        {
            CubeObject.GetComponent<RemoteGeneral>().Truc = null;
        }
        CubeObject.GetComponent<Collider>().enabled = true;
        CubeObject = null;
    }

    }

