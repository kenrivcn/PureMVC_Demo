using System;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using UnityEngine;

/// <summary>
/// PureMVC 核心类 Facade
/// 只需要创建一个即可
/// 
/// 负责完成proxy,mediator,command的初始化工作
/// 获取也均通过facade
/// 
/// 
/// 重写virtual方法 
/// 
/// 执行顺序：
/// Model->Controller->View->Facade的顺序
/// 重写Facade一定要调用base.InitializeFacade()
/// 
/// </summary>
public class MyFacade : PureMVC.Patterns.Facade {

    public const string START_UP = "start_up";
    public const string CREATE_BONUS_ITEMS = "create_bonus_items";
    public const string REFRESH_BONUS_ITEMS = "refresh_items"; //
    public const string UPDATE_PLAYER_DATA = "update_player_data";
    public const string PLAY = "play";
    public const string REFRESH_BONUS_UI = "refresh_bonus_ui";
    public const string UPDATE_REWARD_TIP_VIEW = "update_reward_tip_view";
    public const string REWARD_TIP_VIEW = "reward_tip_view";
    /// <summary>
    /// 静态初始化 
    /// </summary>
    static MyFacade () {
        m_instance = new MyFacade ();
    }

    /// <summary>
    /// 获取单例
    /// </summary>
    /// <returns></returns>
    public static MyFacade GetInstance () {
        return m_instance as MyFacade;
    }

    /// <summary>
    /// 启动MVC
    /// </summary>
    public void Launch () {
        //通过command命令启动游戏
        SendNotification (MyFacade.START_UP);
    }

    /// <summary>
    /// 初始化Controller，完成Notification和Command的映射
    /// </summary>
    protected override void InitializeController () {
        base.InitializeController ();
        //注册Command
        RegisterCommand (START_UP, typeof (StartUpCommand));
        RegisterCommand (REFRESH_BONUS_ITEMS, typeof (RefreshRewardPoolCommand));
        RegisterCommand (PLAY, typeof (PlayCommand));
        RegisterCommand (REWARD_TIP_VIEW, typeof (RewardTipCommand));
    }

    /// <summary>
    /// 初台化View,Initializes the view.
    /// View在Model和Controll之后运行
    /// UI的创建我放到Command中执行
    /// </summary>
    protected override void InitializeView () {
        base.InitializeView ();
    }

    /// <summary>
    /// 注册Proxy
    /// </summary>
    protected override void InitializeFacade () {
        base.InitializeFacade ();
    }

    /// <summary>
    /// 初始化Model 数据模型  Proxy
    /// </summary>
    protected override void InitializeModel () {
        base.InitializeModel ();
        //也可以放在Command中
        RegisterProxy (new BonusProxy (BonusProxy.NAME));
        RegisterProxy (new PlayerDataProxy (PlayerDataProxy.NAME));

    }

}