using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    public GameOver gameisOver;
    public TextMeshProUGUI FriendlyScore;
    public TextMeshProUGUI FinalScore;

    //string[] wall = new string[] { "WallLeft", "WallRight", "WallTop", "WallBottom" };
    string wall;

    bool player1Scored = false;
    bool player2Scored = false;

    public float bonusTime = 5f;

    float startTime;
    public float currentTime = 20;

    public TextMeshProUGUI timer;

    int friendlyScore;


    int PlayerOneHealth = 10;
    int PlayerTwoHealth = 10;

    int PlayerOneScore;
    int PlayerTwoScore;

    public float speed = 30f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * speed;

        

    }

    void Update()
    {
        RestartLevelWithR();

        currentTime = currentTime - Time.deltaTime;

        timer.text = currentTime.ToString("f2");

        if (currentTime < 0)
        {
            gameisOver.GameOverUI();
        }

        ScoreManagment();
        RestartLevelWithR();
    }

    private static void RestartLevelWithR()
    {
        if (Input.GetKeyDown("r"))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
            Time.timeScale = 1;
        }
    }

    private void ScoreManagment()
    {
        FriendlyScore.text = friendlyScore.ToString();
        FinalScore.text = "Your score is " + friendlyScore.ToString();

        if (player1Scored && player2Scored)
        {
            friendlyScore++;
            player1Scored = false;
            player2Scored = false;
            currentTime = currentTime + bonusTime;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D col)
    {

        //switch(wall)

        //{
        //    case "WallLeft":
        //        PlayerOneHealth--;
        //        player1Scored = false;
        //        player2Scored = false;
        //        Debug.Log("WallLeft");
        //        break;
        //    case "WallRight":
        //        PlayerTwoHealth--;
        //        player1Scored = false;
        //        player2Scored = false;
        //        Debug.Log("WallRight");
        //        break;
        //    case "WallBottom":
        //        PlayerTwoHealth--;
        //        player1Scored = false;
        //        player2Scored = false;
        //        Debug.Log("WallBottom");
        //        break;
        //    case "WallTop":
        //        PlayerTwoHealth--;
        //        player1Scored = false;
        //        player2Scored = false;
        //        Debug.Log("Walltop");
        //        break;
        //    default: BallHitDirection(col);
        //        break;

        //}




        if (col.gameObject.name == "WallLeft")
        {
            PlayerOneHealth--;
            player1Scored = false;
            player2Scored = false;
        }
        if (col.gameObject.name == "WallRight")
        {
            PlayerTwoHealth--;
            player1Scored = false;
            player2Scored = false;
        }
        if (col.gameObject.name == "WallBottom")
        {
            PlayerTwoHealth--;
            player1Scored = false;
            player2Scored = false;
        }
        if (col.gameObject.name == "WallTop")
        {
            PlayerTwoHealth--;
            player1Scored = false;
            player2Scored = false;
        }
        BallHitDirection(col);
    }

    private void BallHitDirection(Collision2D col)
    {
        if (col.gameObject.name == "RacketLeft")
        {
            PlayerOneScore++;

            player1Scored=true; 
            
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "RacketRight")
        {
            PlayerTwoScore++;
            
            player2Scored = true;
            
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballpos, Vector2 racketpos, float racketHeigh)
    {
        return (ballpos.y - racketpos.y) / racketHeigh;
    }
}

