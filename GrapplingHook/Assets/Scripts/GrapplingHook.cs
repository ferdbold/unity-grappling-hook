using UnityEngine;
using UnityEngine.Events;

namespace Simoncouche.Prototypes {

	[RequireComponent(typeof(Rigidbody2D))]
	public class GrapplingHook : MonoBehaviour {

		private Rigidbody2D _rigidbody;

		[SerializeField]
		private UnityEvent _onHit;

		public void Awake() {
			_rigidbody = GetComponent<Rigidbody2D>();
			_rigidbody.AddForce(new Vector2(1, 1), ForceMode2D.Impulse);
		}

		public void Update() {
			if (Input.GetButtonDown("Fire")) {
				onHit.Invoke();
			}
		}

		public UnityEvent onHit { get { return _onHit; } }
	}
}
