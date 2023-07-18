using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject platformBluePrint;
    private GameObject[] clonedPlatforms = new GameObject[2];


    private void PositionPlatforms()
    {
        float positionPlayerY = player.transform.position.y;
        float positionPlayerX = player.transform.position.x;
        clonedPlatforms[0].transform.position = new Vector3(positionPlayerX+Random.Range(-5f, 5f), positionPlayerY-5f, player.transform.position.z);
        clonedPlatforms[1].transform.position = new Vector3(positionPlayerX+Random.Range(-5f, 5f), positionPlayerY+5f, player.transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
