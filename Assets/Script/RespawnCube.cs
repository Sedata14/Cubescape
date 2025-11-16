using MenteBacata.ScivoloCharacterControllerDemo;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCube : MonoBehaviour
{
    
    public List<GameObject> Cubes = new List<GameObject>();

    public
    GameObject SpawnPoint,AvailableCubes;

    [SerializeField]
    AudioClip respawnCubeSound;

    [SerializeField, HideInInspector]
    AudioSource source;

    [SerializeField]
    bool RandomRange;

    [SerializeField]
    GameObject Player;
    public void Start()
    {

        source = Camera.main.GetComponent<AudioSource>();

        if(AvailableCubes)
        {
            for (int i = 0; i < AvailableCubes.transform.childCount; i++)
            {
                Cubes.Add(AvailableCubes.transform.GetChild(i).gameObject);
            }
        }

    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            other.gameObject.GetComponent<SimpleCharacterController>().RespawnCubeParent = transform.gameObject;
            Player = other.gameObject;
        }
    }

    public void RespawCube(List<GameObject> Cubes)
    {


        source.PlayOneShot(respawnCubeSound);
        if (RandomRange)
        {
            for (int i = 0; i < Cubes.Count; i++)
            {

                Cubes[i].transform.position = new Vector3(Random.Range(SpawnPoint.transform.position.x - 2, SpawnPoint.transform.position.x + 2), SpawnPoint.transform.position.y + 1, Random.Range(SpawnPoint.transform.position.z - 2, SpawnPoint.transform.position.z + 2));
            }
        }

        else
        {
            for (int i = 0; i < Cubes.Count; i++)
            {

                Cubes[i].transform.position = new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, SpawnPoint.transform.position.z);
            }
        }
    }

    public void PlayerRespawn()
    {
       

        Player.transform.position = SpawnPoint.transform.position;
    }
}
