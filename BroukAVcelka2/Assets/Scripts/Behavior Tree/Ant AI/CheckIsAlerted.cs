using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckIsAlerted : Node
{
    //private Transform _transform;
    private AntStats _antStats;

    public CheckIsAlerted (AntStats antStats)
    {
        _antStats = antStats;
    }

    public override NodeState Evaluate()
    {
        ClearData("player in FOV range");
        if (_antStats.currentAlertLevel > 0.0f) return NodeState.SUCCESS;
        else return NodeState.FAILURE;
    }
}
