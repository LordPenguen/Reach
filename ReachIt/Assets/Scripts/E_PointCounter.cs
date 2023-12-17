using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class E_PointCounter : MonoBehaviour
{
    public static E_PointCounter instance;

    public TMP_Text pointText;
    
    //After everything is done make it private????
    public int currentPoint = 0;
    
    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        pointText.text = "-" + currentPoint.ToString() + "-" ;
    }
  
    public void IncreasePoint()
    {
        currentPoint ++;
        pointText.text = "-" + currentPoint.ToString() + "-" ;
    }
}
