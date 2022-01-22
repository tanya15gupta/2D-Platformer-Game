using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator anim;           
    private BoxCollider2D boxCol;

    float offX = -0.00984f;
    float offY = 0.9908f;
    float offZ = 0.0f;

    float sizeX = 0.4876f;
    float sizeY = 2.1321f;
    float sizeZ = 0.0f;
    int count = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        boxCol = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxis("Horizontal");      //player movement left and right
        float jump = Input.GetAxis("Vertical");         //player movement jump

        anim.SetFloat("Speed", Mathf.Abs(speed));       //speed for movement
        anim.SetFloat("Jump", Mathf.Abs(jump));         //jump for jumping

        if(jump > 0)
        {
            anim.SetFloat("Jump", jump);
        }
        else if(jump < 0)
        {
            anim.SetFloat("Jump", jump);
        }

        Vector3 scale = transform.localScale;

        if(speed<0)
        {
            scale.x = -1.0f * Mathf.Abs(scale.x);
        }
        
        else if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;




        if(Input.GetKey(KeyCode.LeftControl))
        {
            
            Crouch();
            Debug.Log("Counter :" + count++);
            
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("Crouch", false);
            boxCol.size = new Vector3(sizeX, sizeY, sizeZ);
            boxCol.offset = new Vector3(offX, offY , offZ);    

        }
        
    }
    
    public void Crouch()
    {
        float offX = -0.0978f;
        float offY = 0.5947f;
        float offZ = 0.0f;

        float sizeX = 0.6988f;
        float sizeY = 1.3398f;
        float sizeZ = 0.0f;
            
        anim.SetBool("Crouch", true);

        boxCol.size = new Vector3(sizeX, sizeY, sizeZ);
        boxCol.offset = new Vector3(offX, offY , offZ);    
        
    }

}
