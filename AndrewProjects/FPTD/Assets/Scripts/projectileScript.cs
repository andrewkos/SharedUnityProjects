using UnityEngine;
using System.Collections;

public class projectileScript : MonoBehaviour {

    private System.DateTime killTime;

    // Use this for initialization
    void Start () {
        killTime = System.DateTime.Now.AddSeconds(3);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (System.DateTime.Now > killTime){ Destroy(gameObject); }
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Baddie")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
