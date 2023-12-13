using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class E_Randomize : MonoBehaviour
{
    public GameObject buildingPrefab;
    public Camera mainCamera;
    [System.NonSerialized] public float height;
    [System.NonSerialized] public float endPointy;
    [System.NonSerialized] public float width;
    [System.NonSerialized] public float speed;
    [System.NonSerialized] public Vector3 nextBuildingPosition;
    private float _nextBuildingX;
    private float _nextBuildingY = -5f;
    [System.NonSerialized] private  float _oldbuildingstartPosX = -9;

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
    void SpawnBuilding()
    {
        RandomThings();
        
        nextBuildingPosition = new Vector3( _oldbuildingstartPosX + width + _nextBuildingX , _nextBuildingY, 0);

        // Convert the random position to world coordinates
        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(nextBuildingPosition);

        //Debug.Log("worldposition" + worldPosition);

        //if(IsInCameraView(worldPosition))
       // {
            var buildingInstance = Instantiate(buildingPrefab, nextBuildingPosition, Quaternion.identity); 

            SetPivotToTop(buildingInstance.transform);

            buildingInstance.transform.DOMoveY(endPointy, speed);

            //Changing the building's width [Vector3.right => (1,0,0)] height  [Vector3.up => (0,1,0)]
            buildingInstance.transform.localScale = Vector3.right * width + Vector3.up * (6f);
       // }

        _oldbuildingstartPosX = nextBuildingPosition.x;

       // yield return new WaitForSeconds(.1f);

    }

    bool IsInCameraView(Vector3 bPosition)
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(bPosition);

        return viewportPosition.x >= -1 && viewportPosition.x <= 1 && viewportPosition.y >= -1 && viewportPosition.y <= 1;
    }

    void SetPivotToTop(Transform transform)
    {
        Vector3 topPosition = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z);

        transform.position = topPosition;
     }


    void Update() 
    {

        if(Input.GetKeyDown("space"))
        {
            SpawnBuilding();
        }
       //StartCoroutine(SpawnBuilding());
    }
}
    
