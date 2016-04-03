using UnityEngine;
using System.Collections;

public class TowerControllerScript : MonoBehaviour {

    public GameObject[] towers;
    private int selectedTower;
    private RotatingScript currentTower;
    public Camera mainCam;
    private CameraScript camScript;

	// Use this for initialization
	void Start () {
        selectedTower = 0;
        camScript = mainCam.GetComponent<CameraScript>();
        SelectTower(0);
        
    }
	
    void SelectTower(int i)
    {
        currentTower = towers[i].GetComponent<RotatingScript>();
        currentTower.isActivated = true;
        mainCam.transform.position = towers[i].transform.position + new Vector3(0, 0.4f, 0);
        mainCam.transform.forward = towers[i].transform.forward;
        camScript.follow = towers[i];
    }

    void nextTower()
    {
        currentTower.isActivated = false;
        selectedTower++;
        if (selectedTower >= towers.Length){ selectedTower = 0; }
        SelectTower(selectedTower);
    }

    void prevTower()
    {
        currentTower.isActivated = false;
        selectedTower--;
        if (selectedTower < 0) { selectedTower = towers.Length-1; }
        SelectTower(selectedTower);
    }

    void Fire()
    {
        currentTower.Fire();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
