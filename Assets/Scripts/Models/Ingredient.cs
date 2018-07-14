using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class Ingredient
{
    /// <summary>
    /// 素材ID
    /// </summary>
    [JsonProperty]
    public int ID { get; private set; }

    /// <summary>
    /// 素材中文名
    /// </summary>
    [JsonProperty]
    public string Name_CN { get; private set; }

    /// <summary>
    /// 一星素材出售时金币数
    /// </summary>
    [JsonProperty]
    public int OneStarSellGold { get; private set; }

    /// <summary>
    /// 二星素材出售时金币数
    /// </summary>
    [JsonProperty]
    public int TwoStarSellGold { get; private set; }

    /// <summary>
    /// 三星素材出售时金币数
    /// </summary>
    [JsonProperty]
    public int ThreeStarSellGold { get; private set; }

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
    /// 是否自动烹饪
    /// </summary>
    [JsonProperty]
    public bool IsAuto { get; private set; }

    /// <summary>
    /// 烹饪输出对象ID
    /// </summary>
    [JsonProperty]
    public int TargetID { get; private set; }

    public Ingredient(GameDictionary.IngredientFromJson item)
    {
        ID = Convert.ToInt32(item.ID);
        Name_CN = item.Name_CN;
        OneStarSellGold = Convert.ToInt32(item.OneStarSellGold);
        TwoStarSellGold = Convert.ToInt32(item.TwoStarSellGold);
        ThreeStarSellGold = Convert.ToInt32(item.ThreeStarSellGold);
        OneStarUpgradeGold = Convert.ToInt32(item.OneStarUpgradeGold);
        TwoStarUpgradeGold = Convert.ToInt32(item.TwoStarUpgradeGold);
        ThreeStarUpgradeGold = Convert.ToInt32(item.ThreeStarUpgradeGold);
        IsAuto = item.IsAuto.ToLower() == "true" ? true : false;
        TargetID = Convert.ToInt32(item.TargetID);
    }
}
