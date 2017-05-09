using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyStateManager : MonoBehaviour {

    public float hungryRate = 0.005f;

    private Animator anim;

    void Start () {
        anim = GetComponent<Animator>();

        // DEBUG
        anim.SetTrigger("cry");
    }

    void Update() {
        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).IsName("idle"));
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle") && Random.Range(0f, 1f) < hungryRate) {
            anim.SetTrigger("cry");
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("chew")) {
            // manually set the distance back to 0 incase the game drops tracking when the player's hand is in the clear zone
            SetDistance(0f);
        }
    }

    public void SetDistance(float distance) {
        anim.SetFloat("distance from mouth", distance);
    }

    public void StartHighlight() {
        GetComponent<SpriteRenderer>().sortingOrder = 10;
        for( int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = 9;
        }
    }

    public void StopHighlight() {
        GetComponent<SpriteRenderer>().sortingOrder = 0;
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
            transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }
}
