using UnityEngine;
using System.Collections;

public class Object_Interaction : MonoBehaviour {

	public GameObject Tank;
	GameObject TankClone;
	private Vector3 placePos;
	// Use this for initialization
	void Start () {
		TankClone = Instantiate (Tank, placePos, Quaternion.identity) as GameObject;
	}

	// Update is called once per frame
	void Update () {
		if (TankClone.GetComponent<model_manager> ().first_placement) {
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit)) {
				placePos = new Vector3 (hit.point.x, 1, hit.point.z);
				TankClone.transform.position = placePos;
			}
			if (Input.GetMouseButtonDown (0) && TankClone.GetComponent<model_manager> ().valid_placement) {
				TankClone.GetComponent<model_manager> ().first_placement = false;
				TankClone.GetComponent<model_manager> ().change_color('w');
			}
		}
	}
}
