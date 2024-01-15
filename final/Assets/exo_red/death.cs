
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class death : StateMachineBehaviour
{
    Transform player;
  //  NavMeshAgent agent;
    GameObject Explosion;
   //    float ExplosionFire = 0.05f;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    
       Vector3 targetPosition = new Vector3(player.position.x, -1f, player.position.z); // Set your target position here
        //agent.SetDestination(targetPosition);
        
        Explosion = GameObject.FindGameObjectWithTag("explosion");

        if (Explosion != null)
        {
            //Vector3 effectPosition = animator.transform.position; // or specify a different position if needed
            Instantiate(Explosion, targetPosition, Quaternion.identity);
         
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.SetBool("explosion", false);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("explosion", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
