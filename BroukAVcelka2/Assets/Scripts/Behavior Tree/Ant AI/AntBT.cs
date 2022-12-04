using System.Collections.Generic;
using UnityEngine.AI;
using BehaviorTree;

public class AntBT : Tree
{
    
    private NavMeshAgent agent;

    //public UnityEngine.GameObject ant = this.UnityEngine.GameObject;
    protected override Node SetupTree()
    {
        agent = GetComponent<NavMeshAgent>();

        //root selector asi jo
        Node root = new Selector(new List<Node>
            {
                new TaskFollowTarget(transform),
                new TargetRandomLocation(transform/*, agent*/)
            });
        return root;
    }
}
