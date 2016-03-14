using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour {

    public Boundary boundary;
    public float tilt;//倾斜
    public float dodge;//躲闪
    public float smoothing;
    public Vector2 startWait;//开始机动的时候的等待时间
    public Vector2 maneuverTime;//机动时间
    public Vector2 maneuverWait;//机动后等待再次机动的时间

    private float currentSpeed;//当前敌人的速度
    private float targetManeuver;//机动的目标值
	// Use this for initialization
	void Start () {
        currentSpeed = GetComponent<Rigidbody>().velocity.z;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
