using UnityEngine;
using System.Collections;

public class shootingScript : MonoBehaviour {

    private System.DateTime nextShootTime;
    public int reloadMilliSecs;
    public GameObject projectile;
    private GameObject lastSpawned;
    private Rigidbody lastSpawnedRb;
    private System.DateTime chargeStartTime;
    private bool charged;

    // Use this for initialization
    void Start () {
        nextShootTime = System.DateTime.Now;
        charged = false;
    }

    
	void FixedUpdate () {

        double chargeTime;

        if (Input.GetButton("Fire1") && (nextShootTime < System.DateTime.Now) && (charged == false))
        {
            chargeStartTime = System.DateTime.Now;
            Debug.Log("Charging!");
            charged = true;
        }
        if (Input.GetButtonUp("Fire1") && charged)
        {
            nextShootTime = System.DateTime.Now.AddMilliseconds(reloadMilliSecs);
            chargeTime = (System.DateTime.Now - chargeStartTime).TotalMilliseconds;
            Debug.Log("FIRE - " + chargeTime.ToString());
            charged = false;
            lastSpawned = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            lastSpawnedRb = lastSpawned.GetComponent<Rigidbody>();
            lastSpawnedRb.velocity = transform.forward * Mathf.Min((float)chargeTime / 20,10000);
        }
    }
}
