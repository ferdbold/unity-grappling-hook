using UnityEngine;

public class Grappleable : MonoBehaviour {

	private Rigidbody2D _rigidbody;
	private FixedJoint2D _joint;

	public void Awake() {
		_rigidbody = GetComponent<Rigidbody2D>();
		_joint = GetComponent<FixedJoint2D>();
	}

	public void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "GrapplingHook") {
			_joint.connectedBody = collision.rigidbody;
			collision.rigidbody.mass = _rigidbody.mass;
		}
	}
}
