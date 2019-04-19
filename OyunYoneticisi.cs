using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OyunYoneticisi : MonoBehaviour {

	public GameObject startBtn;
	public GameObject playerGemi;
	public GameObject dusmanYaratici;
	public GameObject oyunBitti;
	public GameObject dinamikSkorTxtObje;

	public enum OyunYoneticisiDurumu
	{   
		Baslangic,
		OyunHali,
		OyunSonu,
	}

	OyunYoneticisiDurumu OyunDurumu;

	void Start () {
		
		OyunDurumu = OyunYoneticisiDurumu.Baslangic;
	}

	void OyunDurumunuGuncelle()
	{
		switch (OyunDurumu) 
		{
		case OyunYoneticisiDurumu.Baslangic:
			startBtn.SetActive (true);
			oyunBitti.SetActive (false);
			break;

		case OyunYoneticisiDurumu.OyunHali:

			dinamikSkorTxtObje.GetComponent<oyunSkor> ().Skor = 0;
			startBtn.SetActive (false);
			playerGemi.GetComponent<PlayerKontrol> ().ilkDurum ();
			dusmanYaratici.GetComponent<DusmanYaratici> ().DusmanYaratmayiBaslat ();
			break;

		case OyunYoneticisiDurumu.OyunSonu:
			dusmanYaratici.GetComponent<DusmanYaratici> ().DusmanYaratmayiDurdur ();
			oyunBitti.SetActive (true);
			startBtn.SetActive (false);
			Invoke ("MevcutDurumuDegistir", 8f);
			break;

		}
	}

	public void OyunDurumunuAyarla(OyunYoneticisiDurumu durum)
	{
		OyunDurumu = durum;
		OyunDurumunuGuncelle ();
	}

	public void OyunuBaslat()
	{
		OyunDurumu = OyunYoneticisiDurumu.OyunHali;
		OyunDurumunuGuncelle ();
	}

	public void MevcutDurumuDegistir()
	{
		OyunDurumunuAyarla (OyunYoneticisiDurumu.Baslangic);
	}
}
