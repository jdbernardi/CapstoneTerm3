using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour {

	public GameObject panel;
//	public GameObject player;

	// Use this for initialization
	void Start () {
		panel.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OKClicked()
	{
		panel.SetActive(false);
	}


}
