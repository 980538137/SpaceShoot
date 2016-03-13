using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [System.Serializable]
    public class Boundary
    {
        public float xMin;
        public float xMax;
        public float zMin;
        public float zMax;
    }
    public float speed;
    public Boundary boundary;

    public GameObject shot;//子弹的预制体
    public Transform shotSpawn;//子弹出生位置
    public float fireRate;//子弹发射率

    private float nextFire;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);//生成一枚子弹
        }
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x,boundary.xMin,boundary.xMax), 0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z,boundary.zMin,boundary.zMax));
    }
}
