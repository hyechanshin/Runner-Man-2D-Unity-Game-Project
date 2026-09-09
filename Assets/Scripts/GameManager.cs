using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public enum GameState
{
    Intro,
    Playing,
    Dead
}
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameState State = GameState.Intro;

    public float PlayStartTime;
    public int Lives = 3;
    int finalScore;

    [Header("References")]
    public GameObject IntroUI;
    public GameObject DeadUI;
    public GameObject EnemySpawner;
    public GameObject FoodSpawner;
    public GameObject GoldSpawner;

    public Player PlayerScript;

    public TMP_Text scoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        IntroUI.SetActive(true);
    }


    float CalculateScore()
    {
        return Time.time - PlayStartTime;
    }

    void SaveHighScore()
    {
        int currentHighScore = PlayerPrefs.GetInt("highScore");
        if (finalScore > currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", finalScore);
            PlayerPrefs.Save();
        }
    }

    int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }

    public float CalculateGameSpeed()
    {
        if(State != GameState.Playing)
        {
            return 5f;
        }
        float speed = 8f + (0.5f * MathF.Floor(CalculateScore() / 10f));
        return Mathf.Min(speed, 30f);
    }
    // Update is called once per frame
    void Update()
    {

        if(State == GameState.Playing)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(CalculateScore());
        } else if (State == GameState.Dead)
        {
            scoreText.text = "Score: " + finalScore + "\nHigh Score: " + GetHighScore();
        }

        if(State == GameState.Intro && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            State = GameState.Playing;
            IntroUI.SetActive(false);
            EnemySpawner.SetActive(true);
            FoodSpawner.SetActive(true);
            GoldSpawner.SetActive(true);
            PlayStartTime = Time.time;
        }
        if (State == GameState.Playing && Lives <= 0)
        {
            PlayerScript.KillPlayer();
            EnemySpawner.SetActive(false);
            FoodSpawner.SetActive(false);
            GoldSpawner.SetActive(false);
            finalScore = Mathf.FloorToInt(CalculateScore());
            SaveHighScore();
            DeadUI.SetActive(true);
            State = GameState.Dead;
        }
        if (State == GameState.Dead && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("main");
        }
    }
}
