using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject platformBluePrint;
    [SerializeField] private Camera mainCamera;
    private GameObject[] clonedPlatforms = new GameObject[2];
    private int indexOfMarkedPlatform;

    private void DestroyPlatforms(int indexOfPlatformToDestroy)
    {
        player.NullifyParent();
        DestroyImmediate(clonedPlatforms[indexOfPlatformToDestroy]);
        clonedPlatforms[indexOfPlatformToDestroy] = null;
    }

    private void PositionPlatforms(int indexOfClonedPlatform)
    {
        float positionPlayerY = player.transform.position.y;
        float positionPlayerX = player.transform.position.x;
        
        clonedPlatforms[indexOfClonedPlatform].transform.position = new Vector3(positionPlayerX+Random.Range(-30f, 15f), positionPlayerY+4f, player.transform.position.z);
    }

    private void SpawnPlatforms()
    {
        Platform platformStandingOn = clonedPlatforms[indexOfMarkedPlatform].GetComponent<Platform>();

        if(platformStandingOn.isOnPlatform) {
            switch(indexOfMarkedPlatform) {
                case 0:
                    if(clonedPlatforms[1] != null) {
                        DestroyPlatforms(1);
                    }
                    ++indexOfMarkedPlatform;
                    break;
                case 1:
                    if(clonedPlatforms[0] != null) {
                        DestroyPlatforms(0);
                    }
                    indexOfMarkedPlatform = 0;
                    break;
            }
            clonedPlatforms[indexOfMarkedPlatform] = Instantiate(platformBluePrint) as GameObject;
            PositionPlatforms(indexOfMarkedPlatform);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        indexOfMarkedPlatform = 0;
        clonedPlatforms[indexOfMarkedPlatform] = Instantiate(platformBluePrint) as GameObject;
        PositionPlatforms(indexOfMarkedPlatform);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }
}
