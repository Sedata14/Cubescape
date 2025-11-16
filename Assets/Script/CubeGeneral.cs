using UnityEngine;

public class CubeGeneral : MonoBehaviour
{
    public CubeGeneric cubeGeneric;

    public string Color;

    public bool CanBeTaken;

    public GameObject RespawnCubeParent, Truc,CubeHolder;


    
    private void Start()
    {
        Color = cubeGeneric._Color;
        CanBeTaken = true;
        
    }
}
