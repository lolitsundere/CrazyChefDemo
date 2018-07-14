using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class Level
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonProperty]
    public string ID { get; private set; }

    /// <summary>
    /// 关卡店铺ID
    /// </summary>
    [JsonProperty]
    public int ShopID { get; private set; }

    /// <summary>
    /// 关卡出售食物
    /// </summary>
    [JsonProperty]
    public List<int> WantedFood { get; private set; }

    /// <summary>
    /// 顾客要一个食物的概率
    /// </summary>
    [JsonProperty]
    public int OneFoodProbability { get; private set; }

    /// <summary>
    /// 顾客要两个食物的概率
    /// </summary>
    [JsonProperty]
    public int TwoFoodProbability { get; private set; }

    /// <summary>
    /// 顾客要三个食物的概率
    /// </summary>
    [JsonProperty]
    public int ThreeFoodProbability { get; private set; }

    /// <summary>
    /// 同时最多顾客数
    /// </summary>
    [JsonProperty]
    public int MaximumCustomerWaiting { get; private set; }

    /// <summary>
    /// 是否有时限
    /// </summary>
    [JsonProperty]
    public bool HasTimeLimit { get; private set; }

    /// <summary>
    /// 本关顾客总数
    /// </summary>
    [JsonProperty]
    public int MaximumCustomer { get; private set; }

    /// <summary>
    /// 本关时限
    /// </summary>
    [JsonProperty]
    public double TimeLimit { get; private set; }

    /// <summary>
    /// 平均顾客出现时间
    /// </summary>
    [JsonProperty]
    public double AverageCustomerComeTime { get; private set; }

    /// <summary>
    /// 需要一个食物的顾客的等待时间
    /// </summary>
    [JsonProperty]
    public double OneFoodMaximumCustomerWaitingTime { get; private set; }

    /// <summary>
    /// 需要两个食物的顾客的等待时间
    /// </summary>
    [JsonProperty]
    public double TwoFoodMaximumCustomerWaitingTime { get; private set; }

    /// <summary>
    /// 需要三个食物的顾客的等待时间
    /// </summary>
    [JsonProperty]
    public double ThreeFoodMaximumCustomerWaitingTime { get; private set; }

    /// <summary>
    /// 目标赚取金币数
    /// </summary>
    [JsonProperty]
    public int TargetGold { get; private set; }

    /// <summary>
    /// 目标金币数是否为连续上菜获得的金币数
    /// </summary>
    [JsonProperty]
    public bool UseComboGoldAsTargetGold { get; private set; }

    /// <summary>
    /// 烧焦是否会导致过关失败
    /// </summary>
    [JsonProperty]
    public bool BurntFail { get; private set; }

    /// <summary>
    /// 最多烧焦次数
    /// </summary>
    [JsonProperty]
    public int BurntFailCount { get; private set; }

    /// <summary>
    /// 顾客离开是否会导致过关失败
    /// </summary>
    [JsonProperty]
    public bool CustomerLeaveFail { get; private set; }

    /// <summary>
    /// 最多离开顾客数
    /// </summary>
    [JsonProperty]
    public int CustomerLeaveFailCount { get; private set; }

    public Level(GameDictionary.LevelFromJson item)
    {
        ID = item.ID;
        ShopID = Convert.ToInt32(item.ShopID);
        WantedFood = new List<int>();
        foreach (var i in item.WantedFood.Split(','))
        {
            WantedFood.Add(Convert.ToInt32(i));
        }
        OneFoodProbability = Convert.ToInt32(item.OneFoodProbability);
        TwoFoodProbability = Convert.ToInt32(item.TwoFoodProbability);
        ThreeFoodProbability = Convert.ToInt32(item.ThreeFoodProbability);
        MaximumCustomerWaiting = Convert.ToInt32(item.MaximumCustomerWaiting);
        HasTimeLimit = item.HasTimeLimit.ToLower() == "true" ? true : false;
        MaximumCustomer = Convert.ToInt32(item.MaximumCustomer);
        TimeLimit = Convert.ToDouble(item.TimeLimit);
        AverageCustomerComeTime = Convert.ToDouble(item.AverageCustomerComeTime);
        OneFoodMaximumCustomerWaitingTime = Convert.ToDouble(item.OneFoodMaximumCustomerWaitingTime);
        TwoFoodMaximumCustomerWaitingTime = Convert.ToDouble(item.TwoFoodMaximumCustomerWaitingTime);
        ThreeFoodMaximumCustomerWaitingTime = Convert.ToDouble(item.ThreeFoodMaximumCustomerWaitingTime);
        TargetGold = Convert.ToInt32(item.TargetGold);
        UseComboGoldAsTargetGold = item.UseComboGoldAsTargetGold.ToLower() == "true" ? true : false;
        BurntFail = item.BurntFail.ToLower() == "true" ? true : false;
        CustomerLeaveFail = item.CustomerLeaveFail.ToLower() == "true" ? true : false;
        BurntFailCount = Convert.ToInt32(item.BurntFailCount);
        CustomerLeaveFailCount = Convert.ToInt32(item.CustomerLeaveFailCount);
    }
}
