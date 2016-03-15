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
        StartCoroutine(Evade());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x,startWait.y));
        while(true)
        {
            //如果敌机在x轴正方向，目标值取负值
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            //等待1-2秒用以机动
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;//目标机动位置归零
            //等待1-2秒再次机动
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));

        }
    }

    void FixedUpdate()
    {
        //取得敌机要移动到的目标机动位置
        float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
        GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x,boundary.xMin,boundary.xMax),0.0f,Mathf.Clamp(GetComponent<Rigidbody>().position.z,boundary.zMin,boundary.zMax));
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0,0,GetComponent<Rigidbody>().velocity.x * -tilt);
    
    }
}
