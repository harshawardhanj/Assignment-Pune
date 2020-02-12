using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour {

	private string name;
	public GameObject []text;

	// Use this for initialization
	void Start () {
		
	}

	public void setName(string n)
	{
		name = n;
		text[0].GetComponent<TextMeshPro>().text = name;
		text[1].GetComponent<TextMeshPro>().text = name;

	}

	// Update is called once per frame
	void Update () {
		
	}
}
