using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public
    AudioSource Music1,Music2,Music3;

   


    

    // Update is called once per frame
    void Update()
    {
       

        if(!Music1.isPlaying && !Music2.isPlaying && !Music2.isPlaying)
        {
            int i = Random.Range(1, 3);

            if(i == 1)
            {
                Music1.Play();
            }

            else if(i == 2)
            {
                Music2.Play();
            }

            else if(i == 3)
            {
                Music3.Play();
            }

        }







    }
}
