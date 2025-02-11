using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    private int score;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            
            if (score > HighScore)
            {
                HighScore = score;
            }
            
            displayText.text = "Score: " + score + " " + "High Score:" + HighScore;
            Debug.Log(score);
            
            if (targetScore == score)
            {
                targetScore += 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }

    private int highScore;
    public int HighScore
    {
        get
        {
            if (File.Exists(filePathHighScore))
            {
                string fileContents = File.ReadAllText(filePathHighScore);
                highScore = int.Parse(fileContents); // turn the string into a number
            }
            return highScore;
        }
        set
        {
            highScore = value;

            if (!File.Exists(filePathHighScore))
            {
                string dirLocation = Application.dataPath + DirName;

                if (!Directory.Exists(dirLocation))
                {
                    Directory.CreateDirectory(dirLocation);
                }
            }
            File.WriteAllText(filePathHighScore, score + "");
        }
    }

    private string filePathHighScore;
    private const string DirName = "/Data/";
    const string FileName = DirName + "highscore.txt";
    
    public int targetScore = 1;
    
    public static GameManager instance;

    private TextMeshProUGUI displayText;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get display text
        displayText = GameObject.Find("ScoreDisplay").GetComponent<TextMeshProUGUI>();
        
        //singleton time
        
        if (instance == null) //meaning the instance hasnt been set yet, at very beginning of game
        {
            instance = this;
            DontDestroyOnLoad(this);
            
            displayText = GameObject.Find("ScoreDisplay").GetComponent<TextMeshProUGUI>();
            filePathHighScore = Application.dataPath + FileName;
            
            Score = 0;

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
        // Debug.Log(score);
        // if (targetScore == score)
        // {
        //     targetScore += 1;
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }
    }
}
