using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;
using UnityEngine.UIElements;

public class E_Randomize : MonoBehaviour
{
    public static E_Randomize instance;
    public GameObject buildingPrefab;
    public Camera mainCamera;
    [System.NonSerialized] public float height;
    [System.NonSerialized] public float endPointy;
    [System.NonSerialized] public float width;
    [System.NonSerialized] public float speed;
    [System.NonSerialized] public Vector3 nextBuildingPosition;
    private float _nextBuildingX;
    private float _nextBuildingY = -10f;
    [System.NonSerialized] private  float _oldbuildingstartPosX = -9;

    public GameObject Player;

    private int _length;


    void RandomThings()
    {
        //Random building height
        height = Random.Range(5,11);

        //Random Ending point.Y
        endPointy = Random.Range(-1,3);

        //Random building width
        width = Random.Range(5,10);
        
        //Random building speed
        speed = Random.Range(3,6);

        //Space between two buildings
        _nextBuildingX = Random.Range(3,7);

        Debug.Log("Height =" + height + " Width =" + width + " NextBuilding =" + _nextBuildingX);
        
    }

    //After testing it change it back to IEnumerator and tryout spawn times
    public void SpawnBuilding()
    {
        RandomThings();
        
        nextBuildingPosition = new Vector3( _oldbuildingstartPosX + width + _nextBuildingX , _nextBuildingY, 0);

       
        var buildingInstance = Instantiate(buildingPrefab, nextBuildingPosition, Quaternion.identity); 

        buildingInstance.transform.DOMoveY(endPointy, speed);

        //Changing the building's width [Vector3.right => (1,0,0)] height  [Vector3.up => (0,1,0)]
        buildingInstance.transform.localScale = Vector3.right * width + Vector3.up * (6f);
       

        _oldbuildingstartPosX = nextBuildingPosition.x;

       // yield return new WaitForSeconds(.1f);

    }

    //if out of camera view destroy

    // if points are "this much" double, triple, quadraple...

    //instantiate problem.... if jumped on one buildig instantiate next two... if its "this much" point instantiate three...
    public void GameOn()
    {

        SpawnBuilding();
        
    }
   

}
    
