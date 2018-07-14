using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

/// <summary>
/// 记录玩家信息
/// </summary>
public class PlayerData
{
    /// <summary>
    /// 玩家所持金币
    /// </summary>
    [JsonProperty]
    public int Gold { get; private set; }

    /// <summary>
    /// 玩家所持汤勺(充值游戏币)
    /// </summary>
    [JsonProperty]
    public int Spoon { get; private set; }

    /// <summary>
    /// 玩家装备信息
    /// </summary>
    [JsonProperty]
    public Dictionary<int, int> PlayerEquipmentDic { get; private set; }
    

    /// <summary>
    /// 单例
    /// </summary>
    public static PlayerData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = SetNewPlayer();
            }
            return instance;
        }
    }
    private static PlayerData instance;

    /// <summary>
    /// 设置新创建的玩家
    /// </summary>
    private static PlayerData SetNewPlayer()
    {
        string PlayerDataString = PlayerPrefs.GetString("PlayerData");

        if (PlayerDataString == "")
        {
            PlayerData pd = new PlayerData();
            var setting = Resources.Load<NewPlayerSetting>(@"Settings/NewPlayerSetting");

            pd.Gold = setting.InitialGold;
            pd.Spoon = setting.InitialSpoon;
            pd.PlayerEquipmentDic = new Dictionary<int, int>();

            foreach (var item in setting.InitialEquipmentID)
            {
                pd.PlayerEquipmentDic.Add(item, 3);

            }
            return pd;
        }
        else
        {
            return JsonConvert.DeserializeObject<PlayerData>(PlayerDataString);
        }
    }
}
