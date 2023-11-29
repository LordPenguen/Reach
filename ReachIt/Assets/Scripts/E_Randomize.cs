using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Randomize : MonoBehaviour
{
    public GameObject buildingPrefab;
    public float height;
    public float width;
    public float speed;
    public Vector3 nextBuildingPosition;
    private float _nextBuildingX;
    private float _nextBuildingY = -3;
    private  float _oldbuildingstartPos = -9;

    void RandomThings()
    {
        //Random building height
        height = Random.Range(0,9);

        //Random building width
        width = Random.Range(6,11);
        
        //Random building speed
        speed = Random.Range(1,3);

        //Debug.Log("Speed ="+ speed);

        //Random spawner point
        // 3-6 sayıları arasında rastgele birini seçip bir sonraki çıkıcak olan binanın X değerine ekle
        //Bir sonraki binayı çıkar
        _nextBuildingX = Random.Range(1,6);

        Debug.Log("Height ="+ height + " Width ="+ width + " NextBuilding ="+ _nextBuildingX);
        
    }

    void SpawnBuilding()
    {
        RandomThings();
        
        nextBuildingPosition = new Vector3( _oldbuildingstartPos + width + _nextBuildingX , _nextBuildingY, 0);

        Instantiate(buildingPrefab, nextBuildingPosition, Quaternion.identity); 

        //Changing the building's width [Vector3.right => (1,0,0)] height  [Vector3.up => (0,1,0)]
        buildingPrefab.transform.localScale = Vector3.right * (1f + width) + Vector3.up * (1f + height);

        _oldbuildingstartPos = nextBuildingPosition.x;

        Debug.Log("Oldbuild = " + _oldbuildingstartPos);
        
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBuilding();
        }
    }


}
    
