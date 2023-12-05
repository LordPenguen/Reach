using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class E_Randomize : MonoBehaviour
{
    public GameObject buildingPrefab;
    [System.NonSerialized] public float height;
    [System.NonSerialized] public float width;
    [System.NonSerialized] public float speed;
    [System.NonSerialized] public Vector3 nextBuildingPosition;
    private float _nextBuildingX;
    private float _nextBuildingY = -10f;
    [System.NonSerialized] private  float _oldbuildingstartPosX = -9;

    void RandomThings()
    {
        //Random building height
        height = Random.Range(1,9);

        //Random building width
        width = Random.Range(5,10);
        
        //Random building speed
        speed = Random.Range(5,11);

        //Space between two buildings
        _nextBuildingX = Random.Range(3,6);

        Debug.Log("Height =" + height + " Width =" + width + " NextBuilding =" + _nextBuildingX);
        
    }

    void SpawnBuilding()
    {
        RandomThings();
        
        nextBuildingPosition = new Vector3( _oldbuildingstartPosX + width + _nextBuildingX , _nextBuildingY, 0);

        Instantiate(buildingPrefab, nextBuildingPosition, Quaternion.identity); 

        buildingPrefab.transform.DOMoveY(height + 5f , 1f);

        //Changing the building's width [Vector3.right => (1,0,0)] height  [Vector3.up => (0,1,0)]
        buildingPrefab.transform.localScale = Vector3.right * width + Vector3.up * (5f + height);

        

        _oldbuildingstartPosX = nextBuildingPosition.x;

        

    }


    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBuilding();
        }
    }
}
    
