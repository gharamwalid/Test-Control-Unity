using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charged : MonoBehaviour
{
    private int HP = 100;
    public Slider healthbar; // Assign this via Inspector
    public Animator animator; // Assign this via Inspector

    void Update()
    {
        if (healthbar != null) // Ensure healthbar is not null before using it
        {
            healthbar.value = HP;
            if (animator.GetBool("explosion") == true)
            {
                HP = 0;
              //  animator.SetBool("finish", false);
            }
        }

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
