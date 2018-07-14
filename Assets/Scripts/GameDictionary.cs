using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

/// <summary>
/// 记录游戏数据
/// </summary>
public class GameDictionary
{
    /// <summary>
    /// 食物素材字典
    /// </summary>
    [JsonProperty]
    private Dictionary<int, Ingredient> ingredientDic;

    /// <summary>
    /// 食物托盘字典
    /// </summary>
    [JsonProperty]
    private Dictionary<int, FoodHolder> foodHolderDic;

    /// <summary>
    /// 制作食物的机器字典 
    /// </summary>
    [JsonProperty]
    private Dictionary<int, FoodMaker> foodMakerDic;

    /// <summary>
    /// 食物字典
    /// </summary>
    [JsonProperty]
    private Dictionary<int, Food> foodDic;

    /// <summary>
    /// 店铺字典
    /// </summary>
    [JsonProperty]
    private Dictionary<int, Shop> shopDic;

    /// <summary>
    /// 关卡字典 
    /// </summary>
    [JsonProperty]
    private Dictionary<string, Level> levelDic;

    /// <summary>
    /// 单例
    /// </summary>
    public static GameDictionary Instance
    {
        get
        {
            if (instance == null)
            {
                instance = SetDictionary();
            }
            return instance;
        }
    }
    private static GameDictionary instance;

    private static GameDictionary SetDictionary()
    {
        string GameDicString = PlayerPrefs.GetString("GameDic");

        if (GameDicString == "")
        {
            var dic = new GameDictionary();
            dic.ingredientDic = new Dictionary<int, Ingredient>();
            dic.foodHolderDic = new Dictionary<int, FoodHolder>();
            dic.foodMakerDic = new Dictionary<int, FoodMaker>();
            dic.foodDic = new Dictionary<int, Food>();
            dic.shopDic = new Dictionary<int, Shop>();
            dic.levelDic = new Dictionary<string, Level>();
            foreach (var item in JsonConvert.DeserializeObject<List<IngredientFromJson>>(Resources.Load<TextAsset>(@"Data/Ingredient").text))
            {
                var temp = new Ingredient(item);
                dic.ingredientDic.Add(temp.ID, temp);
            }
            foreach (var item in JsonConvert.DeserializeObject<List<FoodHolderFromJson>>(Resources.Load<TextAsset>(@"Data/FoodHolder").text))
            {
                var temp = new FoodHolder(item);
                dic.foodHolderDic.Add(temp.ID, temp);
            }
            foreach (var item in JsonConvert.DeserializeObject<List<FoodMakerFromJson>>(Resources.Load<TextAsset>(@"Data/FoodMaker").text))
            {
                var temp = new FoodMaker(item);
                dic.foodMakerDic.Add(temp.ID, temp);
            }
            foreach (var item in JsonConvert.DeserializeObject<List<FoodFromJson>>(Resources.Load<TextAsset>(@"Data/Food").text))
            {
                var temp = new Food(item);
                dic.foodDic.Add(temp.ID, temp);
            }
            foreach (var item in JsonConvert.DeserializeObject<List<ShopFromJson>>(Resources.Load<TextAsset>(@"Data/Shop").text))
            {
                var temp = new Shop(item);
                dic.shopDic.Add(temp.ID, temp);
            }
            foreach (var item in JsonConvert.DeserializeObject<List<LevelFromJson>>(Resources.Load<TextAsset>(@"Data/Level").text))
            {
                var temp = new Level(item);
                dic.levelDic.Add(temp.ID, temp);
            }

            return dic;
        }
        else
        {
            return JsonConvert.DeserializeObject<GameDictionary>(GameDicString);
        }
    }

    public Shop GetShop(int id)
    {
        return shopDic[id];
    }

    public Ingredient GetIngredient(int id)
    {
        return ingredientDic[id];
    }

    public Food GetFood(int id)
    {
        return foodDic[id];
    }

    public FoodMaker GetFoodMaker(int id)
    {
        return foodMakerDic[id];
    }

    public FoodHolder GetFoodHolder(int id)
    {
        return foodHolderDic[id];
    }

    public Level GetLevel(string id)
    {
        return levelDic[id];
    }

    public class FoodFromJson
    {
        public string ID;
        public string Name_CN;
        public string SourceID;
    }

    public class FoodHolderFromJson
    {
        public string ID;
        public string Name_CN;
        public string OneStarFoodCount;
        public string TwoStarFoodCount;
        public string ThreeStarFoodCount;
        public string OneStarUpgradeGold;
        public string TwoStarUpgradeGold;
        public string ThreeStarUpgradeGold;
        public string UpdateWithOther;
        public string UpdateWithID;
    }

    public class FoodMakerFromJson
    {
        public string ID;
        public string Name_CN;
        public string OneStarMakingTime;
        public string TwoStarMakingTime;
        public string ThreeStarMakingTime;
        public string OneStarMakerCount;
        public string TwoStarMakerCount;
        public string ThreeStarMakerCount;
        public string OneStarUpgradeGold;
        public string TwoStarUpgradeGold;
        public string ThreeStarUpgradeGold;
        public string TargetID;
        public string ResultID;
        public string IsAuto;
        public string CanBurnt;
        public string OneStarBurntTime;
        public string TwoStarBurntTime;
        public string ThreeStarBurntTime;
        public string IsOneForAll;
    }

    public class IngredientFromJson
    {
        public string ID;
        public string Name_CN;
        public string OneStarSellGold;
        public string TwoStarSellGold;
        public string ThreeStarSellGold;
        public string OneStarUpgradeGold;
        public string TwoStarUpgradeGold;
        public string ThreeStarUpgradeGold;
        public string IsAuto;
        public string TargetID;
    }

    public class ShopFromJson
    {
        public string ID;
        public string Name_CN;
        public string IngredientID;
        public string FoodMakerID;
        public string FoodHolderID;
        public string FoodID;
    }

    public class LevelFromJson
    {
        public string ID;
        public string ShopID;
        public string WantedFood;
        public string OneFoodProbability;
        public string TwoFoodProbability;
        public string ThreeFoodProbability;
        public string MaximumCustomerWaiting;
        public string HasTimeLimit;
        public string MaximumCustomer;
        public string TimeLimit;
        public string AverageCustomerComeTime;
        public string OneFoodMaximumCustomerWaitingTime;
        public string TwoFoodMaximumCustomerWaitingTime;
        public string ThreeFoodMaximumCustomerWaitingTime;
        public string TargetGold;
        public string UseComboGoldAsTargetGold;
        public string BurntFail;
        public string BurntFailCount;
        public string CustomerLeaveFail;
        public string CustomerLeaveFailCount;
    }

}
