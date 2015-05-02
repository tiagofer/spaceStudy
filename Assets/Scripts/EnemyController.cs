using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	//public Slider healthSlider;

	//Enemy health
	public int health = 100;
	//Enemy move speed in units per second
	public float Speed = 1.0f;
	
	//public GameObject enemy = null;

	public float SpeedY = 1.0f;
	//Enemy min and max X position in world space (to keep Enemy in screen)
	public Vector2 MinMaxX = Vector2.zero;

	public int hit = 0;


	// Use this for initialization
	void Start () {
		//hit = 0;
		Destroy (gameObject, 10f);
		//healthSlider.GetComponent<Transform> ().position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//hit = false;
		//Ping pong enemy position
//		transform.position = new Vector3(MinMaxX.x + Mathf.PingPong(Time.time * Speed, 1.0f) *
//		                                 (MinMaxX.y - MinMaxX.x), transform.position.y + Time.deltaTime * SpeedY, transform.position.z);
		transform.position = new Vector3 (transform.position.x, transform.position.y + Time.deltaTime * SpeedY, transform.position.z);
		//GeneratedEnemy ();
	}

	//Trigger enter
	void OnTriggerEnter(Collider other)
	{ 

		if (other.gameObject.CompareTag("fireEnemy")){
			hit += 10;
			Destroy (gameObject);
			Destroy (other.gameObject);
			Debug.Log(hit);


		}


	}
	
}
