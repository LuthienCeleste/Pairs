using UnityEngine;
using System.Collections;

public class ColorRandom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.color = new Color (Random.value, Random.value, Random.value);
	
	}
}
