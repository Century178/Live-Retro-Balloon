using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject gameOverScreen;

    [Header("Score")]
    [SerializeField] private float timerSpeed = 1;
    [SerializeField] private Text scoreText;
    private float scoreTimer = 1;
    private float score;

    private bool gameOver;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;

        Time.timeScale = 1;

        gameOverScreen.SetActive(false);

        gameOver = false;
    }

    private void Update()
    {
        scoreTimer -= Time.deltaTime * timerSpeed;
        if (scoreTimer <= 0)
        {
            score++;
            scoreText.text = score.ToString();
            scoreTimer = 1;
        }

        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        gameOverScreen.SetActive(true);

        gameOver = true;
    }
}
