using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PointDetect : MonoBehaviour
{   
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(GetComponent<BoxCollider2D>());
            Debug.Log("destroyed bobobox");
            //increase point or some other things
            E_PointCounter.instance.IncreasePoint();
        }
    }
}
