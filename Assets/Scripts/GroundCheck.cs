using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D col)
    {
        isGrounded = true;
        //Debug.Log("on ground");
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        isGrounded = false;
        //Debug.Log("off ground");
    }

 
}
