using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntRotateTowardsPlayer : MonoBehaviour
{
    public Transform playerTransform;
    private AntStats _antStats;
    //private float _singleStep;
    [SerializeField] float degreesPerSecond = 90.0f;

    private void Awake()
    {
        _antStats = GetComponent<AntStats>();
        //_singleStep = _antStats.rotateTowardsSpeed * Time.deltaTime;
    }

    /*private void FixedUpdate()
    {
        RotateAntTowardsPlayer();
    }*/

    void Update()
    {
        //float degreesPerSecond = 90 * Time.deltaTime;
        Vector3 direction = playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond * Time.deltaTime);
        //nastavit nejakej limit na rotaci hore/duule?
    }

    /*private void RotateAntTowardsPlayer()
    {
        /*transform.forward = Vector3.RotateTowards(transform.forward, _antStats.lastKnownPlayerPosition, _singleStep, 0.0f);
    }*/
}
