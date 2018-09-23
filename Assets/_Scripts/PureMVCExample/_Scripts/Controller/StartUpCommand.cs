using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
/// <summary>
/// 启动
/// 2.随机生成奖励池
/// </summary>
public class StartUpCommand : PureMVC.Patterns.SimpleCommand {

	public override void Execute (INotification notification) {
		//create ui
		GameObject obj = GameObjectUtility.Instance.CreateGameObject ("_Prefabs/MainPanelView");
		//bind mediator
		Facade.RegisterMediator (new MainPanelMediator (obj));

		//更新12个道具
		SendNotification (MyFacade.REFRESH_BONUS_ITEMS);

	}
}