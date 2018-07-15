using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;
using System;

public class CookGameController: MonoBehaviour
{
    private Level level;
    private Shop shop;
    private GameObject panel;
    private List<int> AutoIngredientList;
    private Dictionary<int, GameObject> NonAutoIngredientDic;
    private Dictionary<int, List<GameObject>> FoodMakerDic;
    private Dictionary<int, List<GameObject>> FoodHolderDic;

    private System.Random rdm = new System.Random();
    private List<double> customerComingTimeList;
    private List<GameObject> customerList;

    private void Start()
    {
        SetUpLevel(1+"");
    }

    private void SetUpLevel(string LevelID)
    {
        AutoIngredientList = new List<int>();
        NonAutoIngredientDic = new Dictionary<int, GameObject>();
        FoodMakerDic = new Dictionary<int, List<GameObject>>();
        FoodHolderDic = new Dictionary<int, List<GameObject>>();
        customerList = new List<GameObject>();

        level = GameDictionary.Instance.GetLevel(LevelID);
        shop = GameDictionary.Instance.GetShop(level.ShopID);
        var g = Resources.Load(@"Prefabs/Shops/" + shop.ID) as GameObject;
        panel = Instantiate<GameObject>(Resources.Load(@"Prefabs/Shops/" + shop.ID) as GameObject, transform);
        foreach (var item in shop.IngredientID)
        {
            if (!PlayerData.Instance.PlayerEquipmentDic.ContainsKey(item))
            {
                GameObject.Find(item + "").SetActive(false);
            }
            else
            {
                if (!GameDictionary.Instance.GetIngredient(item).IsAuto)
                {
                    var go = GameObject.Find(item + "");
                    NonAutoIngredientDic.Add(item, go);
                }
                else
                {
                    AutoIngredientList.Add(item);
                }
            }
        }
        foreach (var item in shop.FoodMakerID)
        {
            if (GameDictionary.Instance.GetFoodMaker(item).IsOneForAll)
            {
                if (!PlayerData.Instance.PlayerEquipmentDic.ContainsKey(item))
                {
                    GameObject.Find(item + "").SetActive(false);
                }
                else
                {
                    var go = GameObject.Find(item + "");
                    int star = PlayerData.Instance.PlayerEquipmentDic[item];
                    var foodMaker = GameDictionary.Instance.GetFoodMaker(item);
                    var setting = go.GetComponent<FoodMakerSetting>();
                    switch (star)
                    {
                        case 1:
                            setting.MaxCookingTime = foodMaker.OneStarMakingTime;
                            setting.MaxBurningTime = foodMaker.OneStarBurntTime;
                            break;
                        case 2:
                            setting.MaxCookingTime = foodMaker.TwoStarMakingTime;
                            setting.MaxBurningTime = foodMaker.TwoStarBurntTime;
                            break;
                        case 3:
                            setting.MaxCookingTime = foodMaker.ThreeStarMakingTime;
                            setting.MaxBurningTime = foodMaker.ThreeStarBurntTime;
                            break;
                    }
                    FoodMakerDic.Add(item, new List<GameObject>());
                    FoodMakerDic[item].Add(go);
                }
            }
            else
            {
                if (!PlayerData.Instance.PlayerEquipmentDic.ContainsKey(item))
                {
                    GameObject.Find(item + "").SetActive(false);
                    if (GameDictionary.Instance.GetFoodMaker(item).ThreeStarMakerCount != 1)
                    {
                        for (int i = 1; i < GameDictionary.Instance.GetFoodMaker(item).ThreeStarMakerCount; i++)
                        {
                            GameObject.Find(item + "_" + i).SetActive(false);
                        }
                    }
                }
                else
                {
                    var go = GameObject.Find(item + "");
                    int star = PlayerData.Instance.PlayerEquipmentDic[item];
                    var foodMaker = GameDictionary.Instance.GetFoodMaker(item);
                    int count = 0;
                    double maxCookingTime = 0;
                    double maxBurningTime = 0;
                    switch (star)
                    {
                        case 1:
                            maxCookingTime = foodMaker.OneStarMakingTime;
                            maxBurningTime = foodMaker.OneStarBurntTime;
                            count = foodMaker.OneStarMakerCount;
                            break;
                        case 2:
                            maxCookingTime = foodMaker.TwoStarMakingTime;
                            maxBurningTime = foodMaker.TwoStarBurntTime;
                            count = foodMaker.TwoStarMakerCount;
                            break;
                        case 3:
                            maxCookingTime = foodMaker.ThreeStarMakingTime;
                            maxBurningTime = foodMaker.ThreeStarBurntTime;
                            count = foodMaker.ThreeStarMakerCount;
                            break;
                    }

                    var Setting = go.GetComponent<FoodMakerSetting>();
                    Setting.MaxBurningTime = maxBurningTime;
                    Setting.MaxCookingTime = maxCookingTime;

                    for (int i = count; i < GameDictionary.Instance.GetFoodMaker(item).ThreeStarMakerCount; i++)
                    {
                        GameObject.Find(item + "_" + i).SetActive(false);
                    }

                    FoodMakerDic.Add(item, new List<GameObject>());
                    FoodMakerDic[item].Add(GameObject.Find(item + ""));
                    for (int i = 1; i < count; i++)
                    {
                        go = GameObject.Find(item + "_" + i);
                        Setting = go.GetComponent<FoodMakerSetting>();
                        Setting.MaxBurningTime = maxBurningTime;
                        Setting.MaxCookingTime = maxCookingTime;
                        FoodMakerDic[item].Add(go);
                    }
                }
            }
        }
        foreach (var item in shop.FoodHolderID)
        {
            if (!PlayerData.Instance.PlayerEquipmentDic.ContainsKey(item))
            {
                GameObject.Find(item + "").SetActive(false);
                if (GameDictionary.Instance.GetFoodHolder(item).ThreeStarFoodCount != 1)
                {
                    for (int i = 1; i < GameDictionary.Instance.GetFoodHolder(item).ThreeStarFoodCount; i++)
                    {
                        GameObject.Find(item + "_" + i).SetActive(false);
                    }
                }
            }
            else
            {
                int count = 0;
                if (PlayerData.Instance.PlayerEquipmentDic[item] == 2)
                {
                    count = GameDictionary.Instance.GetFoodHolder(item).TwoStarFoodCount;
                }
                else if (PlayerData.Instance.PlayerEquipmentDic[item] == 1)
                {
                    count = GameDictionary.Instance.GetFoodHolder(item).OneStarFoodCount;
                }
                else
                {
                    count = GameDictionary.Instance.GetFoodHolder(item).ThreeStarFoodCount;
                }

                for (int i = count; i < GameDictionary.Instance.GetFoodHolder(item).ThreeStarFoodCount; i++)
                {
                    GameObject.Find(item + "_" + i).SetActive(false);
                }

                FoodHolderDic.Add(item, new List<GameObject>());
                FoodHolderDic[item].Add(GameObject.Find(item + ""));
                for (int i = 1; i < count; i++)
                {
                    FoodHolderDic[item].Add(GameObject.Find(item + "_" + i));
                }
            }
        }

        ///Test时使用
        if (true)
        {
            foreach (var item in NonAutoIngredientDic)
            {
                item.Value.GetComponentInChildren<Text>().text = GameDictionary.Instance.GetIngredient(item.Key).Name_CN;
            }

            foreach (var item in FoodMakerDic)
            {
                foreach (var go in item.Value)
                {
                    go.GetComponentInChildren<Text>().text = GameDictionary.Instance.GetFoodMaker(item.Key).Name_CN;
                }
            }

            foreach (var item in FoodHolderDic)
            {
                foreach (var go in item.Value)
                {
                    go.GetComponentInChildren<Text>().text = GameDictionary.Instance.GetFoodHolder(item.Key).Name_CN;
                }
            }
        }

        foreach (var item in NonAutoIngredientDic)
        {
            item.Value.GetComponent<Button>().onClick.AddListener(() => IngredientClick(item.Key));
        }

        foreach (var item in FoodMakerDic)
        {
            if (!GameDictionary.Instance.GetFoodMaker(item.Key).IsAuto)
            {
                foreach (var fm in item.Value)
                {
                    fm.GetComponent<Button>().onClick.AddListener(() => FoodMakerClick(item.Key, fm));
                }
            }
        }

        foreach (var item in FoodHolderDic)
        {
            foreach (var fh in item.Value)
            {
                fh.GetComponent<Button>().onClick.AddListener(() => FoodHolderClick(item.Key, fh));
            }
        }

        customerComingTimeList = new List<double>();
        for (int i = 0; i < level.MaximumCustomerWaiting; i++)
        {
            customerComingTimeList.Add(rdm.NextDouble()*2*level.AverageCustomerComeTime);
        }
    }

