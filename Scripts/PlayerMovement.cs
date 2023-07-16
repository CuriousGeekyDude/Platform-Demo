using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;

    private void Movement()
    {
        float valueOfDisplacement = Input.GetAxis("Horizontal");
        valueOfDisplacement *= 10f;
        rigidBody.velocity = new Vector2(valueOfDisplacement, rigidBody.velocity.y);
        animator.SetFloat("SpeedOfPlayer", Mathf.Abs(valueOfDisplacement));

        if(Input.GetKey(KeyCode.Space)) {
            rigidBody.AddForce(new Vector2(0, 1.5f), ForceMode2D.Impulse);
        }
            
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.transform.GetComponent<Rigidbody2D>();
        animator = this.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
