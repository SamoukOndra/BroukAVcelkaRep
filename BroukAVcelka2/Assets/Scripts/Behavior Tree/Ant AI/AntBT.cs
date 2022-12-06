using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class AntBT : BahaviorTree
{
    

    private NavMeshAgent agent;
    private AntStats antStats;
    private AntRotateTowardsPlayer antRotateTowardsPlayer;

    //public UnityEngine.GameObject ant = this.UnityEngine.GameObject;
    protected override Node SetupTree()
    {
        agent = GetComponent<NavMeshAgent>();
        antStats = GetComponent<AntStats>();
        antRotateTowardsPlayer = GetComponent<AntRotateTowardsPlayer>();
        antRotateTowardsPlayer.enabled = false;

        //root selector asi jo
        Node root = new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new Selector(new List<Node>{new CheckPlayerInFOVRange(transform, antStats, agent), new CheckIsAlerted(antStats) }),
                    new TaskAlert(antStats, agent, antRotateTowardsPlayer),
                    new TargetPlayer(antStats, agent),
                    new TaskFollowTarget(transform, agent)
                }),

                new Selector(new List<Node> {new TaskFollowTarget(transform,agent), new TargetRandomLocation(transform, agent)})
            });
        return root;
    }
}
