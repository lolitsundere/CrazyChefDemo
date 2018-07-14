using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class Shop
{
    /// <summary>
    /// 店铺ID
    /// </summary>
    [JsonProperty]
    public int ID { get; private set; }

    /// <summary>
    /// 店铺名
    /// </summary>
    [JsonProperty]
    public string Name_CN { get; private set; }

    /// <summary>
    /// 店铺可用素材ID
    /// </summary>
    [JsonProperty]
    public List<int> IngredientID { get; private set; }

    /// <summary>
    /// 店铺可用工具ID
    /// </summary>
    [JsonProperty]
    public List<int> FoodMakerID { get; private set; }

    /// <summary>
    /// 店铺可用托盘ID
    /// </summary>
    [JsonProperty]
    public List<int> FoodHolderID { get; private set; }

    /// <summary>
    /// 店铺可用食物ID
    /// </summary>
    [JsonProperty]
    public List<int> FoodID { get; private set; }

    public Shop(GameDictionary.ShopFromJson item)
    {
        ID = Convert.ToInt32(item.ID);
        Name_CN = item.Name_CN;
        IngredientID = new List<int>();
        foreach (var i in item.IngredientID.Split(','))
        {
            IngredientID.Add(Convert.ToInt32(i));
        }
        FoodMakerID = new List<int>();
        foreach (var i in item.FoodMakerID.Split(','))
        {
            FoodMakerID.Add(Convert.ToInt32(i));
        }
        FoodHolderID = new List<int>();
        foreach (var i in item.FoodHolderID.Split(','))
        {
            FoodHolderID.Add(Convert.ToInt32(i));
        }
        FoodID = new List<int>();
        foreach (var i in item.FoodID.Split(','))
        {
            FoodID.Add(Convert.ToInt32(i));
        }
    }
}
