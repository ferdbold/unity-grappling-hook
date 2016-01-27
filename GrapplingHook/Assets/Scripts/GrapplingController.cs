using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Simoncouche.Prototypes {

	[RequireComponent(typeof(Rigidbody2D))]
	public class GrapplingController : MonoBehaviour {

		[Tooltip("Reference to the grappling hook prefab")]
		[SerializeField]
		private GrapplingHook _grapplingHookPrefab;

		private Rigidbody2D _rigidbody;
		private GrapplingHook _grapplingHookObj;

		public void Awake() {
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		public void Update () {
			if (Input.GetButtonDown("Fire") && !isGrapplingHookActive) {
				Fire();
			}
		}

		private void Fire() {
			_grapplingHookObj = (GrapplingHook)GameObject.Instantiate(_grapplingHookPrefab, transform.position, transform.rotation);
			_grapplingHookObj.onHit.AddListener(RecallGrapplingHook);
			_grapplingHookObj.springJoint.connectedBody = _rigidbody;
		}

		public void RecallGrapplingHook() {
			GameObject.Destroy(_grapplingHookObj.gameObject);
			_grapplingHookObj = null;
		}

		private bool isGrapplingHookActive {
			get {
				return _grapplingHookObj != null;
			}
		}
	}
}
