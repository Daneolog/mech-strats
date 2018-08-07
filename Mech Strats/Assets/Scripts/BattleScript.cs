using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Debug.Log(screenPos);
    }
}
