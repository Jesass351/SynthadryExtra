using UnityEngine;
using System.Collections;

public class TriggerEnt : MonoBehaviour {
	
	public GameObject CarTrue;
	public GameObject CarFalse;
	public Transform CarTrueBody;
	private bool enter;
	private GameObject player;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame


	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			enter = true;
		}
	}
	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			enter = false;
		}
	}
}