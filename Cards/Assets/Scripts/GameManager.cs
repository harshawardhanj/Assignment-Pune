using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

 	public Sprite CardDiamond;
	public Sprite CardClubs;
	public Sprite CardSpades;
	public Sprite CardHeart;

	private int[] cards;

	public GameObject []PlayingCards;
	// Use this for initialization
	void Start () {
		cards = new int[13];
		refreshCards();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void refreshCards()
	{
		// 0- 12 - > Heart
		//13- 25 -> Diamond
		// 26- 38 ->Club
		//39- 51 ->  Spade
		for (int i = 0; i < cards.Length; i++)
		{
			cards[i] = Random.Range(0, 51)+1;
			Debug.Log(i+"====> "+cards[i]);
		}

		UpdateCards();	
	}

	// updating cards suit and numbers 
		public void UpdateCards()
	{
		// 1- 13 - > Heart
		//14- 26 -> Diamond
		// 27- 39 ->Club
		//40- 52 ->  Spade
		for (int i = 0; i < cards.Length; i++)
		{
			string text = "";
			int temp = cards[i] % 13 +1;
			if (temp == 1)
				text = "A";
			else if (temp == 11)
				text = "J";
			else if (temp == 12)
				text = "Q";
			else if (temp == 13)
				text = "K";
			else 
				text = temp+"";

			PlayingCards[i].transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = text;
			PlayingCards[i].transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>().text = text;

			if (cards[i] >= 1 && cards[i] <= 13)
			{// Heart Card var theImage:UnityEngine.UI.Image; 
				PlayingCards[i].GetComponentInChildren < UnityEngine.UI.Image >().sprite= CardHeart;
			}
			else if (cards[i] >= 14 && cards[i] <= 26)
			{// Diamond Card
				PlayingCards[i].GetComponentInChildren<UnityEngine.UI.Image>().sprite = CardDiamond;
			}
			else if (cards[i] >= 27 && cards[i] <= 39)
			{// Club card
				PlayingCards[i].GetComponentInChildren<UnityEngine.UI.Image>().sprite = CardClubs;
			}
			else if (cards[i] >= 40 && cards[i] <= 52)
			{// Spade Card
				PlayingCards[i].GetComponentInChildren<UnityEngine.UI.Image>().sprite = CardSpades;
			}
		}

	}

	// Sorting cards 
	public void sortCards()
	{
		for (int i = 0; i < cards.Length-1; i++)
		{
			for (int j = i+1; j < cards.Length; j++)
			{
				if (cards[i] > cards[j])
				{
					int temp = cards[i];
					cards[i] = cards[j];
					cards[j] = temp;
				}
			}
			
		}


		UpdateCards();
	}
}
