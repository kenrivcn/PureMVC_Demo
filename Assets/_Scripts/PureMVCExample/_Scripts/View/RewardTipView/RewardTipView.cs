using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 显示当前获得的奖励
/// </summary>
public class RewardTipView : MonoBehaviour {

	public Button Back;
	public Text Context;

	// Use this for initialization
	void Start () {
		
	}

	public void SetText(string context)
	{
		Context.text = context;
	}
}
