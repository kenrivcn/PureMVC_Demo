using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
public class PlayCommand : PureMVC.Patterns.SimpleCommand
{

    public override void Execute(INotification notification)
    {
        //开始随机
        BonusProxy bonus = MyFacade.Instance.RetrieveProxy(BonusProxy.NAME) as BonusProxy;
        int id = Random.Range(0, bonus.BonusLists.Count);

        Debug.Log("result:"+bonus.BonusLists[id].Name+","+bonus.BonusLists[id].Reward);

        //改变数值 并发送消息
		PlayerDataProxy playerData = Facade.RetrieveProxy(PlayerDataProxy.NAME) as PlayerDataProxy;
        if(playerData!=null)
        {
            playerData.GetReward(bonus.BonusLists[id].Reward,bonus.BonusLists[id].Name);
            	Debug.Log ("================PlayCommand");

        }

      
    }
}
