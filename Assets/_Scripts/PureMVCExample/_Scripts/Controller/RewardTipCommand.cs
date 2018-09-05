using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class RewardTipCommand:PureMVC.Patterns.SimpleCommand
{
	public override void Execute(INotification notification)
	{
		//显示结算结果
		RewardTipViewMediator mediator = Facade.RetrieveMediator(RewardTipViewMediator.NAME) as RewardTipViewMediator;
		if (mediator == null) {
			GameObject obj = GameObjectUtility.Instance.CreateGameObject ("_Prefabs/RewardTipView");
			mediator = new RewardTipViewMediator (obj);
			Facade.RegisterMediator (mediator);
		}
			
		//update reward tip view
		SendNotification (MyFacade.UPDATE_REWARD_TIP_VIEW, notification.Body);
	}
}

