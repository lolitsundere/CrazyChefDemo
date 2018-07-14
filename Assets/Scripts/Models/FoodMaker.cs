using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class FoodMaker
{
    /// <summary>
    /// 机器ID
    /// </summary>
    [JsonProperty]
    public int ID {get; private set; }

    /// <summary>
    /// 机器中文名
    /// </summary>
    [JsonProperty]
    public string Name_CN { get; private set; }

    /// <summary>
    /// 一星制作时间
    /// </summary>
    [JsonProperty]
    public double OneStarMakingTime { get; private set; }

    /// <summary>
    /// 二星制作时间
    /// </summary>
    [JsonProperty]
    public double TwoStarMakingTime { get; private set; }

    /// <summary>
    /// 三星制作时间
    /// </summary>
    [JsonProperty]
    public double ThreeStarMakingTime { get; private set; }

    /// <summary>
    /// 一星机器数量
    /// </summary>
    [JsonProperty]
    public int OneStarMakerCount { get; private set; }

    /// <summary>
    /// 二星机器数量
    /// </summary>
    [JsonProperty]
    public int TwoStarMakerCount { get; private set; }

    /// <summary>
    /// 三星机器数量
    /// </summary>
    [JsonProperty]
    public int ThreeStarMakerCount { get; private set; }

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
    /// 输出对象ID
    /// </summary>
    [JsonProperty]
    public int TargetID { get; private set; }

    /// <summary>
    /// 输出结果ID
    /// </summary>
    [JsonProperty]
    public int ResultID { get; private set; }

    /// <summary>
    /// 是否一个制作多份
    /// </summary>
    [JsonProperty]
    public bool IsOneForAll { get; private set; }

    /// <summary>
    /// 是否自动
    /// </summary>
    [JsonProperty]
    public bool IsAuto { get; private set; }

    /// <summary>
    /// 是否会烧焦食物
    /// </summary>
    [JsonProperty]
    public bool CanBurnt { get; private set; }

    /// <summary>
    /// 一星烧焦时间
    /// </summary>
    [JsonProperty]
    public double OneStarBurntTime { get; private set; }

    /// <summary>
    /// 二星烧焦时间
    /// </summary>
    [JsonProperty]
    public double TwoStarBurntTime { get; private set; }

    /// <summary>
    /// 三星烧焦时间
    /// </summary>
    [JsonProperty]
    public double ThreeStarBurntTime { get; private set; }

    public FoodMaker(GameDictionary.FoodMakerFromJson item)
    {
        ID = Convert.ToInt32(item.ID);
        Name_CN = item.Name_CN;
        OneStarMakingTime = Convert.ToDouble(item.OneStarMakingTime);
        TwoStarMakingTime = Convert.ToDouble(item.TwoStarMakingTime);
        ThreeStarMakingTime = Convert.ToDouble(item.ThreeStarMakingTime);
        OneStarMakerCount = Convert.ToInt32(item.OneStarMakerCount);
        TwoStarMakerCount = Convert.ToInt32(item.TwoStarMakerCount);
        ThreeStarMakerCount = Convert.ToInt32(item.ThreeStarMakerCount);
        OneStarUpgradeGold = Convert.ToInt32(item.OneStarUpgradeGold);
        TwoStarUpgradeGold = Convert.ToInt32(item.TwoStarUpgradeGold);
        ThreeStarUpgradeGold = Convert.ToInt32(item.ThreeStarUpgradeGold);
        TargetID = Convert.ToInt32(item.TargetID);
        ResultID = Convert.ToInt32(item.ResultID);
        IsAuto = item.IsAuto.ToLower() == "true" ? true : false;
        CanBurnt = item.CanBurnt.ToLower() == "true" ? true : false;
        IsOneForAll = item.IsOneForAll.ToLower() == "true" ? true : false;
        OneStarBurntTime = Convert.ToDouble(item.OneStarBurntTime);
        TwoStarBurntTime = Convert.ToDouble(item.TwoStarBurntTime);
        ThreeStarBurntTime = Convert.ToDouble(item.ThreeStarBurntTime);

    }
}
