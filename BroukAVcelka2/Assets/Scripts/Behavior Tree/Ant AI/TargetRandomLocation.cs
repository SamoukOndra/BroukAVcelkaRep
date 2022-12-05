using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;

public class TargetRandomLocation : Node
{
    //[SerializeField] GameObject ant;
    public float _searchRadius = 200.0f;
    private Transform _transform;
    private NavMeshAgent _agent;

    private Vector3 _targetPosition;

    public TargetRandomLocation(Transform transform, NavMeshAgent agent)
    {
        _transform = transform;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            _targetPosition = RandomNavmeshLocation(AntStats.randomSearchRadius);
            parent.SetData("target", _targetPosition);
            _agent.destination = _targetPosition;
            //Debug.Log("Target set");
            return NodeState.SUCCESS;
        }
        else return NodeState.FAILURE;
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += _transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 3))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
