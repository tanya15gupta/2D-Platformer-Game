using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyStateAnimTest : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        AnyStateTrying();
        
        
    }

    public void AnyStateTrying()
    {
        if(Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("Speed", 2);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 5);
        }

        if(Input.GetKey(KeyCode.None))
        {
            anim.SetFloat("Speed", 0);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            //anim.SetBool("Staff_Attack", false);
            //anim.SetBool("Crouch", false);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            //anim.SetBool("Jump", false);
            anim.SetTrigger("Staff_Attack");
            //anim.SetBool("Crouch", false);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            //anim.SetBool("Jump", false);
            //anim.SetBool("Staff_Attack", false);
            anim.SetBool("Crouch", true);
        }
    }
}
