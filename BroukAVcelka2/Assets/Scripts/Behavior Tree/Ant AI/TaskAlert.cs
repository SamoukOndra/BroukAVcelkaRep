using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskAlert : Node
{
    private Transform _transform;
    private AntStats _antStats;

    public TaskAlert(Transform transform, AntStats antStats)
    {
        _transform = transform;
        _antStats = antStats;
    }

    public override NodeState Evaluate()
    {
        bool playerInFOVRange;
        object o = GetData("player in FOV range");
        playerInFOVRange = (o != null) ? true : false;
        float currentAlertLevel = _antStats.Alert(playerInFOVRange, _antStats.lastKnownPlayerPosition);
        if (currentAlertLevel == _antStats.maxAlertLevel)
        {
            parent.SetData("target", "player");
            return NodeState.SUCCESS;
        }
        else if (currentAlertLevel == 0) return NodeState.FAILURE;
        else return NodeState.RUNNING;
    }
}
