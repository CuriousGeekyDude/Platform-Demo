using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Platform platformBluePrint;
    [SerializeField] private Camera mainCamera;
    private Platform[] clonedPlatforms = new Platform[2];


    private void DestroyPlatforms()
    {
        float posCameraMaxY = mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, mainCamera.nearClipPlane)).y;
        float posCameraMinY = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0, mainCamera.nearClipPlane)).y;
        for(int i = 0; i < 2; ++i) {
            if(posCameraMaxY < clonedPlatforms[i].transform.position.y || clonedPlatforms[i].transform.position.y < posCameraMinY) {
                player = null;
                Destroy(clonedPlatforms[i]);
                clonedPlatforms[i] = null;
            }
        }
    }

    private void PositionPlatforms(int indexOfClonedPlatform)
    {
        float positionPlayerY = player.transform.position.y;
        float positionPlayerX = player.transform.position.x;
        if(indexOfClonedPlatform == 0) {
            clonedPlatforms[0].transform.position = new Vector3(positionPlayerX+Random.Range(-5f, 5f), positionPlayerY-5f, player.transform.position.z);
        }
        else {
            clonedPlatforms[1].transform.position = new Vector3(positionPlayerX+Random.Range(-5f, 5f), positionPlayerY+5f, player.transform.position.z);
        }
    }

    private void SpawnPlatforms()
    {
        for(int i = 0; i < 2; ++i) {
            if(clonedPlatforms[i] == null) {
                clonedPlatforms[i] = Instantiate(platformBluePrint) as Platform;
                PositionPlatforms(i);
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
        SpawnPlatforms();
        DestroyPlatforms();   
    }
}
