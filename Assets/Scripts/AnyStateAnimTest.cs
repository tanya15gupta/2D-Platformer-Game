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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Staff_Attack", false);
            anim.SetBool("Crouch", false);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Staff_Attack", true);
            anim.SetBool("Crouch", false);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Staff_Attack", false);
            anim.SetBool("Crouch", true);
        }
    }
}
