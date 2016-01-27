using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Simoncouche.Prototypes {

	[RequireComponent(typeof(Rigidbody2D))]
	public class GrapplingController : MonoBehaviour {

		[Tooltip("Reference to the grappling hook prefab")]
		[SerializeField]
		private GrapplingHook _grapplingHookPrefab;

		private GrapplingHook _grapplingHookObj;

		public void Update () {
			if (Input.GetButtonDown("Fire") && !isGrapplingHookActive) {
				Fire();
			}
		}

		private void Fire() {
			_grapplingHookObj = (GrapplingHook)GameObject.Instantiate(_grapplingHookPrefab, transform.position, transform.rotation);
			_grapplingHookObj.onHit.AddListener(RecallGrapplingHook);
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
