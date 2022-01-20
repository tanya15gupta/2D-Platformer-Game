using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator anim;
    private BoxCollider2D boxCol;

    
    // Start is called before the first frame update
    void Start()
    {
        boxCol = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(speed));

        
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
            Movement();
        
        }
    }
    
    public void Movement()
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
