using UnityEngine;
using System.Collections;

public class baddieSpawnerScript : MonoBehaviour {

    public GameObject baddie;
    private GameObject lastSpawned;
    private Rigidbody lastSpawnedRb;
    private System.DateTime nextSpawnTime;
    private Vector3 baddieDirection;

    // Use this for initialization
    void Start () {
        nextSpawnTime = System.DateTime.Now.AddMilliseconds(500);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (System.DateTime.Now> nextSpawnTime)
        {
            baddieDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            baddieDirection.Normalize();
            baddieDirection = baddieDirection * 100;
            nextSpawnTime = System.DateTime.Now.AddMilliseconds(2000);
            lastSpawned = (GameObject)Instantiate(baddie, transform.position+ baddieDirection, transform.rotation);
            lastSpawnedRb = lastSpawned.GetComponent<Rigidbody>();
            lastSpawnedRb.velocity = (transform.position - lastSpawned.transform.position).normalized * 10;
        }

    }
}
