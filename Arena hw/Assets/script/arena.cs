using UnityEngine;
using System.Collections;

public class arena : MonoBehaviour {
	public Vector3 destination;
	public GameObject victim;
	public GameObject vicBlueprint;
	public float seekSpeed = 0.2f;
	Vector3 nearbyPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		destination = victim.transform.position;
		transform.LookAt (destination);

		if (Vector3.Distance (destination, transform.position) > 1f) {
			GetComponent<Rigidbody> ().AddForce (Vector3.Normalize (destination - transform.position) * seekSpeed);
		} else {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GameObject temp = victim;

			MakeVic ();
			Destroy (temp);

	}

	if (Input.GetKeyDown ("d")) {
		Destroy(victim);
	}
}
	void MakeVic(){

		Debug.Log ("make dat vic");

		nearbyPos = destination + Random.insideUnitSphere * 1.5f;

		GameObject clone = Instantiate (vicBlueprint, nearbyPos, Quaternion.identity) as GameObject;

		victim = clone;
	}
 
}