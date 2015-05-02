using UnityEngine;
using System.Collections;

public class GenerateEnemy : MonoBehaviour {

	public GameObject objeto;
	public float tempoRespawn = 2f;
	private float tempoCorrido = 0f;


	// Use this for initialization
	void Start () {
		//Destroy (gameObject, 10f);
	}
	
	// Update is called once per frame
	void Update () {
		tempoCorrido += Time.deltaTime;
		if (tempoCorrido >= tempoRespawn) {
			Instantiate(objeto, new Vector3(Random.Range(-50.0f,50f),30.0f,30.0f), objeto.transform.rotation);
			//objeto.transform.position = new Vector3 (Random.Range(0.0f,Screen.width),objeto.transform.position.y,objeto.transform.position.z);
			tempoCorrido = 0f;
		}
	}
	
}