    private void CreateCustomer()
    {

    }

    private void IngredientClick(int id)
    {
        var targetID = GameDictionary.Instance.GetIngredient(id).TargetID;
        if (FoodMakerDic.ContainsKey(targetID))
        {
            foreach (var item in FoodMakerDic[targetID])
            {
                var setting = item.GetComponent<FoodMakerSetting>();
                if (!setting.IsCooking && !setting.IsBurning)
                {
                    setting.IsCooking = true;
                    break;
                }
            }
        }
        else if (FoodHolderDic.ContainsKey(targetID))
        {
            foreach (var item in FoodHolderDic[targetID])
            {
                var setting = item.GetComponent<FoodHolderSetting>();
                List<int> tempList;
                if (setting.FoodID != 0)
                {
                    tempList = GameDictionary.Instance.GetFood(setting.FoodID).SourceID.ToList();
                }
                else
                {
                    tempList = new List<int>();
                }
                var sourceID = id;
                if (!tempList.Contains(sourceID))
                {
                    tempList.Add(sourceID);
                    foreach (var foodID in shop.FoodID)
                    {
                        if (GameDictionary.Instance.GetFood(foodID).SourceID.All(tempList.Contains) && GameDictionary.Instance.GetFood(foodID).SourceID.Count == tempList.Count)
                        {
                            setting.FoodID = foodID;
                            return;
                        }
                    }
                }
            }
        }
    }

