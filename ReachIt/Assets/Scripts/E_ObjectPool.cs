using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ObjectPool : MonoBehaviour
{
    public static E_ObjectPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();

    private int amountToPool = 10;

    [SerializeField] private GameObject buildingPrefab;

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
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
    
}
