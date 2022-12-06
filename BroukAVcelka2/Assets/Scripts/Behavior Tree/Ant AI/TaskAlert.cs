using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class TaskAlert : Node
{
    //private Transform _transform;
    private AntStats _antStats;
    private NavMeshAgent _agent;
    private AntRotateTowardsPlayer _antRotateTowardsPlayer;

    public TaskAlert(AntStats antStats, NavMeshAgent agent, AntRotateTowardsPlayer antRotateTowardsPlayer)
    {
        //_transform = transform;
        _antStats = antStats;
        _agent = agent;
        _antRotateTowardsPlayer = antRotateTowardsPlayer;
    }

    public override NodeState Evaluate()
    {
        bool playerInFOVRange;
        object o = GetData("player in FOV range");
        //playerInFOVRange = (o != null) ? true : false;
        if (o != null)
        {
            Debug.Log("dictionary ok");
            playerInFOVRange = true;
            
        }
        else playerInFOVRange = false;
        float currentAlertLevel = _antStats.Alert(playerInFOVRange, _antStats.lastKnownPlayerPosition);
        //Debug.Log(currentAlertLevel);
        if (currentAlertLevel == _antStats.maxAlertLevel)
        {
            parent.SetData("target", "player");
            _antRotateTowardsPlayer.enabled = false;
            _agent.isStopped = false;
            return NodeState.SUCCESS;
        }
        else if (currentAlertLevel == 0)
        {
            _antRotateTowardsPlayer.enabled = false;
            ClearData("target");
            _agent.isStopped = false;
            return NodeState.FAILURE;
        }
        else
        {
            _antRotateTowardsPlayer.enabled = true;
            return NodeState.RUNNING;
        }
    }
    /*private void RotateAntTowardsPlayer()
    {
        float singleStep = _antStats.rotateTowardsSpeed * Time.deltaTime;
        //Vector3 forwardDirection = Vector3.R
        _transform.forward = Vector3.RotateTowards(_transform.forward, _antStats.lastKnownPlayerPosition, singleStep, 0.0f);
    }

    IEnumerator RotateAntTowardsPlayerRoutine()
    {
        yield return new WaitForFixedUpdate();
        RotateAntTowardsPlayer();
    }*/
}
