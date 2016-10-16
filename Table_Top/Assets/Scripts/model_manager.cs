using UnityEngine;
using System.Collections;

public class model_manager : MonoBehaviour {

	Color color = Color.white;
	Color red = new Color(1.0f, 0.0f, 0.0f, 0.35f);
	Color green = new Color(0.0f, 1.0f, 0.0f, 0.35f);
	Color white = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	int health;
	int move_distance;
	int attack_damage;
	int defense;
	public bool first_placement = true;
	public bool valid_placement = false;

	bool transparency;
	Component[] components;

	// Use this for initialization
	void Start () {
		switch (gameObject.tag) {
		case("tank"):
			health = 100;
			move_distance = 12;
			attack_damage = 50;
			defense = 25;
			break;
		}
		components = gameObject.GetComponentsInChildren<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void change_color(char x){
		switch (x) {
		case('r'):
			color = red;
			transparency = true;
			break;
		case('g'):
			color = green;
			transparency = true;
			break;
		case('w'):
			color = white;
			transparency = false;
			break;
		}
		for (int i = 0; i < components.Length; i++) {
			components [i].gameObject.GetComponent<MeshRenderer> ().material.color = color;
		}
		change_rendering_mode ();
	}

	void change_rendering_mode(){
		if (transparency) {
			for (int i = 0; i < components.Length; i++) {
				components [i].gameObject.GetComponent<MeshRenderer> ().material.SetFloat ("_Mode", 3);
				components [i].gameObject.GetComponent<MeshRenderer> ().material.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
				components [i].gameObject.GetComponent<MeshRenderer> ().material.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
				components [i].gameObject.GetComponent<MeshRenderer> ().material.SetInt ("_ZWrite", 0);
				components [i].gameObject.GetComponent<MeshRenderer> ().material.DisableKeyword ("_ALPHATEST_ON");
				components [i].gameObject.GetComponent<MeshRenderer> ().material.DisableKeyword ("_ALPHABLEND_ON");
				components [i].gameObject.GetComponent<MeshRenderer> ().material.EnableKeyword ("_ALPHAPREMULTIPLY_ON");
				components [i].gameObject.GetComponent<MeshRenderer> ().material.renderQueue = 3000;
			}
		} else {
			for (int i = 0; i < components.Length; i++) {
				components [i].gameObject.GetComponent<MeshRenderer> ().material.SetFloat ("_Mode", 0);
				components [i].gameObject.GetComponent<MeshRenderer> ().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
				components [i].gameObject.GetComponent<MeshRenderer> ().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
				components [i].gameObject.GetComponent<MeshRenderer> ().material.SetInt("_ZWrite", 1);
				components [i].gameObject.GetComponent<MeshRenderer> ().material.DisableKeyword("_ALPHATEST_ON");
				components [i].gameObject.GetComponent<MeshRenderer> ().material.DisableKeyword("_ALPHABLEND_ON");
				components [i].gameObject.GetComponent<MeshRenderer> ().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				components [i].gameObject.GetComponent<MeshRenderer> ().material.renderQueue = -1;
			}
		}
	}
}
