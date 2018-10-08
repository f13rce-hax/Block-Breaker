using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip crack; 
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	public Color color;

	private int maxHits;
	private int timesHit;
 	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start ()
	{
		isBreakable = (this.tag == "Breakable");
		// keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
			 
		} 

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.8f);
		if (isBreakable) {
			HandleHits();
		}
 
	}

	void HandleHits ()
	{	
		timesHit++;
		maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			SmokePuff();
			levelManager.BrickDestroyed();
			Destroy (gameObject);
		} else {
			LoadSprites();

			}
	}

	void SmokePuff ()
	{
		GameObject smokePuff = Object.Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}else
			Debug.LogError ("Brick Sprite Missing");
	}


}
