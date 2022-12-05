using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;

public class TaskFollowTarget : Node
{
    private Transform _transform;
    private NavMeshAgent _agent;

    public TaskFollowTarget(Transform transform, NavMeshAgent agent)
    {
        _transform = transform;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        object target = GetData("target");
        if (target != null)
        {
            // muze asi púusobit problem, kdyz destination v prekazce ??? ale hovno
            if (Vector3.Distance(_transform.position, _agent.destination)< 0.01f)
            {
                parent.ClearData("target");
                state = NodeState.FAILURE;
                return state;
            }
            else
            //should be Running asi
            state = NodeState.RUNNING;
            return state;
        }
        else state = NodeState.FAILURE;
        return state;
    }
}
