using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject[] hazards;//小行星数组
    public Vector3 spawnValues;//随机生成小行星的位置

    public int hazardCount;//每一波小行星生成的数量
    public float spawnWait;
    public float startWait;
    public float waveWait;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWave());
	}
	
	// Update is called once per frame
	void Update () {
        
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
        }
        
    }

}
