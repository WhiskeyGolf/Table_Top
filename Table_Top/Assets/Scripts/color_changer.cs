using UnityEngine;
using System.Collections;

public class color_changer : MonoBehaviour {

	bool transparency;
	Component[] components;
	Color[] original_colors;
	Color color = Color.white;
	Color red = new Color(1.0f, 0.0f, 0.0f, 0.35f);
	Color green = new Color(0.0f, 1.0f, 0.0f, 0.35f);
	Color white = new Color(1.0f, 1.0f, 1.0f, 1.0f);

	// Use this for initialization
	void Start () {
		components = gameObject.GetComponentsInChildren<MeshRenderer> ();
		original_colors = new Color[components.Length];
		for (int i = 0; i < components.Length; i++) {
			original_colors [i] = components [i].gameObject.GetComponent<MeshRenderer> ().material.color;
		}
	}
	
	public void change_color(char x){
		switch (x) {
		case('r'):
			for (int i = 0; i < components.Length; i++) {
				components [i].gameObject.GetComponent<MeshRenderer> ().material.color = red;
			}
			transparency = true;
			break;
		case('g'):
			for (int i = 0; i < components.Length; i++) {
				components [i].gameObject.GetComponent<MeshRenderer> ().material.color = green;
			}
			transparency = true;
			break;
		case('w'):
			for (int i = 0; i < components.Length; i++) {
				components [i].gameObject.GetComponent<MeshRenderer> ().material.color = original_colors[i];
			}
			transparency = false;
			break;
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
