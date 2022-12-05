using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using BehaviorTree;

public class TargetPlayer : Node
{
    private AntStats _antStats;
    private NavMeshAgent _agent;

    public TargetPlayer(AntStats antStats, NavMeshAgent agent)
    {
        _antStats = antStats;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        _agent.destination = _antStats.lastKnownPlayerPosition;
        return NodeState.SUCCESS;
    }
}
