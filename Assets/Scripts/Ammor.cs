using UnityEngine;
using System.Collections;

public class Ammor : MonoBehaviour {

	//Direction to travel
	public Vector3 Direction = Vector3.up;
	//Speed to travel
	public float Speed = 20.0f;
	//Lifetime in seconds
	public float Lifetime = 10.0f;

	// Use this for initialization
	void Start () {
		Invoke ("DestroyMe", Lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		//Update travel in direction at speed
		transform.position += Direction * Speed * Time.deltaTime;
		//DestroyMe ();
	}

	void DestroyMe(){
			Destroy (gameObject);
		
	}
}
