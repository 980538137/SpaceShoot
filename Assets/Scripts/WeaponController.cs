using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
    public GameObject shot;//子弹
    public Transform shotSpawn;//子弹发射位置
    public float delay;//发射子弹的延迟
    public float fireRate;//子弹发射率

	// Use this for initialization
	void Start () {
        InvokeRepeating("Fire",delay,fireRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        GetComponent<AudioSource>().Play();
    }
}
