using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class RefreshRewardPoolCommand : PureMVC.Patterns.SimpleCommand {

	public override void Execute (INotification notification) {
		//生成随机奖励
		//获取Proxy，可以定义出来，不需要每次都获取
		BonusProxy bonus = Facade.RetrieveProxy (BonusProxy.NAME) as BonusProxy;
		if (bonus != null) {
			//生成随机奖励
			bonus.Clear ();
			//bonus.RandomCreate();
			bonus.CreateRewardPool (12);

			Debug.Log ("start REFRESH_BONUS_UI");

			MainPanelMediator mediator = Facade.RetrieveMediator (MainPanelMediator.NAME) as MainPanelMediator;

			//先清除已有的BonusItem
			//mediator.DestroyAll ();
			bool newCreate = mediator.BonusItemCount == 0;

			GameObject obj = null;
			for (int i = 0; i < bonus.BonusLists.Count; ++i) {
				if (newCreate) {
					obj = mediator.InstanceBonusItem ();
					obj.SetActive (true);
				} else {
					obj = mediator.BonusItem (i);
				}

				
				BonusIem item = obj.GetComponent<BonusIem> ();
				if (item != null) {
					//更新Item
					item.UpdateItem (bonus.BonusLists[i]);
				}
				//mediator.BonusItemLists.Add (obj);
				mediator.AddItems (obj);
			}

			//更新UI，并显示MainPanelView面板
			SendNotification (MyFacade.REFRESH_BONUS_UI);

			Debug.Log ("==============RefreshRewardPoolCommand done");
		}
	}

}