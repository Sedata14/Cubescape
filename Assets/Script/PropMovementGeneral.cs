using System.Collections.Generic;
using UnityEngine;

public class PropMovementGeneral : MonoBehaviour
{
    [SerializeField]
    PropsMovementGeneric PMG;

    [SerializeField]
    float Speed,TimeRemaining;

    [SerializeField]
    bool fdp;

    [SerializeField]
    GameObject NextPoint;

    [SerializeField]
    List<GameObject> objects = new List<GameObject>();

    


    Vector3 DefaultPoint;

    public string TypeOfMovement;

    public bool CanMove;


    void Start()
    {
        TypeOfMovement = PMG._TypeOfMovement;
        DefaultPoint = transform.position;


        if(TypeOfMovement == "MovingWall")
        {
            NextPoint = transform.parent.transform.GetChild(1).gameObject;

        }


        for (int i = 0; i < transform.childCount; i++)
        {

            objects.Add(transform.GetChild(i).gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if(TypeOfMovement == "MovingWall")
        {
            if (transform.position != NextPoint.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, NextPoint.transform.position, Speed * Time.deltaTime);

            }
            else
            {
                transform.position = DefaultPoint;
            }

        }

        if (CanMove)
        {
            if (TypeOfMovement == "Movement")
            {

                    NextPointMovement(NextPoint);
                  
            }

            if (TypeOfMovement == "SpawnObjects")
            {
                
                
                    SpawnObjects(objects);

                
            }

            
        }

        else
        {
            if(TypeOfMovement == "Movement")
            {
                DefaultPointMovement(DefaultPoint);
            }

            if (TypeOfMovement == "SpawnObjects")
            {

                UnSpawn(objects);
            }
        }
        


        
    }

    

    /*IEnumerator MovingWall()
    {
        
        if(transform.position != NextPoint.transform.position) 
        {
            transform.position = Vector3.MoveTowards(transform.position,NextPoint.transform.position,Speed * Time.deltaTime);
            
        }

        else
        {
            transform.GetComponent<BoxCollider>().isTrigger = true;
            transform.GetComponent<MeshRenderer>().enabled = false;

            yield return new WaitForSeconds(2f);

        }
    }
    */

    public void NextPointMovement(GameObject Object)
    {
        transform.position = Vector3.MoveTowards(transform.position,Object.transform.position, Speed * Time.deltaTime);

    }

    public void DefaultPointMovement(Vector3 vec)
    {
        transform.position = Vector3.MoveTowards(transform.position, vec, Speed * Time.deltaTime);
    }


    public void SpawnObjects(List<GameObject> objects)
    {
        for(int i  = 0; i < objects.Count; i++)
        {
            
            objects[i].gameObject.SetActive(true);
            
        }
    }
    
    public void UnSpawn(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {

            objects[i].gameObject.SetActive(false);
        }
    }

   

}