    private void FoodMakerClick(int id, GameObject go)
    {
        var targetID = GameDictionary.Instance.GetFoodMaker(id).TargetID;
        var resultID = GameDictionary.Instance.GetFoodMaker(id).ResultID;
        var fmSetting = go.GetComponent<FoodMakerSetting>();
        if ((!fmSetting.IsCooking && fmSetting.CurrentCookingTime > fmSetting.MaxCookingTime) && (!fmSetting.IsBurning || fmSetting.MaxBurningTime > fmSetting.CurrentBurningTime))
        {
            if (FoodHolderDic.ContainsKey(targetID))
            {
                foreach (var item in FoodHolderDic[targetID])
                {
                    var setting = item.GetComponent<FoodHolderSetting>();
                    List<int> tempList;
                    if (setting.FoodID != 0)
                    {
                        tempList = GameDictionary.Instance.GetFood(setting.FoodID).SourceID.ToList();
                    }
                    else
                    {
                        tempList = new List<int>();
                    }
                    var sourceID = GameDictionary.Instance.GetFood(resultID).SourceID.First();
                    if (!tempList.Contains(sourceID))
                    {
                        tempList.Add(sourceID);
                        foreach (var foodID in shop.FoodID)
                        {
                            if (GameDictionary.Instance.GetFood(foodID).SourceID.All(tempList.Contains) && GameDictionary.Instance.GetFood(foodID).SourceID.Count == tempList.Count)
                            {
                                setting.FoodID = foodID;
                                fmSetting.CurrentCookingTime = 0;
                                fmSetting.CurrentBurningTime = 0;
                                fmSetting.IsBurning = false;
                                if (!GameDictionary.Instance.GetFoodMaker(id).IsAuto)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (fmSetting.IsBurning && fmSetting.MaxBurningTime <= fmSetting.CurrentBurningTime)
        {
            fmSetting.CurrentCookingTime = 0;
            fmSetting.CurrentBurningTime = 0;
            fmSetting.IsBurning = false;
        }
    }

    private void FoodHolderClick(int id, GameObject go)
    {
        go.GetComponent<FoodHolderSetting>().FoodID = 0;
    }

    private void Update()
    {
        foreach (var item in AutoIngredientList)
        {
            int targetID = GameDictionary.Instance.GetIngredient(item).TargetID;
            if (FoodMakerDic.ContainsKey(targetID))
            {
                targetID = GameDictionary.Instance.GetFoodMaker(targetID).TargetID;
            }
            foreach (var fh in FoodHolderDic[targetID])
            {
                var setting = fh.GetComponent<FoodHolderSetting>();
                if (setting.FoodID == 0)
                {
                    IngredientClick(item);
                    break;
                }
            }
        }

        foreach (var item in FoodMakerDic)
        {
            foreach (var go in item.Value)
            {
                var setting = go.GetComponent<FoodMakerSetting>();
                if (setting.IsCooking)
                {
                    setting.CurrentCookingTime += Time.deltaTime;

                    if (setting.CurrentCookingTime > setting.MaxCookingTime)
                    {
                        setting.IsCooking = false;
                        if (GameDictionary.Instance.GetFoodMaker(item.Key).IsAuto)
                        {
                            FoodMakerClick(item.Key, go);
                        }
                        if (GameDictionary.Instance.GetFoodMaker(item.Key).CanBurnt)
                        {
                            setting.IsBurning = true;
                        }
                    }
                }
                else if (setting.IsBurning)
                {
                    setting.CurrentBurningTime += Time.deltaTime;
                }
            }
        }

        customerComingTimeList = customerComingTimeList.Select(d => d - Time.deltaTime).ToList();
        List<double> tempList = customerComingTimeList.Where(d => d < 0).Select(d => d).ToList();
        customerComingTimeList = customerComingTimeList.Except(tempList).ToList();
        for (int i = 0; i < tempList.Count; i++)
        {
            CreateCustomer();
        }
        
        while ((customerList.Count + customerComingTimeList.Count) < level.MaximumCustomerWaiting)
        {
            customerComingTimeList.Add(rdm.NextDouble() * 2 * level.AverageCustomerComeTime);
        }

        ///Test时使用
        ///
        if (true)
        {
            foreach (var item in FoodMakerDic)
            {
                foreach (var go in item.Value)
                {
                    var setting = go.GetComponent<FoodMakerSetting>();
                    if (setting.CurrentCookingTime == 0)
                    {
                        go.GetComponentInChildren<Text>().text = GameDictionary.Instance.GetFoodMaker(item.Key).Name_CN + "(空)";
                    }
                    else if (setting.IsCooking)
                    {
                        go.GetComponentInChildren<Text>().text = "烹饪中(" + Math.Round(setting.CurrentCookingTime/setting.MaxCookingTime*100) +"%）";
                    }
                    else if (setting.CurrentCookingTime > setting.MaxCookingTime && !setting.IsBurning)
                    {
                        go.GetComponentInChildren<Text>().text = "烹饪好了";
                    }
                    else if (setting.IsBurning && setting.CurrentBurningTime < setting.MaxBurningTime)
                    {
                        go.GetComponentInChildren<Text>().text = "烹饪好了(距离烧焦还有"+ Math.Round(setting.MaxBurningTime - setting.CurrentBurningTime)+"秒)";
                    }
                    else
                    {
                        go.GetComponentInChildren<Text>().text = "烧焦了";
                    }
                }
            }

            foreach (var item in FoodHolderDic)
            {
                foreach (var go in item.Value)
                {
                    var setting = go.GetComponent<FoodHolderSetting>();
                    if (setting.FoodID == 0)
                    {
                        go.GetComponentInChildren<Text>().text = GameDictionary.Instance.GetFoodHolder(item.Key).Name_CN + "(空)";
                    }
                    else
                    {
                        go.GetComponentInChildren<Text>().text = GameDictionary.Instance.GetFood(setting.FoodID).Name_CN;
                    }
                }
            }
        }
    }
}
