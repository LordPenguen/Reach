using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RepurposeBuildin : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.CompareTag("Wall"))
    {
      gameObject.SetActive(false);
      Debug.Log("destroying the");
    }
  }
}
