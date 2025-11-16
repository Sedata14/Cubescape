
using UnityEngine;

public class MoveProps : MonoBehaviour
{
    [SerializeField]
    LayerMask MovableCube;

    [SerializeField]
    GameObject FollowPoint,CurrentPropHolding;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray.origin,ray.direction,out hit,100, MovableCube))
        {
     

           // CurrentPropHolding = hit.transform.gameObject;
        }


       /* if (CurrentPropHolding)
        {
            CubeFollowHitPoint(CurrentPropHolding, FollowPoint);
        }
       */
        Debug.DrawRay(ray.origin,ray.direction * 100,Color.yellow);
    }

    private void CubeFollowHitPoint(GameObject Prop,GameObject Follow)
    {
        Prop.transform.position = Vector3.MoveTowards(Prop.transform.position,Follow.transform.position,1);

    }


}