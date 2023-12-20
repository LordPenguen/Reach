using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PointDetect : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //spawn
            E_Randomize.instance.GameOn();
        }
    }
}
