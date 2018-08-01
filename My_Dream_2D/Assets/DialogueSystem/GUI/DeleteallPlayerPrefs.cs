using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteallPlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
