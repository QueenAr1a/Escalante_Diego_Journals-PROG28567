using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    // Update is called once per frame
    void Update()
    {
        //every frame it checks if the b key is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            //invokes the spawn bomb event. will then jump and run the void instead until it is done
            SpawnBombAtOffset(new Vector3(0, 1));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
           WarpDriver();
        

        }
    }
    private void SpawnBombAtOffset(Vector3 inOffset) // we let it take a vector 3 
    {
        Vector3 spawnPosition = transform.position + inOffset; //this sets the spawn of the bomb to be at the ship but plus the offset so its not ontop
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);// this makes the domb with quaternion. identity to basically tellit not to rotate
        //
    }
    public void WarpDriver()
    {
        float RatioValue = 0.5f;
        Vector2 enemypositon = enemyTransform.position;
        Vector2 Shipposition = transform.position;
        Vector2 LerpDrive = Vector2.Lerp(Shipposition, enemypositon, RatioValue);

        transform.position = LerpDrive;

    }

}
