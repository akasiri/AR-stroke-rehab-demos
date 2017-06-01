using UnityEngine;
using System.Collections;

public class DirtManager : MonoBehaviour {

    public int ammountOfDirt = 0;
    public int minDirtOnPlate = 1;
    public int maxDirtOnPlate = 30;
    public GameObject dirt;

	// Use this for initialization
	void Start () {
        if (ammountOfDirt == 0) {
            ammountOfDirt = Random.Range(minDirtOnPlate, maxDirtOnPlate);
        }

        SpawnDirt();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnDirt () {
        for (int i = 0; i < ammountOfDirt; i++) {
            Vector2 randomPos = Random.insideUnitCircle * GetComponent<CircleCollider2D>().radius;
            GameObject newDirt = (GameObject) Instantiate(dirt, new Vector3(randomPos.x + gameObject.transform.position.x, randomPos.y + gameObject.transform.position.y), transform.rotation);
            newDirt.transform.parent = gameObject.transform;
        }
    }
}
