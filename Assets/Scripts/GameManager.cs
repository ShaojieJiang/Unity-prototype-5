using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI gameOverText;
    public bool isGameAlive;
    public Button restartButton;
    private GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen = GameObject.Find("Title Screen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(isGameAlive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameAlive = false;
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        score = 0;
        isGameAlive = true;
        spawnRate /= difficulty;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
