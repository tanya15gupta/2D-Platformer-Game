using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    private BoxCollider2D boxCol;
    public ScoreController scoreController;
    float offX;
    float offY;
    float offZ;

    float sizeX;
    float sizeY;
    float sizeZ;
    public float speed = 5f;
    private Rigidbody2D rb;
    public float jumpForce = 2f;
    public GroundCheck groundCheck;
    float horizontalInput;
    float verticalInput;

    public void PickUp()
    {
        scoreController.IncreaseScore(10);
        
    }

    void Awake()
    {
        boxCol = this.GetComponent<BoxCollider2D>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");      //player Flipping left and right
        verticalInput = Input.GetAxisRaw("Jump");         //player jump
        PlayerMovementAnimation(horizontalInput, verticalInput);
    }

	void FixedUpdate()
    {
        MoveCharacter(horizontalInput, verticalInput);

        //Crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }
    }

    private void MoveCharacter(float horizontalInput, float verticalInput)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontalInput * speed * Time.deltaTime;
        transform.position = position;

        if (verticalInput > 0 && groundCheck.isGrounded == true)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
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


        if (crouch == true)
        {
            offX = -0.0978f;
            offY = 0.5947f;
            offZ = 0.0f;

            sizeX = 0.6988f;
            sizeY = 1.3398f;
            sizeZ = 0.0f;

            anim.SetBool("Crouch", crouch);
        }

        else
        {
            offX = -0.00984f;
            offY = 0.9908f;
            offZ = 0.0f;

            sizeX = 0.4876f;
            sizeY = 2.1321f;
            sizeZ = 0.0f;

            anim.SetBool("Crouch", crouch);
        }


        boxCol.size = new Vector3(sizeX, sizeY, sizeZ);
        boxCol.offset = new Vector3(offX, offY, offZ);

    }


}