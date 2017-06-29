using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {
	private Transform Particle;
	private ParticleSystem ParticleSystem;

	// Use this for initialization
	void Start () {
		Particle = Helper.getChildByTag("Particle", gameObject);
		ParticleSystem = Particle.GetComponent<ParticleSystem> ();
		StopParticle ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void StartParticle(int ForSeconds = 0)
	{
		if (ParticleSystem.isPlaying)
			ParticleSystem.Stop ();
		ParticleSystem.Play ();
		if (ForSeconds > 0)
			StopParticle (ForSeconds);
	}

	public void StopParticle(int WaitFor = 0)
	{
		if (ParticleSystem.isPlaying)
			StartCoroutine(Delay(WaitFor));
	}

	IEnumerator Delay(int WaitFor)
	{
		yield return new WaitForSeconds (WaitFor);
		if (ParticleSystem.isPlaying)
			ParticleSystem.Stop ();
		//print ("stop");
	}
}
