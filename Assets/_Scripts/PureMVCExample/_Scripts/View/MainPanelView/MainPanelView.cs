using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using PureMVC.Interfaces;

/// <summary>
/// 抽奖面板
/// </summary>
public class MainPanelView : MonoBehaviour {

    public Button ButtonPlay;
	/// <summary>
	/// 模板对象,BonusItem也是单独的View，但是不需要也为此建立一个xxxMediator,
	/// 他被包含在MainPanelView中，所以放在一个Mediator中处理即可
	/// </summary>
    public GameObject BonusItemTemplate;
    public Text GamePlayCount;
    public Text RewardTotal;
    public Transform ParentBonusItem;//父节点
    

    //解耦合，按下事件通过委托实现
    public System.Action ActionPlay;

    public void UpdateGamePlayCount(int val)
    {
        GamePlayCount.text = "游戏次数:"+ val;
    }

    public void UpdateRewardTotal(int val)
    {
        RewardTotal.text = "赢得总奖励:" + val;
    }
	
}
