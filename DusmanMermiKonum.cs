using UnityEngine;
using System.Collections;

public class DusmanMermiKonum : MonoBehaviour {


	public GameObject DusmanMermi;

	// Use this for initialization
	void Start () {
		Invoke ("DusmanAtesi",1f);
	}

	// Update is called once per frame
	void Update () {

	}

	void DusmanAtesi()
	{
		GameObject playerUzayGemisi = GameObject.Find ("Player");
		if (playerUzayGemisi != null) {

			GameObject mermi = (GameObject)Instantiate (DusmanMermi);
			mermi.transform.position = transform.position;
			Vector2 yon = playerUzayGemisi.transform.position - mermi.transform.position;
			mermi.GetComponent<DusmanMermi> ().YonAyarla (yon);
		}
	}
}
