using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject gameOverPanel;

    public List<Parallax> moving;
    public List<Cactus> cactus;
    public List<Coin> coins;
    public bool isAlive = true;

    public Text scoreText;
    private float score;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    public void AddMoving(Parallax obj)
    {
        moving.Add(obj);
    }

    public void AddCactus(Cactus obj)
    {
        cactus.Add(obj);
    }

    public void AddCoins(Coin obj)
    {
        coins.Add(obj);
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void StopAllMoving()
    {
        foreach(Parallax obj in moving)
        {
            obj.canMove = false;
        }

        foreach(Cactus obj in cactus)
        {
            obj.canMove = false;
        }

        foreach(Coin obj in coins)
        {
            obj.canMove = false;
        }

        gameOverPanel.SetActive (true);
    }

    // Use this for initialization
    void Start () {
		
	}

    public void Replay()
    {
        SceneManager.LoadScene("Level1");
    }
	
	// Update is called once per frame
	void Update () {
        if (isAlive)
        {
            score += Time.deltaTime;
            
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();

        }
	}
}
