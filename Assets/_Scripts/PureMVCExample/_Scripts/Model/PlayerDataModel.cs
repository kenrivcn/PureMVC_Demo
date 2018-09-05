using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 保存玩家数据
/// </summary>
public class PlayerDataModel {

    public int PlayGameCount { get; set; }//游戏次数
    public int RewardTotal { get; set; }//奖励总价
	public string RewardInfo{get;set;}//奖励信息
	public int RewardPrice{get;set;}//商品的价格

    public PlayerDataModel(int _count,int total)
    {
        PlayGameCount = _count;
        RewardTotal = total;
    }
    
}
