using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PointDetect : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //needs to be deactived and activated again

            Debug.Log("destroyed bobobox");
            //increase point or some other things
            E_PointCounter.instance.IncreasePoint();
            E_Randomize.instance.GameOn();
        }
    }
}
