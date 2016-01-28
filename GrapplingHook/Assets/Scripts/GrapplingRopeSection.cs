using UnityEngine;
using System.Collections;

namespace Simoncouche.Prototypes {

	[RequireComponent(typeof(SpringJoint2D))]
	public class GrapplingRopeSection : MonoBehaviour {

		[SerializeField]
		private GrapplingRopeSection _grapplingRopeSectionPrefab;

		private GrapplingRopeSection _nextRopeSection;
		public GrapplingController controller { get; set; }

		// COMPONENTS

		private SpringJoint2D _joint;
		public SpringJoint2D joint { get { return _joint; } }

		private Rigidbody2D _rigidbody;
		public new Rigidbody2D rigidbody { get { return _rigidbody; } }

		// METHODS

		public void Awake() {
			_joint = GetComponent<SpringJoint2D>();
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		public void Start() {
			controller.joint.connectedBody = _rigidbody;
		}

		public void SpawnRope() {
			Vector3 nextRopeSectionPosition = transform.position;
			nextRopeSectionPosition -= transform.right * transform.localScale.x;

			_nextRopeSection = (GrapplingRopeSection)Instantiate(_grapplingRopeSectionPrefab, nextRopeSectionPosition, transform.rotation);
			_nextRopeSection.joint.connectedBody = _rigidbody;
			_nextRopeSection.controller = controller;
		}
	}
}
