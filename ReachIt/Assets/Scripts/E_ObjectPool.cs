using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ObjectPool : MonoBehaviour
{
    public static E_ObjectPool instance;

    private List<GameObject> pooledBuildingObjects = new List<GameObject>();
    private List<GameObject> pooledCoinObjects = new List<GameObject>();

    private int amountToPool = 10;

    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private GameObject coinPrefab;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(buildingPrefab);
            obj.SetActive(false);
            pooledBuildingObjects.Add(obj);
        }
        for(int j = 0; j < amountToPool; j++)
        {
            GameObject obj = Instantiate(coinPrefab);
            obj.SetActive(false);
            pooledCoinObjects.Add(obj);
        }
    }

    public GameObject GetPooledBuildingObject()
    {
        for (int i = 0; i < pooledBuildingObjects.Count; i++)
        {
            if(!pooledBuildingObjects[i].activeInHierarchy)
            {
                return pooledBuildingObjects[i];
            }
        }
        return null;
    }

    public GameObject GetPooledCoinObject()
    {
        for (int j = 0; j < pooledCoinObjects.Count; j++)
        {
            if(!pooledCoinObjects[j].activeInHierarchy)
            {
                return pooledCoinObjects[j];
            }
        }
        
        return null;
    }
    
}
