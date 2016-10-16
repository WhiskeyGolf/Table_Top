using UnityEngine;
using System.Collections;

public class starting_boxes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "tank") {
			col.GetComponent<model_manager> ().valid_placement = true;
			col.GetComponent<model_manager> ().change_color('g');
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "tank") {
			col.GetComponent<model_manager> ().valid_placement = false;
			col.GetComponent<model_manager> ().change_color('r');
		}
	}

}
