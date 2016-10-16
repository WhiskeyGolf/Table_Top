using UnityEngine;
using System.Collections;

public class player_manager : MonoBehaviour {

	game_manager gm;
	public GameObject[] army = new GameObject[50];
	public int army_points = 1500;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("game_manager").GetComponent<game_manager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gm.pre_game_selection) {
			select_initial_units ();
		}
	}

	void select_initial_units(){

	}
}
