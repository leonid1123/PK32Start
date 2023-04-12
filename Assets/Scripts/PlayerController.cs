using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    int HP = 100;
    [SerializeField]
    GameObject panel;
    void Start()
    {
        panel.SetActive(false);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) {
            ChangeHP(5);
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            ChangeHP(-10);
        }
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
    public void ChangeHP(int _x)
    {
        HP += _x;
        if (HP >= 100)
        {
            HP = 100;
        }
        if(HP <= 0)
        {
            HP = 0;
            anim.SetTrigger("isDead");
            panel.SetActive(true);
            this.enabled = false;
        }
    }
    public int GetHP()
    {
        return HP;
    }
}
