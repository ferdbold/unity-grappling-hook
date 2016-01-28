using UnityEngine;

namespace Simoncouche.Prototypes {

	[RequireComponent(typeof(SpringJoint2D))]
	public class GrapplingController : MonoBehaviour {

		[Tooltip("Reference to the grappling hook prefab")]
		[SerializeField]
		private GrapplingHook _grapplingHookPrefab;

		private float _spawnRopeDistanceThreshold = 1f;

		private GrapplingHook _grapplingHookObj;

		// COMPONENTS

		private SpringJoint2D _joint;
		public SpringJoint2D joint { get { return _joint; } }

		// METHODS

		public void Awake() {
			_joint = GetComponent<SpringJoint2D>();
		}

		public void Update() {
			if (Input.GetButtonDown("Fire") && !isGrapplingHookActive) {
				Fire();
			}

			Debug.Log(Vector3.Distance(transform.position, _joint.connectedBody.position));
			if (isGrapplingHookActive && Vector3.Distance(transform.position, _joint.connectedBody.position) > _spawnRopeDistanceThreshold) {
				_joint.connectedBody.GetComponent<GrapplingRopeSection>().SpawnRope();
			}
		}

		private void Fire() {
			_grapplingHookObj = (GrapplingHook)Instantiate(_grapplingHookPrefab, transform.position, transform.rotation);
			_grapplingHookObj.controller = this;
			_grapplingHookObj.onHit.AddListener(RecallGrapplingHook);
			_joint.enabled = true;
		}

		public void RecallGrapplingHook() {
			Destroy(_grapplingHookObj.gameObject);
			_grapplingHookObj = null;
		}

		private bool isGrapplingHookActive {
			get {
				return _grapplingHookObj != null;
			}
		}
	}
}
