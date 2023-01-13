using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public Brick[] bricks;
    
    public int score = 0;
    public int level = 1;
    public int lives = 2;

    public static GameManager instance;

    public void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance=this;
    }


    private void Start()
    {
        this.score = 0;
        this.lives = 2;
        
    }

    private void NewGame()
    {
        this.score = 0;
        this.lives = 2;
        LoadLevel(0);
        

    }

    private void LoadLevel(int level)
    {
        this.level = level;

        /*if (level > 10)
        {
            SceneManager.LoadScene("WinScreen");
        }
        else
        {
            SceneManager.LoadScene("Level" + level);
        }*/

        SceneManager.LoadScene(level,LoadSceneMode.Single);
        
    }





    public void ResetLevel()
    {
        this.ball.ResetBall();
        
        this.paddle.ResetPaddle();

        for(int i = 0; i < this.bricks.Length; i++)
        {
            this.bricks[i].ResetBrick();

        }
    }

    private void GameOver()
    {
        //SceneManager.LoadScene("GameOver");
        NewGame();
    }

    public void Miss()
    {
        this.lives--;

        if (this.lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }

    public void Hit(Brick brick)
    {
        this.score += brick.points;

        if (Cleared()){
            LoadLevel(0);
        }
    }

    private bool Cleared()
    {
        Debug.Log(bricks);
        for(int i = 0; i < this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbrekable)
            {
                return false;
            }
        }

        return true;
    }
}
