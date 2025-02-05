using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed,jumpSpeed;
    private Rigidbody2D body;
    private bool Grounded;

    void Awake()
    {
        body=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput=Input.GetAxis("Horizontal");
        body.linearVelocity=new Vector2(HorizontalInput*moveSpeed,body.linearVelocityY);
        if(HorizontalInput>0.01f){
            transform.localScale=Vector2.one;
        }
        if(HorizontalInput<-0.01f){
            transform.localScale=new Vector2(-1f,1f);
        }

        if(Input.GetKeyDown(KeyCode.Space)&&Grounded){
            body.linearVelocityY=jumpSpeed;
            Grounded=false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            Grounded=true;
            body.linearVelocityY=0;
        }
    }
}
