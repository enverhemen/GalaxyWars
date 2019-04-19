﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerKontrol : MonoBehaviour {

	public GameObject oyunYoneticisiObje;
	public GameObject playerMermi;
	public GameObject mermiKonumSol;
	public GameObject mermiKonumSag;
	public GameObject Patlama; 

	public Text CanText;
	const int MaxCan = 3;
	int canSayisi;

	public float hiz;
	float baslangicKonumY;

	public void ilkDurum()
	{
		canSayisi = MaxCan;
		CanText.text = canSayisi.ToString ();
		transform.position = new Vector2 (0,0);
		gameObject.SetActive (true);
	}

	void Start () {

		baslangicKonumY = Input.acceleration.y;
	}

	void Update () {

		float x = Input.acceleration.x;
		float y = Input.acceleration.y - baslangicKonumY;

		Vector2 yon = new Vector2 (x, y);

		if (yon.sqrMagnitude > 1)
			yon.Normalize ();

		Hareket (yon);

	}

	public void AtesEt() {

			gameObject.GetComponent<AudioSource>().Play();
			GameObject mermi1 = (GameObject)Instantiate (playerMermi);
			mermi1.transform.position = mermiKonumSol.transform.position;

			GameObject mermi2 = (GameObject)Instantiate (playerMermi);
			mermi2.transform.position = mermiKonumSag.transform.position;

	}

	void Hareket(Vector2 yon)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.225f;
		min.x = min.x + 0.225f;

		max.y = max.y - 0.285f;
		min.y = min.y + 0.285f;

		Vector2 konum = transform.position;

		konum += yon * hiz * Time.deltaTime;

		konum.x = Mathf.Clamp (konum.x, min.x, max.x);
		konum.y = Mathf.Clamp (konum.y, min.y, max.y);

		transform.position = konum;
	}

	void OnTriggerEnter2D(Collider2D obje)
	{
		if ((obje.tag == "DusmanGemi") || (obje.tag == "DusmanMermi")) {

			PatlamaAnimasyonu ();
			canSayisi--;
			CanText.text = canSayisi.ToString ();

			if (canSayisi == 0) {
				oyunYoneticisiObje.GetComponent<OyunYoneticisi>().OyunDurumunuAyarla (OyunYoneticisi.OyunYoneticisiDurumu.OyunSonu);
				gameObject.SetActive (false);
			}
		}
	} 

	void PatlamaAnimasyonu() {

		GameObject patlama = (GameObject)Instantiate (Patlama);
		patlama.transform.position = transform.position;
	} 

}
