using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;

/// <summary>
///  抽奖界面 Mediator
///  
/// U3d的View需要先初始化才能注册Mediator，然而何时会初始化是不确定的
/// 所以需要由ViewComponment组件在内部初始化完成后，主动调用Facade进行
/// 连接
/// </summary>
public class MainPanelMediator:PureMVC.Patterns.Mediator {

    public new const string NAME = "MainPanelMediator";

    private MainPanelView View;

	private List<GameObject> BonusItemLists = new List<GameObject>();

    /// <summary>
    /// Mediator有三种构造函数
    /// 通过设置mediatorName，注册后，可以通过Facade获取
    /// ViewComponent View引用
    /// </summary>
    /// <param name="mediatorName"></param>
    /// <param name="viewComponent"></param>
    public MainPanelMediator(string mediatorName, object viewComponent)
        :base(mediatorName,viewComponent)
    {
        //前提只有ViewComponent初始化成功，才可以进行UI的操作
        //绑定事件
        //View = (GameObject)viewComponent;
        View = ((GameObject)ViewComponent).GetComponent<MainPanelView>();
        Debug.Log("panel mediator");

        //绑定按钮事件
        //View.ButtonPlay.onClick = btn.onClick.AddListener( OnClick );;
        View.ButtonPlay.onClick.AddListener(OnClickPlay);

    }

	public MainPanelMediator(object viewComponent)
		:base(NAME,viewComponent)
	{
		//前提只有ViewComponent初始化成功，才可以进行UI的操作
		//绑定事件
		View = ((GameObject)ViewComponent).GetComponent<MainPanelView>();
		Debug.Log("panel mediator");

		//绑定按钮事件
		//View.ButtonPlay.onClick = btn.onClick.AddListener( OnClick );;
		View.ButtonPlay.onClick.AddListener(OnClickPlay);
	}

    public void OnClickPlay()
    {
        Debug.Log("start game");
        //为了测试功能，使用command方式实现
        SendNotification(MyFacade.PLAY);
    }
    
	public void DestroyAll()
	{
		if (BonusItemLists.Count != 0) {
			foreach (GameObject obj in BonusItemLists) {
				GameObject.DestroyObject (obj);

			}
		}
		View.BonusItemTemplate.SetActive (false);
	}

    /// <summary>
    /// 监听消息
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
		case MyFacade.REFRESH_BONUS_UI:
         //此处业务逻辑可以放在Command中实现，Mediator的功能尽量简单
			Debug.Log ("REFRESH_BONUS_UI");

				//显示当前的窗本
			if (!View.isActiveAndEnabled) {
				View.gameObject.SetActive (true);
			}
                break;
		case MyFacade.UPDATE_PLAYER_DATA:
                {
                    //更新UI
                   PlayerDataProxy playerData = notification.Body as PlayerDataProxy;
                    if(playerData!=null)
                    {
					View.GamePlayCount.text = string.Format("游戏次数:{0}",playerData.PlayerData.PlayGameCount);
					View.RewardTotal.text = string.Format("游戏总奖励:{0}",playerData.PlayerData.RewardTotal);

					//show reward tip view
					SendNotification (MyFacade.REWARD_TIP_VIEW,playerData);

                    }
                   
                }
                break;
        }
    }

	/// <summary>
	/// 添加随机的Item
	/// </summary>
	/// <param name="obj">Object.</param>
	public void AddItems(GameObject obj)
	{
		BonusItemLists.Add (obj);
	}

	/// <summary>
	/// 创建bonus item
	/// </summary>
	/// <returns>The bonus item.</returns>
	public GameObject InstanceBonusItem()
	{
		return GameObjectUtility.Instance.CreateGameObject (View.BonusItemTemplate, View.ParentBonusItem);
	}
    /// <summary>
    /// 事件监听 
    /// 不可以为Null，否则无法注册
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests()
    {
        //IList<string> list = new List<string>();
        //list.Add(NotificationConstants.REFRESH_POOL);
        //list.Add(NotificationConstants.UPDATE_PLAYERDATA);

        IList<string> list = new List<string>()
		{ MyFacade.REFRESH_BONUS_UI, MyFacade.UPDATE_PLAYER_DATA };
       
        return list;
    }

    public override void OnRegister()
    {

    }
    public override void OnRemove()
    {

    }

   
}
