using UnityEngine;
using System.Collections;

public class PirateSpriteController : MonoBehaviour {
	public Sprite normalHead;
	public Sprite normalChest;
	public Sprite normalArms;
	public Sprite normalLegs;

	public Sprite backHead;
	public Sprite backChest;
	public Sprite backArms;
	public Sprite backLegs;

	public Sprite turnedHead;
	public Sprite turnedChest;
	public Sprite turnedArms;
	public Sprite turnedLegs;

	private SpriteRenderer headRenderer;
	private SpriteRenderer chestRenderer;
	private SpriteRenderer armsRenderer;
	private SpriteRenderer legsrenderer;

	private bool facingRight = false;
	private bool facingLeft = true;
	private bool facingUp = false;
	private bool facingDown = true;

	// Use this for initialization
	void Start () {
		headRenderer = transform.FindChild("Head").GetComponent<SpriteRenderer>();
		chestRenderer = transform.FindChild("Chest").GetComponent<SpriteRenderer>();
		armsRenderer = transform.FindChild("Arms").GetComponent<SpriteRenderer>();
		legsrenderer = transform.FindChild("Legs").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			headRenderer.sprite = turnedHead;
			chestRenderer.sprite = turnedChest;
			armsRenderer.sprite = turnedArms;
			legsrenderer.sprite = turnedLegs;

			if(facingRight){
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
			}

			facingRight = false;
			facingLeft = true;
		}

		if(Input.GetKey(KeyCode.RightArrow)){
			headRenderer.sprite = turnedHead;
			chestRenderer.sprite = turnedChest;
			armsRenderer.sprite = turnedArms;
			legsrenderer.sprite = turnedLegs;

			if(facingLeft){
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
			}
			
			facingRight = true;
			facingLeft = false;
		}

		if(Input.GetKey(KeyCode.UpArrow)){
			headRenderer.sprite = backHead;
			chestRenderer.sprite = backChest;
			armsRenderer.sprite = backArms;
			legsrenderer.sprite = backLegs;
		}
	
		if(Input.GetKey(KeyCode.DownArrow)){
			headRenderer.sprite = normalHead;
			chestRenderer.sprite = normalChest;
			armsRenderer.sprite = normalArms;
			legsrenderer.sprite = normalLegs;
		}

	}
}
