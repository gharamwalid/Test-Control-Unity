using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    private int HP = 100;
    public Slider healthbar; // Assign this via Inspector
    public Animator animator; // Assign this via Inspector
    [SerializeField] private float timer = 3;
    private float bullettime;
    public GameObject enemybullet;
    public Transform spawnpoint;
    public float enemyspeed;
    Transform player;
    



    void Start()
    {
       
    }
        void Update()
    {
        // Get the current state information
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        
        // Check if the animator is entering the "YourShootingState" state
        if (stateInfo.IsName("shooting") && stateInfo.normalizedTime < 1.0f)
        {
            Debug.Log("1");
            shootatplayer();
        }

    }

    void shootatplayer()
    {
        bullettime -= Time.deltaTime;
        if (bullettime > 2) return;
        bullettime = timer;
        GameObject bulletObj = Instantiate(enemybullet, spawnpoint.transform.position, spawnpoint.transform.rotation) as GameObject;
        Rigidbody bulletrig = bulletObj.GetComponent<Rigidbody>();
        bulletrig.AddForce(bulletrig.transform.forward * enemyspeed);
        Destroy(bulletObj, 5f);

    }

    public void TakeDamage(int damageamount)
    {
        HP -= damageamount;
        if (HP <= 0 && animator != null) // Ensure animator is not null before using it
        {

        }
        else
        {
            // Additional logic for when HP > 0 or animator is null
        }
    }
}