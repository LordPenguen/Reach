using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PointCoin : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            E_PointCounter.instance.IncreasePoint();
            gameObject.SetActive(false);
        }
    }
}
