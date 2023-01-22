using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    public Joystick joystick;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
        
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;


        if (direction.magnitude > 0)
        {
            animator.SetBool("IsWalking", true);
        }

        else
        {
            animator.SetBool("IsWalking", false);
        }

    }
}
