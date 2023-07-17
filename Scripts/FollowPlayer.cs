using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 currentVelocity;
    // Start is called before the first frame update
    void Start()
    {
        currentVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   void LateUpdate()
    {
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = Vector3.SmoothDamp(this.transform.position, target, ref currentVelocity, 0.25f);
    }

}
