using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed,jumpSpeed;
    private Rigidbody2D body;
    private bool Grounded;
    private Vector2 moveInput;

    void Awake()
    {
        body=GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context){
        moveInput=context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context){
        if(context.performed&&Grounded){
            body.linearVelocityY=jumpSpeed;
            Grounded=false;
        }
        
    }
    
    void FixedUpdate()
    {
        body.linearVelocity=new Vector2(moveInput.x*moveSpeed,body.linearVelocityY);
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            Grounded=true;
            body.linearVelocityY=0;
        }
    }
}
