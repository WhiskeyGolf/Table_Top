using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class add_button : MonoBehaviour {

	public Dropdown dd;
	public GameObject tank;
	public GameObject infantry;
	public GameObject helicopter;
	public GameObject current_gameObject;
	int cost = 0;
	player_manager player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<player_manager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnButtonPress(){
		switch (dd.value) {
		case 0:
			cost = 200;
			current_gameObject = tank;
			break;
		case 1:
			cost = 50;
			current_gameObject = infantry;
			break;
		case 2:
			cost = 300;
			current_gameObject = helicopter;
			break;
		}
		if (cost <= player.army_points) {
			player.army_points -= cost;
			for (int i = 0; i < player.army.Length; i++) {
				if (player.army [i] == null) {
					player.army [i] = current_gameObject;
					print (player.army_points);
					break;
				}
			}
		}
	}


}
