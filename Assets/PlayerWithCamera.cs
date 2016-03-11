using UnityEngine;
using System.Collections;

public class PlayerWithCamera : MonoBehaviour {

    const float rotateAngle = 30f; // 旋转速率
    const float moveVelocity = 50f; // 移动速率
    const float upForce = 200f; // 起跳力度

    bool somethingDown = false;

    Rigidbody player;

    // Use this for initialization
    void Start () {
        player = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        //transform.Rotate(Vector3.up, -Time.deltaTime * rotateAngle);

        IsDown();

        if (somethingDown)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.AddForce(Vector3.forward * moveVelocity);
            }

            if (Input.GetKey(KeyCode.S))
            {
                player.AddForce(Vector3.back * moveVelocity);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -Time.deltaTime * rotateAngle);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, Time.deltaTime * rotateAngle);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                player.AddForce(Vector3.up * upForce, ForceMode.Force);
            }
        }
	}

    void IsDown()
    {
        if (Input.anyKeyDown)
        {
            somethingDown = true;
        }
    }
}
