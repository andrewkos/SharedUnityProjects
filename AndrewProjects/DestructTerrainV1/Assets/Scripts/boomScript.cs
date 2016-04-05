using UnityEngine;
using System.Collections;

public class boomScript : MonoBehaviour {

    public System.DateTime killTime;
    private SphereCollider sphere;

	// Use this for initialization
	void Start () {
        Debug.Log("BOOM!");
        killTime = System.DateTime.Now.AddMilliseconds(1000);
        sphere = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (System.DateTime.Now > killTime) { Destroy(gameObject); }
        gameObject.transform.localScale *= 1.01f;
        sphere.radius *= 1.005f;

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("BOOM-HIT");
        if (col.gameObject.tag == "Replacer")
        {
            Destroy(col.gameObject);
        }
    }

}
