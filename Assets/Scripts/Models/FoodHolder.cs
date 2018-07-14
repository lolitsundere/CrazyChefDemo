using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class FoodHolder
{
    /// <summary>
    /// 托盘ID
    /// </summary>
    [JsonProperty]
    public int ID { get; private set; }

    /// <summary>
    /// 托盘中文名
    /// </summary>
    [JsonProperty]
    public string Name_CN { get; private set; }

    /// <summary>
    /// 一星盛放食物数
    /// </summary>
    [JsonProperty]
    public int OneStarFoodCount { get; private set; }

    /// <summary>
    /// 二星盛放食物数
    /// </summary>
    [JsonProperty]
    public int TwoStarFoodCount { get; private set; }

    /// <summary>
    /// 三星盛放食物数
    /// </summary>
    [JsonProperty]
    public int ThreeStarFoodCount { get; private set; }

    /// <summary>
    /// 一星升级需要金币
    /// </summary>
    [JsonProperty]
    public int OneStarUpgradeGold { get; private set; }

    /// <summary>
    /// 二星升级需要金币
    /// </summary>
    [JsonProperty]
    public int TwoStarUpgradeGold { get; private set; }

    /// <summary>
    /// 三星升级需要金币
    /// </summary>
    [JsonProperty]
    public int ThreeStarUpgradeGold { get; private set; }

    /// <summary>
    /// 是否随着其他器材升级
    /// </summary>
    [JsonProperty]
    public bool UpdateWithOther { get; private set; }

    /// <summary>
    /// 跟随升级器材的ID
    /// </summary>
    [JsonProperty]
    public int UpdateWithID { get; private set; }

    public FoodHolder(GameDictionary.FoodHolderFromJson item)
    {
        ID = Convert.ToInt32(item.ID);
        Name_CN = item.Name_CN;
        OneStarFoodCount = Convert.ToInt32(item.OneStarFoodCount);
        TwoStarFoodCount = Convert.ToInt32(item.TwoStarFoodCount);
        ThreeStarFoodCount = Convert.ToInt32(item.ThreeStarFoodCount);
        OneStarUpgradeGold = Convert.ToInt32(item.OneStarUpgradeGold);
        TwoStarUpgradeGold = Convert.ToInt32(item.TwoStarUpgradeGold);
        ThreeStarUpgradeGold = Convert.ToInt32(item.ThreeStarUpgradeGold);
        UpdateWithOther = item.UpdateWithOther.ToLower() == "true" ? true : false;
        UpdateWithID = Convert.ToInt32(item.UpdateWithID);
    }

}
