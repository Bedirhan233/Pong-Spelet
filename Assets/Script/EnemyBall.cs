using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyBall : MonoBehaviour
{
    public TextMeshProUGUI Player1Score;
    public TextMeshProUGUI Player2Score;

    public TextMeshProUGUI timer;

    float startTime;
    float currentTime = 20;



    int PlayerOneScore = 0;
    int PlayerTwoScore = 0;


    public float speed = 30f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

        currentTime = startTime;
    }

    void Update()
    {
        ScoreManagment();
        ReloadSceneWithR();

        





        
    }

    private static void ReloadSceneWithR()
    {
        if (Input.GetKeyDown("r"))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

    

    private void ScoreManagment()
    {
        Player1Score.text = "Player 1 Score: " + PlayerOneScore.ToString();
        Player2Score.text = "Player 2 Score: " + PlayerTwoScore.ToString();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        BallHitDirection(col);

        if(col.gameObject.name == "WallLeft")
        {
            PlayerTwoScore++;
        }
        if(col.gameObject.name == "WallRight")
        {
            PlayerOneScore++;
        }
        
    }

    private void BallHitDirection(Collision2D col)
    {
        if (col.gameObject.name == "RacketLeft")
        {
      
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "RacketRight")
        {
            
            
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

