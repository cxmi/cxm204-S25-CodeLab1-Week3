using UnityEngine;

public class RewardScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision other)
    {
        GameManager.instance.score++;
        Destroy(GameObject.Find("Reward"));
    }
}
