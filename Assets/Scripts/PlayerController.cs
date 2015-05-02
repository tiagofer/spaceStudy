using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;

	public Slider healthySlider;

	public Slider turboSlider;

	public Vector2 minMax = Vector2.zero;

	public Image fill;

	public Image fillTurbo;

	public int health = 100;

	public float ReloadDelay =0.2f;

	public GameObject PrefabAmmo = null;

	public GameObject GunPosition = null;

	private bool WeaponsActivated = true;

	private int turbo;

	private float forceTurbo = 100.0f;

	private float lifeTime;

	private float turboTime = 5.0f;

	public int score;

	private string scoreString;

	public Text scoreText;

	public EnemyController checkCollision;
	

	//public float smooth = 2.0f;

	// Use this for initialization
	void Start () {
		healthySlider.minValue = 0.0f;
		healthySlider.maxValue = 100.0f;
		healthySlider.value = health;

		turboSlider.minValue = 0.0f;
		turboSlider.maxValue = 100.0f;
		turboSlider.value = 100.0f;
		turbo = 3;

		score = 0;

		//CheckHit (checkCollision.hit);
	
		//transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x + Input.GetAxis ("Horizontal") * speed * Time.deltaTime, minMax.x, minMax.y), transform.position.y, transform.position.z);

		lifeTime += Time.deltaTime;
		//if (lifeTime > turboTime) {
			if (forceTurbo >= 0) {
				if (Input.GetButtonDown ("Jump") && forceTurbo > 0) {
					speed = 100f;
					forceTurbo -= 10;
					turboSlider.value -= 10;
				}
				if (Input.GetButtonUp("Jump") || forceTurbo <= 0) {
					speed = 60.0f;
				}
			}
			//lifeTime = 0f;
		//}

	}

	//Check input
	void LateUpdate()
	{
		//If fire button press, then shoot ammo
		if(Input.GetButton("Fire1") && WeaponsActivated)
		{
			//Create new ammo object
			Instantiate(PrefabAmmo, GunPosition.transform.position, PrefabAmmo.transform.rotation);
			//Deactivate weapons
			WeaponsActivated = false;
			Invoke("ActivateWeapons", ReloadDelay);
		}

			score += checkCollision.hit;
			scoreString = score.ToString ();
			scoreText.text = scoreString;
			Debug.Log (score);


	}
	//Enable fire
	void ActivateWeapons()
	{
		WeaponsActivated = true;
	}

	void OnTriggerEnter(Collider other) {

		//Debug.Log (healthySlider.value);
//		Destroy (gameObject);
		if (healthySlider.value <= 0.0f){
			Destroy(gameObject);
		} else if (other.gameObject.CompareTag("enemy")) {
			healthySlider.value -= 25.0f;

			if (healthySlider.value <= 25.0f){
				fill.color = Color.red;
			}
//			Debug.Log(gameObject.name);
//			Debug.Log(other.name);
		}

	}

//	void CheckHit(bool colision){
//		if (colision) {
//			score += 10;
//			scoreString = score.ToString();
//			scoreText.text = scoreString;
//			Debug.Log(score);
//		}
//	}

}
