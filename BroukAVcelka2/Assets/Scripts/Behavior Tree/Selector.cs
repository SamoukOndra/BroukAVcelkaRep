using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Selector : Node
    {
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children) { }
        public override NodeState Evaluate()
        {
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        //Debug.Log("fail");
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        //Debug.Log("succ");
                        return state;
                    case NodeState.RUNNING:
                        //Debug.Log("runn");
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        continue;

                }
            }

            state = NodeState.FAILURE;
            //Debug.Log(state);
            return state;
        }
    }
}
