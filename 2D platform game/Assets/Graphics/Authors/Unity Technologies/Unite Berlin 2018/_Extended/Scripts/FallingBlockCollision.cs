using UnityEngine;

public class FallingBlockCollision : MonoBehaviour
{
	Rigidbody2D rigidBody;
	BoxCollider2D box;
	AudioSource audioSource;
	LayerMask groundMask;
	int groundLayer;
	public GameObject stoneLayer;


	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		box = GetComponent<BoxCollider2D>();
		audioSource = GetComponent<AudioSource>();

		groundMask = LayerMask.GetMask("Platforms");
		groundLayer = LayerMask.NameToLayer("Platforms");
	}

	public void Fall()
	{
		rigidBody.bodyType = RigidbodyType2D.Dynamic;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer != groundLayer)
			return;

		stoneLayer.layer = 10;
		rigidBody.bodyType = RigidbodyType2D.Static;
		
		Vector3 pos = rigidBody.position;
		RaycastHit2D hit;

		hit = Physics2D.Raycast(pos, Vector2.down, 1f, groundMask);
		pos.y = hit.point.y + .01f;
		transform.position = pos;

		box.usedByComposite = true;
		Destroy(rigidBody);

		audioSource.Play();
		stoneLayer.transform.position = new Vector3(stoneLayer.transform.position.x, stoneLayer.transform.position.y, -0.5f);
	}
}
