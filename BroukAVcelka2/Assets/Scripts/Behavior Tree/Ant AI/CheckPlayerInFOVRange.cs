using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class CheckPlayerInFOVRange : Node
{
    private Transform _transform;
    private AntStats _antStats;
    private NavMeshAgent _agent;
    //private AntRotateTowardsPlayer _antRotateTowardsPlayer;

    private Transform _playerTransform;

    

    //private static int _playerLayerMask = 1 << 6;

    public CheckPlayerInFOVRange(Transform transform, AntStats antStats, NavMeshAgent agent/*, AntRotateTowardsPlayer antRotateTowardsPlayer*/)
    {
        _transform = transform;
        _antStats = antStats;
        _agent = agent;
        //_antRotateTowardsPlayer = antRotateTowardsPlayer;
        _playerTransform = _antStats.playerTransform;
        //Vector3 eyesPosition = _transform.position + _transform.TransformPoint(_antStats.headOffset);
    }

    public override NodeState Evaluate()
    {
        if (PlayerInFOVRange())
        {
            //_antRotateTowardsPlayer.enabled = true;
            return NodeState.SUCCESS;
        }
            
        else
        {
            //_antRotateTowardsPlayer.enabled = false;
            return NodeState.FAILURE;
        }
    }

    private bool PlayerInFOVRange()
    {
        //Collider[] playerCollider = Physics.OverlapSphere(_transform.position,_antStats.rangeFOV, ~AntStats.playerLayerMask);
        //Debug.Log(Vector3.Dot(_transform.forward, (_playerTransform.position - _transform.position).normalized));
        //if (playerCollider.Length > 1 && (Vector3.Dot(_transform.forward, (_playerTransform.position - _transform.position).normalized) > _antStats.dotProductFOV))
        if (_antStats.playerInSightRange && (Vector3.Dot(_transform.forward, (_playerTransform.position - _transform.position).normalized) > _antStats.dotProductFOV))
        {
            
            if (_antStats.IsFOVObstructed(_playerTransform.position))
            {
                Debug.Log("isObstructed");
                return false;
            }
            else
            {
                Debug.Log("inFOV");
                _antStats.lastKnownPlayerPosition = _playerTransform.position;
                parent.parent.SetData("player in FOV range", true);
                if (_antStats.currentAlertLevel < _antStats.maxAlertLevel) _agent.isStopped = true;
                return true;
            }
            
        }

        else return false;
    }
}
