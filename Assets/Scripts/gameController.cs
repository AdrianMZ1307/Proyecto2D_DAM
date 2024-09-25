using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    private string text = "G-A-M-E- -O-V-E-R";

    [SerializeField]
    public bool gameOver = false;
    [SerializeField]
    public bool mobile = false;

    [SerializeField]
    private GameObject scoreIndicator;


    [SerializeField]
    private GameObject timer;
    private float gameTime = 0f;

    [SerializeField]
    private GameObject restartButtons;

    [SerializeField]
    private GameObject mobileButtons;

    [Header("Enemys Spawn")]
    [SerializeField]
    private GameObject spawnPosition;
    [SerializeField]
    private GameObject[] enemies;

    [Header("Parametros de Juego")]
    [SerializeField]
    private float initialTime = 5f;
    [SerializeField]
    private float roundDelay = 1f;
    [SerializeField]
    private int enemyNumber = 5;
    [SerializeField]
    private float spawnDelay = 1f;

    private int score;

    private float contador = 0f;

    public float volume;

    private IEnumerator spawnRounds()
    {
        yield return new WaitForSeconds(initialTime);

        while (true)
        {
            for (int enemiesSpawned = 0; enemiesSpawned < enemyNumber; enemiesSpawned++)
            {
                Vector3 randomPos = new Vector3(
                    spawnPosition.transform.position.x,
                    Random.Range(spawnPosition.transform.position.y, spawnPosition.transform.position.y - 1f),
                    0f
                    );

                GameObject randomAsteroid = enemies[Random.Range(0, enemies.Length)];

                GameObject enemy = Instantiate(randomAsteroid, randomPos, Quaternion.Euler(new Vector3(0f, 0f, -90f)));

                enemy.transform.parent = spawnPosition.transform;

                if (gameOver)
                {
                    foreach (string s in text.Split('-'))
                    {
                        GameObject.FindGameObjectWithTag("GameOverLabel").GetComponent<Text>().text += s;
                        yield return new WaitForSeconds(0.125f);
                    }
                    if (mobile)
                    {
                        mobileButtons.SetActive(false);
                        if (restartButtons != null)
                        {
                            restartButtons.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 2f);
                        }
                    }
                    yield break;
                }

                yield return new WaitForSeconds(spawnDelay);
            }
            if (gameOver)
            {
                foreach (string s in text.Split('-'))
                {
                    GameObject.FindGameObjectWithTag("GameOverLabel").GetComponent<Text>().text += s;
                    yield return new WaitForSeconds(0.125f);
                }
                if (mobile)
                {
                    mobileButtons.SetActive(false);
                    if (restartButtons != null)
                    {
                        restartButtons.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 2f);
                    }
                }
                yield break;
            }
            yield return new WaitForSeconds(roundDelay);
        }

    }
    void Start()
    {
        Debug.Log("t" + transform.up);
        Debug.Log("v" + Vector3.up);
        score = 0;
        StartCoroutine(spawnRounds());
    }

    public void addScore(int puntuacion)
    {
        score += puntuacion;
        scoreIndicator.GetComponent<Text>().text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        GetComponent<AudioSource>().Stop();
        this.gameOver = true;
        GameObject.FindGameObjectWithTag("GameOverLabel").GetComponent<AudioSource>().Play();
        GameObject.FindGameObjectWithTag("GameOverLabel").GetComponent<AudioSource>().volume = 0.3f;

    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            {
                Application.Quit();
                return;
            }
        }

        if (!gameOver)
        {
            contador += Time.deltaTime;
            addScore((int)contador);

            gameTime += Time.deltaTime;

            int seconds = (int)(gameTime % 60);
            int minutes = (int)(gameTime / 60);
            int hours = (int)(gameTime / 3600);

            string timeStr = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

            timer.GetComponent<Text>().text = timeStr;
        }
        if (Input.GetKey(KeyCode.R) && gameOver)
        {
            GameObject.FindGameObjectWithTag("GameOverLabel").GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene("GameScene");
        }
        if (Input.GetKey(KeyCode.M) && gameOver)
        {
            GameObject.FindGameObjectWithTag("GameOverLabel").GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene("TitleScreenScene");
        }
    }
}
