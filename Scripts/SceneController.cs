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

    private void DestroyPlatforms()
    {
        float posCameraMaxY = mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, mainCamera.nearClipPlane)).y;
        float posCameraMinY = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0, mainCamera.nearClipPlane)).y;
        for(int i = 0; i < 2; ++i) {
            if(posCameraMaxY < clonedPlatforms[i].transform.position.y || clonedPlatforms[i].transform.position.y < posCameraMinY) {
                player.NullifyParent();
                DestroyImmediate(clonedPlatforms[i]);
                clonedPlatforms[i] = null;
            }
        }
    }

    private void PositionPlatforms(int indexOfClonedPlatform)
    {
        float positionPlayerY = player.transform.position.y;
        float positionPlayerX = player.transform.position.x;
        if(indexOfClonedPlatform == 0) {
            clonedPlatforms[0].transform.position = new Vector3(positionPlayerX+Random.Range(-30f, 15f), positionPlayerY-5f, player.transform.position.z);
        }
        else {
            clonedPlatforms[1].transform.position = new Vector3(positionPlayerX+Random.Range(-30f, 15f), positionPlayerY+5f, player.transform.position.z);
        }
    }

    private void SpawnPlatforms()
    {
        Platform platformStandingOn = clonedPlatforms[indexOfMarkedPlatform].GetComponent<Platform>();

        if(platformStandingOn.isOnPlatform) {
            switch(indexOfMarkedPlatform) {
                case 0:
                    ++indexOfMarkedPlatform;
                    break;
                case 1:
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
        DestroyPlatforms();   
    }
}
