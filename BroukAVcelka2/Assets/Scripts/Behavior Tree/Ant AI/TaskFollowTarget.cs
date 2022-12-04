using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;

public class TaskFollowTarget : Node
{
    private Transform _transform;
    private NavMeshAgent _agent;

    public TaskFollowTarget(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object target = GetData("target");
        if (target != null)
        {
            //should be Running asi
            state = NodeState.RUNNING;
            return state;
        }
        else state = NodeState.FAILURE;
        return state;
    }
}
