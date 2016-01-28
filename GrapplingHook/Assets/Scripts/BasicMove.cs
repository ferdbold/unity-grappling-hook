using UnityEngine;
using System.Collections;

namespace Simoncouche.Prototypes {
	
	public class BasicMove : MonoBehaviour {

		[SerializeField]
		private float _moveSpeed = 5.0f;

		public void Update () {
			transform.Translate(new Vector3(_moveSpeed * Time.deltaTime, 0, 0));
		}
	}
}
