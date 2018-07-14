using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class Food
{
    /// <summary>
    /// 食物ID
    /// </summary>
    [JsonProperty]
    public int ID { get; private set; }

    /// <summary>
    /// 食物中文名
    /// </summary>
    [JsonProperty]
    public string Name_CN { get; private set; }

    /// <summary>
    /// 组合用食材ID
    /// </summary>
    [JsonProperty]
    public List<int> SourceID { get; private set; }


    public Food(GameDictionary.FoodFromJson item)
    {
        ID = Convert.ToInt32(item.ID);
        Name_CN = item.Name_CN;
        SourceID = new List<int>();
        foreach (var i in item.SourceID.Split(','))
        {
            SourceID.Add(Convert.ToInt32(i));
        }
    }
}
