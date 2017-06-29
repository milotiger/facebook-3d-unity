using UnityEngine;
using System.Collections;

public enum MoveMode
{
	Move,
	Return,
	None
};

public class MoveToPosition : MonoBehaviour {
	private Vector3 OriginPosition;
	private Vector3 OriginScale;
	private Quaternion OriginRotation;
	private Transform End;
	private MoveMode moveMode = MoveMode.Return;
	private ParticleController particleController;

	public float MoveSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		OriginPosition = transform.position;
		OriginScale = transform.localScale;
		OriginRotation = transform.rotation;
		particleController = GetComponent<ParticleController> ();
		moveMode = MoveMode.None;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (moveMode == MoveMode.Move) {
			float step = MoveSpeed * Time.deltaTime;
			transform.position = Vector3.Lerp (transform.position, End.position, step);
			transform.localScale = Vector3.Lerp (transform.localScale, End.localScale, step);
			transform.rotation = Quaternion.Lerp (transform.rotation, End.rotation, step);
			particleController.StopParticle (Global.ParticleDelay);
		}

		if (moveMode == MoveMode.Return) {
			float step = MoveSpeed * Time.deltaTime;
			transform.position = Vector3.Lerp (transform.position, OriginPosition, step);
			transform.localScale = Vector3.Lerp (transform.localScale, OriginScale, step);
			transform.rotation = Quaternion.Lerp (transform.rotation, OriginRotation, step);
		}
	}

	public void SetEndPosition(Transform End)
	{
		this.End = End;
		this.moveMode = MoveMode.Move;
	}

	public void SetReturn()
	{
		this.moveMode = MoveMode.Return;
	}

	public void UpdateScale(Vector3 NewScale)
	{
		this.OriginScale = NewScale;
	}
}
