using System.Collections;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

public class E_Randomize : MonoBehaviour
{
    public static E_Randomize instance;
    public GameObject buildingPrefab;
    public GameObject coinPrefab;
    [System.NonSerialized] public float height;
    [System.NonSerialized] public float endPointy;
    [System.NonSerialized] public float width;
    [System.NonSerialized] public float speed;
    [System.NonSerialized] public Vector3 nextBuildingPosition;
    [System.NonSerialized] public Vector3 nextCoinPosition;
    private float _nextBuildingX;
    private float _nextBuildingY = -10f;
    [System.NonSerialized] private  float _oldbuildingstartPosX = -9;

    private void Awake() 
    {
        instance = this;
    }

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

        //Space between two buildingss
        _nextBuildingX = Random.Range(3,7);

        //Debug.Log("Height =" + height + " Width =" + width + " NextBuilding =" + _nextBuildingX);
        
    }

    //After testing it change it back to IEnumerator and tryout spawn times
    public void SpawnBuilding()
    {
        RandomThings();
        
        nextBuildingPosition = new Vector3( _oldbuildingstartPosX + width + _nextBuildingX , _nextBuildingY, 0);

        //height is broken
        nextCoinPosition = new Vector3(nextBuildingPosition.x, endPointy + height/2 , 0);
        
        //var buildingInstance = Instantiate(buildingPrefab, nextBuildingPosition, Quaternion.identity); 

        //tryingg to take it from pool
        GameObject buildingInstance = E_ObjectPool.instance.GetPooledBuildingObject();

        GameObject coinInstance = E_ObjectPool.instance.GetPooledCoinObject();


        if(buildingInstance != null )
        {
            buildingInstance.transform.position = nextBuildingPosition;
            buildingInstance.SetActive(true);

            coinInstance.transform.position = nextCoinPosition;
            coinInstance.SetActive(true);

            buildingInstance.transform.DOMoveY(endPointy, speed);

            //Changing the building's width [Vector3.right => (1,0,0)] height  [Vector3.up => (0,1,0)]
            buildingInstance.transform.localScale = Vector3.right * width + Vector3.up * (6f);

            _oldbuildingstartPosX = nextBuildingPosition.x;
        }
        //yield return new WaitForSeconds(.1f);
    }
    
    // if points are "this much" double, triple, quadraple...

    //instantiate problem.... if jumped on one buildig instantiate next two... if its "this much" point instantiate three...
    public void GameOn()
    {
        if(E_PointCounter.instance.currentPoint <= 10)
        {
            SpawnBuilding();
        }
        else
        {
            SpawnBuilding();
            SpawnBuilding();
        }
        
    }
   

}
    
