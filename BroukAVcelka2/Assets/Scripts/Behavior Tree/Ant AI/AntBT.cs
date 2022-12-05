using System.Collections.Generic;
using UnityEngine.AI;
using BehaviorTree;

public class AntBT : Tree
{
    
    private NavMeshAgent agent;
    private AntStats antStats;

    //public UnityEngine.GameObject ant = this.UnityEngine.GameObject;
    protected override Node SetupTree()
    {
        agent = GetComponent<NavMeshAgent>();
        antStats = GetComponent<AntStats>();

        //root selector asi jo
        Node root = new Selector(new List<Node>
            {
                new TaskFollowTarget(transform, agent),
                new TargetRandomLocation(transform, agent)
            });
        return root;
    }
}
