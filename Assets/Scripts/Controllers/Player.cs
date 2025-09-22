using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    public float speed = 1f;
   
    public float Accelerationtime = 1.0f;
    public float Maxspeed = 1f;
    private Vector3 Velocity;
    // Update is called once per frame
    void Update()
    {
      
        PlayerMovment();





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
    private void PlayerMovment()
    {
        float accelerationrate = Maxspeed / Accelerationtime;
        //Velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Velocity += Vector3.up * accelerationrate * Time.deltaTime;
     
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Velocity += Vector3.left * accelerationrate * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Velocity += Vector3.right * accelerationrate * Time.deltaTime; 
           
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Velocity += Vector3.down * accelerationrate * Time.deltaTime;
           
        }
        Velocity = Vector3.ClampMagnitude(Velocity, Maxspeed);
        transform.position += Velocity * Time.deltaTime;
    }

}
