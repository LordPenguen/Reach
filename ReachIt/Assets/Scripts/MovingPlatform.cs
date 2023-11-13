using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingPlatform : MonoBehaviour
{

    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    //public float speed = 1.5f;
    public float speed = Random.Range(1, 5);
    private float elapsedTime;
    
    //public float randomladım = Random.Range(1, 5);
    
    private int direction = 1;
    // movement
    private void Update()
    {

        Vector2 target = currentMovementTarget();
        
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / speed;

        //platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);
        platform.position = Vector2.Lerp(endPoint.position, startPoint.position , percentageComplete);

    }

    Vector2 currentMovementTarget()
    {
        
        
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (platform!=null && startPoint!=null && endPoint!=null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }
}
