using UnityEngine;
using System.Collections;

public class PlateManager : MonoBehaviour {

    public int platesWashed = 0;

    public GameObject sponge;

    public GameObject plate1;
    public GameObject plate2;
    public GameObject plate3;
    public GameObject plate4;
    public GameObject plate5;
    public GameObject plate6;

    ArrayList platePrefabs;

    private GameObject currentPlate;
    private GameObject nextPlate;

	// Use this for initialization
	void Start () {
        platePrefabs = new ArrayList();
        platePrefabs.Add(plate1);
        platePrefabs.Add(plate2);
        platePrefabs.Add(plate3);
        platePrefabs.Add(plate4);
        platePrefabs.Add(plate5);
        platePrefabs.Add(plate6);

        currentPlate = SpawnPlate(new Vector2( 0, 0));
        nextPlate = SpawnPlate(new Vector2( 15, 0));
	}

    // Update is called once per frame
    void Update() {

        if (currentPlate.GetComponent<DirtManager>().ammountOfDirt == 0) {
            currentPlate.transform.position = new Vector2(currentPlate.transform.position.x - 0.1f, currentPlate.transform.position.y);
            nextPlate.transform.position = new Vector2(nextPlate.transform.position.x - 0.1f, nextPlate.transform.position.y);

            if (currentPlate.transform.position.x < -15) {
                GameObject old = currentPlate;
                currentPlate = nextPlate;
                nextPlate = SpawnPlate(new Vector2(15, 0));

                platesWashed += 1; // TODO updates this a bit late. Someone may finish washing a plate but it won't be recorded until the plate has left the screen.
                old.SetActive(false);
                Destroy(old);
            }
        }

    }

    GameObject SpawnPlate (Vector2 spawnPoint) {
        GameObject plate = (GameObject) Instantiate((GameObject) platePrefabs[Random.Range(0, 5)], spawnPoint, transform.rotation);
        plate.transform.parent = gameObject.transform;
        Physics2D.IgnoreCollision(plate.GetComponent<Collider2D>(), sponge.GetComponent<Collider2D>());

        return plate;
    }
}
