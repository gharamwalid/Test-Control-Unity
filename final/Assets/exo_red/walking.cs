using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;


public class walking : StateMachineBehaviour
{
    Transform player;
    float chaseRange = 8;
    List<Transform> way = new List<Transform>();
    NavMeshAgent agent;

  
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = 1.5f;
        GameObject go = GameObject.FindGameObjectWithTag("way");
        foreach (Transform t in go.transform)
            way.Add(t);
        agent.SetDestination(way[Random.Range(0, way.Count)].position);
       

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (agent.remainingDistance < agent.stoppingDistance)
            agent.SetDestination(way[Random.Range(0, way.Count)].position);
              animator.SetBool("walking", true);
            if (agent.remainingDistance != agent.stoppingDistance)
                 animator.SetBool("walking", false);
        //timer += Time.deltaTime;
        if (agent.remainingDistance == agent.stoppingDistance)
            animator.SetBool("walking", false);
           // animator.SetBool("walking", true);

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange &&  distance >=1)
            animator.SetBool("running", true);
        


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
