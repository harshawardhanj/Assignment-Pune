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
	private int cardSets=1;

	public GameObject []PlayingCards;
	public GameObject SelectedSetText;
	public GameObject statusText;
	// Use this for initialization
	void Start () {
		cards = new int[13];
		cardSets = 1;
		refreshCards();

	}

	// Update is called once per frame
	void Update () {
		
	}
	public void refreshCards()
	{
		// 1- 13 - > Heart
		//14- 26 -> Diamond
		// 27- 39 ->Club
		//40- 52 ->  Spade
		statusText.GetComponent<TextMeshProUGUI>().text = "STATUS : UNSORTED";

		for (int i = 0; i < cards.Length; i++)
		{
			// Generate 13 cards wih random suits and numbers
			int num = Random.Range(0, 53) + 1;
				int count=0;
				for (int k = 0; k < i; k++)
				{
					if (num == cards[k])
						++count;				
				}
 
	// Duplicate of card depend on sets 		
			if (count < cardSets)
				cards[i] = num;
			else
				--i;
		}

		UpdateCards();	
	}

	// updating cards suit and numbers in gameplay
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

			// Updating card suit numbers 
			if (temp == 1)
				text = "A";
			else if (temp == 11)
				text = "J";
			else if (temp == 12)
				text = "Q";
			else if (temp == 13)
				text = "K";
			else if (temp == 53)
				text = "JOKER";
			else
				text = temp + "";
		
			// updating numbers on cards 
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
			{// Spade card
				PlayingCards[i].GetComponentInChildren<UnityEngine.UI.Image>().sprite = CardSpades;
			}
			else if (cards[i] >= 40 && cards[i] <= 52)
			{// Club Card
				PlayingCards[i].GetComponentInChildren<UnityEngine.UI.Image>().sprite = CardClubs;
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


		statusText.GetComponent<TextMeshProUGUI>().text = "STATUS : SORTED";

		UpdateCards();
	}

	// Update card set to 1 when clicked on set 1 button
	public void Set1()
	{
		cardSets = 1;
		SelectedSetText.GetComponent<TextMeshProUGUI>().text = "SET: 1";
		refreshCards();
	}
	// Upading card set to 2 when clicked on set 2 button
	public void Set2()
	{
		cardSets = 2;
		SelectedSetText.GetComponent<TextMeshProUGUI>().text = "SET: 2";
		refreshCards();
	}
	// Updaing on card set to 3 when clicked on set 3 button
	public void Set3()
	{
		cardSets = 3;
		SelectedSetText.GetComponent<TextMeshProUGUI>().text = "SET: 3";
		refreshCards();
	}
	// Updaing on card set to 4 when clicked on set 4 button
	public void Set4()
	{
		cardSets = 4;
		SelectedSetText.GetComponent<TextMeshProUGUI>().text = "SET: 4";
		refreshCards();
	}


}
