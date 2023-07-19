using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private int directionOfMovement = 1;
    public bool isOnPlatform {get; set;} = false;
    private void Movement()
    {
        float posX = this.transform.position.x;
        if(-13f <= posX && posX <= 5f) {
            switch(directionOfMovement) {
                case 1:
                    this.transform.Translate(new Vector3(0.05f, 0, 0));
                    break;
                case -1:
                    this.transform.Translate(new Vector3(-0.05f, 0, 0));
                    break;
            }
        }

        else {
            if(posX < -13f) {
                this.transform.Translate(new Vector3(0.05f, 0, 0));
                directionOfMovement = 1;
            }
            if(5f < posX) {
                this.transform.Translate(new Vector3(-0.05f, 0, 0));
                directionOfMovement = -1;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
