using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckPlayerInFOVRange : Node
{
    private Transform _transform;
    private AntStats _antStats;

    //private static int _playerLayerMask = 1 << 6;

    public CheckPlayerInFOVRange(Transform transform, AntStats antStats)
    {
        _transform = transform;
        _antStats = antStats;
        //Vector3 eyesPosition = _transform.position + _transform.TransformPoint(_antStats.headOffset);
    }

    public override NodeState Evaluate()
    {
        if (PlayerInFOVRange())
        {
            //_antStats.playerInSight = true;
            return NodeState.SUCCESS;
        }
            
        else return NodeState.FAILURE;
    }

    private bool PlayerInFOVRange()
    {
        Collider[] playerCollider = Physics.OverlapSphere(_transform.position,_antStats.rangeFOV, AntStats.playerLayerMask);
        if (playerCollider != null && (Vector3.Dot(_transform.forward, playerCollider[0].transform.position - _transform.position) > _antStats.dotProductFOV))
        {
            if (_antStats.IsFOVObstructed(playerCollider[0].transform.position)) return false;
            else
            {
                _antStats.lastKnownPlayerPosition = playerCollider[0].transform.position;
                parent.SetData("player in FOV range", true);
                return true;
            }
        }
        else return false;
    }
}
