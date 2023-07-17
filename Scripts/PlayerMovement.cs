using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    private BoxCollider2D boxCollider;

    private void Movement()
    {
        float valueOfDisplacement = Input.GetAxis("Horizontal");
        valueOfDisplacement *= 10f;
        rigidBody.velocity = new Vector2(valueOfDisplacement, rigidBody.velocity.y);
        animator.SetFloat("SpeedOfPlayer", Mathf.Abs(valueOfDisplacement));

        Vector3 maxBox = boxCollider.bounds.max;
        Vector3 minBox = boxCollider.bounds.min;
        Vector2 topLeftCorner = new Vector2(minBox.x, minBox.y - 0.1f);
        Vector2 bottomRightCorner = new Vector2(maxBox.x, minBox.y - 0.5f);
        Collider2D hit = Physics2D.OverlapArea(topLeftCorner, bottomRightCorner);
        rigidBody.gravityScale = 9.81f;
        if(hit != null) {
            if(Mathf.Approximately(valueOfDisplacement, 0)) {
                rigidBody.gravityScale = 0;
            }

            if(Input.GetKey(KeyCode.Space)) {
                rigidBody.gravityScale = 9.81f;
                rigidBody.AddForce(new Vector2(0, 3f), ForceMode2D.Impulse);
            }
        }
            
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.transform.GetComponent<Rigidbody2D>();
        animator = this.transform.GetComponent<Animator>();
        boxCollider = this.transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
