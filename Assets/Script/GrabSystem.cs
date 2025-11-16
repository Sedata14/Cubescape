using System.Collections;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{

    public LayerMask RespawnCubesLayerMask;

    [SerializeField]
    Transform CubeHolder;

    public
    GameObject Cube;

    [SerializeField]
    bool FDP;

    [SerializeField]
    LayerMask CubeLayerMask, CubePressureLayerMask;


    [SerializeField, HideInInspector]
    AudioSource source;

    [SerializeField]
    AudioClip WrongAnswer;


    void Start()
    {
        source = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {


        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 2f, CubeLayerMask))
        {

            if (Input.GetKeyDown(KeyCode.E) && hit.transform.GetComponent<CubeGeneral>().CanBeTaken)
            {


                if (Cube != null)
                {
                    DropCube(Cube);
                    Cube = null;
                    Cube = hit.transform.gameObject;
                    StartCoroutine(GrabCube(Cube));
                }
                else
                {

                    Cube = hit.transform.gameObject;
                    StartCoroutine(GrabCube(Cube));
                }


            }
        }

        else
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 2f, CubePressureLayerMask))
            {

                if (hit.transform.GetComponent<Make_it>().GotCube == null)
                {

                    if (Cube)
                    {
                        if (hit.transform.GetComponent<Make_it>().CollorAccepted == Cube.GetComponent<CubeGeneral>().Color)
                        {
                            if (Input.GetKeyDown(KeyCode.E))
                            {

                                Cube.GetComponent<BoxCollider>().isTrigger = false;
                                Cube.transform.position = hit.transform.position;
                                Cube = null;



                            }


                        }

                        else
                        {
                            if (Input.GetKeyDown(KeyCode.E))
                            {
                                source.PlayOneShot(WrongAnswer);
                            }
                        }

                        


                    }

                  

                    
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {

                        hit.transform.GetComponent<Make_it>().GotCube = null;
                        if (hit.transform.GetComponent<Make_it>().TypeOfPressurePlate == "NormalPlate")
                        {
                            for(int i = 0;i < hit.transform.GetComponent<Make_it>().Object.Length; i++)
                            {
                                hit.transform.GetComponent<Make_it>().Object[i].GetComponent<PropMovementGeneral>().CanMove = false;
                            }
                            
                        }



                    }


                }


            }

        }
       

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1.8f, RespawnCubesLayerMask))
        {
            if (Cube == null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                   
                    hit.transform.gameObject.GetComponent<RespawnCube>().RespawCube(hit.transform.GetComponent<RespawnCube>().Cubes);
                    
                }
            }
        }



        if (Cube != null)

        {


            Cube.transform.position = CubeHolder.transform.position;






            if (Input.GetKeyDown(KeyCode.G))
            {
                DropCube(Cube);

                Cube = null;

            }
        }
    
        


        
       

     IEnumerator GrabCube(GameObject objecto)
        {


           

            yield return new WaitForSeconds(0f);
            objecto.GetComponent<BoxCollider>().isTrigger = true;




        }
    }

       
    public void DropCube(GameObject objecto)
    {
        objecto.GetComponent<Rigidbody>().AddForce(0, 2, 0, ForceMode.Force);
        objecto.GetComponent<BoxCollider>().isTrigger = false;
      


    }
}
