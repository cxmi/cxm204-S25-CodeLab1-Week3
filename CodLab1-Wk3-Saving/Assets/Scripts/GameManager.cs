using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //class is short for classification - a type of thing.
    //so GameManager is a type of thing - out of classes we make specific instances
    //a specific instance of a class is an object
    public int score = 0;
    public int targetScore = 1;
    
    public static GameManager instance;
    // static - no matter how many  gamemanagesr we have, there's only one of this variable
    
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
        Debug.Log(score);
        if (targetScore == score)
        {
            targetScore += 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
