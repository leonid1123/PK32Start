using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float spd=2f;
    [SerializeField]
    float jumpForce = 1f;
    Animator anim;
    bool isRight = true;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    float groundCheckRadius=0.1f;
    [SerializeField]
    LayerMask groundMask;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("spd",Mathf.Abs(moveInput));
        rb2d.velocity = new Vector2(moveInput*spd,rb2d.velocity.y);
        if(isRight && moveInput<0){
            Flip();
        }
        if(!isRight && moveInput>0){
            Flip();
        }
        if(Input.GetButtonDown("Jump")) {
            Collider2D isground = Physics2D.OverlapCircle(new Vector2(groundCheck.position.x,groundCheck.position.y),groundCheckRadius,groundMask);
            if(isground!=null && isground.CompareTag("Ground"))
            {
                rb2d.AddRelativeForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
                anim.SetTrigger("isJump");
            }
        }
    }
    void Flip() {
        transform.Rotate(0,180,0);
        isRight = !isRight;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position,groundCheckRadius);
    }
}
