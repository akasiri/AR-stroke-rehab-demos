using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class __test_menu_gamemanager : MonoBehaviour {

    public MenuBehavior testObj;

	void Update () {
		if (testObj != null) {
            GetComponent<Image>().color = Color.green;
        }
        else {
            GetComponent<Image>().color = Color.red;
        }
    }
}
