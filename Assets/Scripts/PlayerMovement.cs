using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed,jumpSpeed;
    public bool InBossRoom=false;
    private Rigidbody2D body;
    [SerializeField]private bool Grounded;
    private Vector2 moveInput;
    private Animator animator;
    private bool portalActive=true;
    private GameObject CurrentPortal;
    void Awake()
    {
        portalActive=true;
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
        if(body.position.y>25f){
            InBossRoom=true;
        }
        animator.SetBool("Walk",moveInput.x!=0&&Grounded);

    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            Grounded=true;
            body.linearVelocityY=0;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Portal")){
            if(portalActive){
                Transform parent=other.gameObject.transform.parent;
                foreach(Transform child in parent){
                    if (child.gameObject!=other.gameObject){
                        CurrentPortal=child.gameObject;
                        body.position=CurrentPortal.transform.position;
                        portalActive=false;
                    }
                }
            }
        }
        else if(other.gameObject.CompareTag("Flag")){
                SceneController.instance.Complete();
            }
    }
    void OnTriggerExit2D(Collider2D other){
        if(CurrentPortal!=null)
        if(other.gameObject==CurrentPortal) portalActive=true;
    }
}
