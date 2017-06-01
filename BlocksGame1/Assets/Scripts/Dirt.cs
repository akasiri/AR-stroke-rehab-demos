using UnityEngine;
using System.Collections;

public class Dirt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    //void OnCollisionStay2D(Collision2D collision) {
    //    foreach (ContactPoint2D contact in collision.contacts) {
    //        print(contact.collider.name + " hit " + contact.otherCollider.name);
    //        Debug.DrawRay(contact.point, contact.normal, Color.red);
    //    }
    //}

    public void GetCleaned () {
        gameObject.transform.parent.gameObject.GetComponent<DirtManager>().ammountOfDirt -= 1;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
