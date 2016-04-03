using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject follow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.forward = follow.transform.forward;
	}
}
