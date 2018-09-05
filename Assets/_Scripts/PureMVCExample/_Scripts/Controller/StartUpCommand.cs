using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

using PureMVC.Interfaces;
/// <summary>
/// 启动
/// 1.创建MainPanelView，与Mediator关联，并绑定到Facade中
/// 2.随机生成奖励池
/// </summary>
public class StartUpCommand : PureMVC.Patterns.SimpleCommand {

//    protected override void InitializeMacroCommand()
//    {
//        AddSubCommand(typeof(CreateBonusUICommand));
//        AddSubCommand(typeof(RefreshRewardPoolCommand));
//    }

	public override void Execute(INotification notification)
	{
		//create ui
		GameObject obj =GameObjectUtility.Instance.CreateGameObject("_Prefabs/MainPanelView"); 
		//bind mediator
		Facade.RegisterMediator(new MainPanelMediator(obj));

		Debug.Log ("============create ui");


		//初始化随机列表，这部分业务逻辑，不能放在proxy，也不能放在mediator中，放在command中，View和Model松耦合，提高了复用性。
		SendNotification(MyFacade.REFRESH_BONUS_ITEMS);

	}
}
