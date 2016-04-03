using UnityEngine;
using System.Collections;

public class RotatingScript : MonoBehaviour {

    public bool isActivated;
    public GameObject projectile;
    private GameObject lastSpawned;
    private Rigidbody lastSpawnedRb;

    void Start()
    {

    }

	// Update is called once per frame
	void FixedUpdate () {

        if (isActivated)
        {
            foreach (Touch touch in Input.touches)
            {
                transform.Rotate(new Vector3(touch.deltaPosition.y, -touch.deltaPosition.x, 0));
            }
        }
    }

    public void Fire()
    {
        lastSpawned = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
        lastSpawnedRb = lastSpawned.GetComponent<Rigidbody>();
        lastSpawnedRb.velocity = transform.forward*20;
    }
}
