using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

    public Transform cube;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(cube.position, Vector3.up, 4f);
	}
}
