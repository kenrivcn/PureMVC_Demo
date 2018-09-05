using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
public class BonusProxy : PureMVC.Patterns.Proxy  {
    
    //奖励列表
    public List<BonusModel> BonusLists = new List<BonusModel>();

    public new static string NAME = "Bonus";

    private static string[] REWARD_NAME = new string[]{ "金创药", "薄荷叶", "橡木果", "圣灵药", "还魂丹", "解毒药" };
    private static int[] REWARD_PRICE = new int[]{100,300,500,800,1200 };

    public BonusProxy(string proxyName)
		: base(proxyName)
	{
        Debug.Log("bonusProxy create");
    }

    public void AddBonus(BonusModel bonus)
    {
        BonusLists.Add(bonus);
    }

    public void Clear()
    {
        BonusLists.Clear();
    }

    /// <summary>
    /// 创建奖池
    /// </summary>
    public void CreateRewardPool(int count)
    {
        for(int i=0;i<count;++i)
        {
            //int id = 0;
            string name = REWARD_NAME[Random.Range(0, REWARD_NAME.Length)];
            int price = REWARD_PRICE[Random.Range(0, REWARD_PRICE.Length)];
            BonusModel model = new BonusModel(i+1, name, price);
            BonusLists.Add(model);
        }
        
        //更新UI的通知也可以在这里写
        

    }

    /// <summary>
    /// 注册成功后会自动调用
    /// </summary>
    public override void OnRegister()
    {
        base.OnRegister();
        Debug.Log("BonusProxy OnRegister");
    }

    /// <summary>
    /// Called by the Model when the Proxy is removed
    /// </summary>
    public override void OnRemove()
    {
        base.OnRemove();
        Debug.Log("BonusProxy OnRemove");
    }

}
