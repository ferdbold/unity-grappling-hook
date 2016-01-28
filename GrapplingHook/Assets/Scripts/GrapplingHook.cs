using UnityEngine;
using UnityEngine.Events;

namespace Simoncouche.Prototypes {

	[RequireComponent(typeof(FixedJoint2D))]
	public class GrapplingHook : MonoBehaviour {

		[SerializeField]
		private GrapplingRopeSection _grapplingRopeSectionPrefab;

		[SerializeField]
		private float _forceAmount = 50f;

		[SerializeField]
		private UnityEvent _onHit;

		private GrapplingRopeSection _firstRope;

		public UnityEvent onHit { get { return _onHit; } }
		public GrapplingController controller { get; set; }

		// COMPONENTS

		private Rigidbody2D _rigidbody;

		private FixedJoint2D _joint;
		public FixedJoint2D joint { get { return _joint; } }

		// METHODS

		public void Awake() {
			_rigidbody = GetComponent<Rigidbody2D>();
			_joint = GetComponent<FixedJoint2D>();

			_rigidbody.AddForce(transform.rotation * new Vector2(_forceAmount, 0), ForceMode2D.Impulse);
		}

		public void Start() {
			_firstRope = (GrapplingRopeSection)Instantiate(_grapplingRopeSectionPrefab, transform.position, transform.rotation);
			_firstRope.joint.connectedBody = _rigidbody;
			_firstRope.controller = controller;
		}

		public void Update() {
			if (Input.GetButtonDown("Fire")) {
				onHit.Invoke();
			}
		}

		public void OnCollisionEnter2D(Collision2D collision) {
			if (collision.gameObject.GetComponent<Grappleable>() != null) {
				_joint.enabled = true;
				_joint.connectedBody = collision.rigidbody;
				_joint.connectedAnchor = collision.transform.InverseTransformPoint(collision.contacts[0].point);
			}
		}
	}
}
