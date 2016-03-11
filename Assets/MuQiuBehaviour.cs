using UnityEngine;
using System.Collections;

public class MuQiuBehaviour : MonoBehaviour {

    public float speed = 300;
    private Vector3 initPos;

    Rigidbody body;

	// Use this for initialization
	void Start () {
        initPos = transform.position;

        body = transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.localPosition += Vector3.back * Time.deltaTime * speed;

        // 按下后一直发力
        //if (Input.GetKey(KeyCode.A))
        //{
        //    Debug.Log("左");
        //    body.AddForce(Vector3.left * speed);
        //}
        //else if (Input.GetKey(KeyCode.W))
        //{
        //    Debug.Log("前");
        //    body.AddForce(Vector3.forward * speed);
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    Debug.Log("后");
        //    body.AddForce(Vector3.back * speed);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    Debug.Log("右");
        //    body.AddForce(Vector3.right * speed);
        //}


        // 单次按键用力
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    body.AddForce(Vector3.left * speed);
        //}
        //else if (Input.GetKeyDown(KeyCode.S))
        //{
        //    body.AddForce(Vector3.back * speed);
        //}
        //else if (Input.GetKeyDown(KeyCode.W))
        //{
        //    body.AddForce(Vector3.forward * speed);
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    body.AddForce(Vector3.right * speed);
        //}
        

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("touch");
        }
	}

    public void ResetMuQiuPos()
    {
        //transform.position = initPos;

        //body.AddForce(new Vector3(90, 0, 0));
    }

    // 在一个方向上施加力
    public void AddForce(Vector3 force)
    {
        body.AddForce(force * speed);
    }

    // 直接设置成位置,用于飞机等游戏操作还行。。
    public void SetPos(Vector3 pos)
    {
        body.transform.localPosition += pos * speed / 100;
    }
}
