using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject[] hazards;//小行星数组
    public Vector3 spawnValues;//随机生成小行星的位置

    public int hazardCount;//每一波小行星生成的数量
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private int score;

    private bool gameOver;
    private bool restart;

	// Use this for initialization
	void Start () {
        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        UpdateScore();

        StartCoroutine(SpawnWave());
	}
	
	// Update is called once per frame
	void Update () {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);//加载关卡
            }
        }
	}

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0;i < hazardCount;i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);//随机生成小行星
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' For Restart";
                restart = true;
                break;
            }
        }
        
    }

    //增加分数
    public void AddScore(int newScoreValues)
    {
        score += newScoreValues;
        UpdateScore();
    }

    //更新UI界面的积分显示
    void UpdateScore()
    {
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!!!";
        gameOver = true;
    }

}
