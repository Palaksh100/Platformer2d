using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed,jumpSpeed;
    private Rigidbody2D body;
    private bool Grounded;
    private Vector2 moveInput;
    private Animator animator;

    void Awake()
    {
        body=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    public void Move(InputAction.CallbackContext context){
        moveInput=context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context){
        if(context.performed&&Grounded){
            animator.SetBool("Walk",false);
            body.linearVelocityY=jumpSpeed;
            Grounded=false;
        }
        
    }
    
    void FixedUpdate()
    {
        body.linearVelocity=new Vector2(moveInput.x*moveSpeed,body.linearVelocityY);
        if(body.linearVelocityX>0.01f){
            transform.localScale=new Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y,1f);
        }
        if(body.linearVelocityX<-0.01f){
            transform.localScale=new Vector3(-Mathf.Abs(transform.localScale.x),transform.localScale.y,1f);
        }
        animator.SetBool("Walk",moveInput.x!=0&&Grounded);

    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            Grounded=true;
            body.linearVelocityY=0;
        }
    }
}
