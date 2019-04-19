using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class oyunSkor : MonoBehaviour {

	Text skorTxt;
	int skor;


	public int Skor{
		get{ return this.skor; }
		set{ this.skor = value; UpdateSkorTxt(); }
	}
		
	void Start () {
	
		skorTxt = GetComponent<Text> ();
	}

	void UpdateSkorTxt () {
		
		string skorFormat = string.Format ("{0:00000}", skor);
		skorTxt.text = skorFormat;
	}
}
