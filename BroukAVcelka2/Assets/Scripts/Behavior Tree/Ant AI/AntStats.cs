using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntStats : MonoBehaviour
{
    public const int playerLayerMask = 1 << 6;
    public Vector3 lastKnownPlayerPosition;

    public static float randomSearchRadius = 60.0f;

    public static float maxStorageCapacity = 100.0f;
    public float currentStorageUsage;

    public bool playerInSight;
    public float maxAlertLevel = 2.0f;
    public float currentAlertLevel = 0.0f;

    [Range(-1.0f,1.0f)]
    public float dotProductFOV = -0.2f;
    public float rangeFOV = 5.0f;
    public Vector3 headOffset = new Vector3 (0.0f, 1.1f, 1.1f);
    public float rotateTowardsSpeed = 1.0f;
    


    /*private void Update()
    {
        if (playerInSight && currentAlertLevel < maxAlertLevel)
        {
            currentAlertLevel += Time.deltaTime;
            float singleStep = rotateTowardsSpeed * Time.deltaTime;
            //Vector3 forwardDirection = Vector3.R
            Vector3.forward = Vector3.RotateTowards(Vector3.forward, )
        }
    }*/

    public bool IsFOVObstructed(Vector3 targetPosition)
    {
        bool isFOVObstructed = Physics.Raycast(transform.position + transform.TransformPoint(headOffset), targetPosition, rangeFOV, playerLayerMask);
        Debug.DrawRay(transform.position + transform.TransformPoint(headOffset), targetPosition, Color.yellow, 1);
        return isFOVObstructed;
    }

    public float Alert(bool isRising, Vector3 targetPosition)
    {
        if (isRising)
        {
            currentAlertLevel += Time.deltaTime;
            float singleStep = rotateTowardsSpeed * Time.deltaTime;
            //Vector3 forwardDirection = Vector3.R
            transform.forward = Vector3.RotateTowards(transform.forward, targetPosition, singleStep, 0.0f);
        }
        else currentAlertLevel -= Time.deltaTime;
        if (currentAlertLevel > maxAlertLevel) currentAlertLevel = maxAlertLevel;
        else if (currentAlertLevel < 0.0f) currentAlertLevel = 0.0f;
        return currentAlertLevel;
    }
}
