using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float spd=2f;
    [SerializeField]
    float jumpForce = 1f;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*spd,rb2d.velocity.y);
        if(Input.GetButtonUp("Jump")) {
            rb2d.AddRelativeForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
        }
    }
}
