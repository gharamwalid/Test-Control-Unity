using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;


public class fly : StateMachineBehaviour
{
    Transform player;
    float chaseRange = 8;
    List<Transform> flyingway = new List<Transform>();
    NavMeshAgent agent;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = 1.5f;
        GameObject go = GameObject.FindGameObjectWithTag("flyingway");
        foreach (Transform t in go.transform)
            flyingway.Add(t);
        agent.SetDestination(flyingway[Random.Range(0, flyingway.Count)].position);
        agent.transform.LookAt(player);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        /*  if (agent.remainingDistance < agent.stoppingDistance) { 
              agent.SetDestination(flyingway[Random.Range(0, flyingway.Count)].position);
              animator.SetBool("fly", true); }
          if (agent.remainingDistance != agent.stoppingDistance)
              animator.SetBool("fly", false);
          //timer += Time.deltaTime;
          if (agent.remainingDistance == agent.stoppingDistance)
              animator.SetBool("fly", false);
          // animator.SetBool("walking", true);

          float distance = Vector3.Distance(player.position, animator.transform.position);
          if (distance < chaseRange && distance >= 3)
              animator.SetBool("chasing", true);
        */
        agent.transform.LookAt(player);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > chaseRange)
        {
            animator.SetBool("fly", false);

        }
        else if (distance > 3 && distance < chaseRange)
        {
            animator.SetBool("chasing", true);
        }
        else if (distance < 3)
        {
            animator.SetBool("fly", false);

        }
       
    }




    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
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
