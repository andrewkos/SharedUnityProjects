using UnityEngine;
using System.Collections;

public class replacerScript : MonoBehaviour {

    public GameObject explosion;
    public GameObject replacerCube;
    private Vector3 size;
    private Vector3 centre;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag == "Projectile")
        {
            Instantiate(explosion, col.contacts[0].point, transform.rotation);
            Destroy(col.gameObject);
            centre = transform.position;
            size = transform.localScale;
            size = new Vector3(Mathf.RoundToInt(size.x), Mathf.RoundToInt(size.y), Mathf.RoundToInt(size.z));
            Destroy(gameObject);
            for (int i = 1; i <= size.x; i++)
            {
                for (int j = 1; j <= size.y; j++)
                {
                    for (int k = 1; k <= size.y; k++)
                    {
                        Instantiate(replacerCube, centre - size / 2 + new Vector3(i, j, k), transform.rotation);
                    }
                }
            }
        }
	
	}
}
