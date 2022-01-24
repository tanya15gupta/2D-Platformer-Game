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
    public float speed = 5f;
    private Rigidbody2D rb;
    public float jumpForce = 2f;


    
    void Awake()
    {
        boxCol = this.GetComponent<BoxCollider2D>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");      //player Flipping left and right
        float verticalInput = Input.GetAxisRaw("Jump");         //player jump animation
        PlayerMovementAnimation(horizontalInput, verticalInput);
        MoveCharacter(horizontalInput, verticalInput);

        //Crouch Animation
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
            boxCol.size = new Vector3(sizeX, sizeY, sizeZ);
            boxCol.offset = new Vector3(offX, offY, offZ);
        }
        
    }

    private void MoveCharacter(float horizontalInput, float verticalInput)
    {
        Vector3 position= transform.position;
        position.x = position.x + horizontalInput * speed * Time.deltaTime;
        transform.position = position; 

        if(verticalInput > 0)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
        }
        
    }

    private void PlayerMovementAnimation(float horizontalInput, float verticalInput)
    {
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        Vector3 scale = transform.localScale;
        //Flipping Logic
        if (horizontalInput < 0)
        {
            scale.x = -1.0f * Mathf.Abs(scale.x);
        }
        else if (horizontalInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (verticalInput > 0)
        {
            anim.SetBool("Jump 0", true);
        }
        else
        {
            anim.SetBool("Jump 0", false);
        }
    }

    public void Crouch(bool crouch)
    {
        float offX = -0.0978f;
        float offY = 0.5947f;
        float offZ = 0.0f;

        float sizeX = 0.6988f;
        float sizeY = 1.3398f;
        float sizeZ = 0.0f; 

        anim.SetBool("Crouch", crouch);

        boxCol.size = new Vector3(sizeX, sizeY, sizeZ);
        boxCol.offset = new Vector3(offX, offY , offZ);    
        
    }


}
