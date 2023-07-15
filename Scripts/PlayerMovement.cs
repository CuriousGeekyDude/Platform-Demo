using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private void Movement()
    {
        float valueOfDisplacement = Input.GetAxis("Horizontal");
        valueOfDisplacement *= 10f;
        rigidBody.velocity = new Vector2(valueOfDisplacement, rigidBody.velocity.y);
            
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
