using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusIem : MonoBehaviour {

    public BonusModel bonusData;
    public Text Desc;
	public Image img;
	// Use this for initialization
	void Start () {
		
	}
	

    public void UpdateItem(BonusModel model)
    {
		RandomColor ();

        bonusData = model;
        if(bonusData!=null)
        {
            Desc.text = bonusData.Id + ",\n" + bonusData.Name + ",\n" + bonusData.Reward;
        }
    }

	private void RandomColor()
	{
		Color[] color = { Color.red, Color.green, Color.blue, Color.cyan, Color.white,Color.yellow,Color.gray};
		int val = Random.Range (0, color.Length);
		img.color = color [val];

	}
}
