
using MenteBacata.ScivoloCharacterControllerDemo;
using System.Collections;
using System.IO;
using UnityEngine;


public class Teleportation : MonoBehaviour
{
    [SerializeField]
    Transform NextPortal;


    [SerializeField]
    GameObject World;

    [SerializeField,HideInInspector]
    AudioSource source;

    [SerializeField]
    AudioClip TeleportationSound, DeadSound;



    private void Start()
    {

        source = Camera.main.GetComponent<AudioSource>();
    }
    private void OnTriggerStay(Collider other)
    {

        
        StartCoroutine(Teleport(other.gameObject));
        
        

        

       

    }

 

    private void OnCollisionEnter(Collision collision)
    {



        if(collision.gameObject.tag == "Cube")
        {
         

            if (collision.gameObject.GetComponent<CubeGeneral>().CubeHolder)
            {
                Debug.Log("mdrr");
                Physics.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider>(), GetComponent<BoxCollider>());
            }
            else { 

               
                try
                {
                    collision.gameObject.GetComponent<CubeGeneral>().Truc.GetComponent<Grue>().Dropit();
                }

                catch
                {

                }
                finally
                {
                    Debug.Log("Et c'est l'histoirekk");
                    collision.gameObject.GetComponent<CubeGeneral>().RespawnCubeParent.GetComponent<RespawnCube>().RespawCube(collision.gameObject.GetComponent<CubeGeneral>().RespawnCubeParent.GetComponent<RespawnCube>().Cubes);
                }
            }


            

            

            

           
           
        }

        else if(collision.gameObject.tag == "Remote")
        {
            
            if (collision.gameObject.GetComponent<RemoteGeneral>().Truc)
            {
                
                collision.gameObject.GetComponent<RemoteGeneral>().Truc.GetComponent<Grue>().Dropit();
            }
            collision.gameObject.GetComponent<RemoteGeneral>().RespawnRemoteParent.GetComponent<RespawnCube>().RespawCube(collision.gameObject.GetComponent<RemoteGeneral>().RespawnRemoteParent.GetComponent<RespawnCube>().Cubes);

        }

        else
        {
            
         
              
           
            if(collision.gameObject.CompareTag("Player"))
            {
          
                GameObject Cube = Camera.main.GetComponent<GrabSystem>().Cube;

                GameObject remote = Camera.main.GetComponent<RemoteController>().HaveRemote;

                source.PlayOneShot(DeadSound);

                if (Cube != null)
                {


                    // Camera.main.GetComponent<GrabSystem>().DropCube(Cube);
                    Camera.main.GetComponent<GrabSystem>().Cube.GetComponent<BoxCollider>().isTrigger = false;
                    Camera.main.GetComponent<GrabSystem>().Cube.GetComponent<CubeGeneral>().RespawnCubeParent.GetComponent<RespawnCube>().RespawCube(Camera.main.GetComponent<GrabSystem>().Cube.GetComponent<CubeGeneral>().RespawnCubeParent.GetComponent<RespawnCube>().Cubes);
                    Camera.main.GetComponent<GrabSystem>().Cube = null;

                }

                if (remote != null)
                {
                    
                    Camera.main.GetComponent<RemoteController>().DropRemote(remote);
                    Camera.main.GetComponent<RemoteController>().HaveRemote = null;

                }

                collision.gameObject.GetComponent<SimpleCharacterController>().RespawnCubeParent.GetComponent<RespawnCube>().PlayerRespawn();
                
             
            }
        }
        
    }

    IEnumerator Teleport(GameObject Playyer )
    {
        try
        {
            Playyer.transform.position = NextPortal.position;
            source.PlayOneShot(TeleportationSound);

        }
        catch
        {

        }
            yield return new WaitForSeconds(1f);
            Destroy(World.gameObject);



    }

    void Respawn(GameObject Player)
    {
        Player.transform.position = NextPortal.position;
    }
}
