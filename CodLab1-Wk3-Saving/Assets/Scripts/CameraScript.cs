using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public float cameraDistance = -20f;
    public static CameraScript instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null) //meaning the instance hasnt been set yet, at very beginning of game
        {
            instance = this; 
            DontDestroyOnLoad(this);
            //makes sure this game manager doesn't destroy on load
        }
        else
        {
            Destroy(gameObject);
            //if theres already an instance, destroy the new instance that was just created
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - cameraDistance);
    }
}
