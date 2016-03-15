using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public GameController gameController;
    public int scoreValue;

	// Use this for initialization
	void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
            if (gameController == null)
            {
                Debug.Log("Cannot find 'GameController' Scripts");
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);//在小行星销毁的位置生成爆炸效果
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, transform.rotation);//在玩家飞机销毁的位置生成爆炸效果
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);//销毁和小行星碰撞的物体
        Destroy(this.gameObject);//销毁小行星
    }
}
