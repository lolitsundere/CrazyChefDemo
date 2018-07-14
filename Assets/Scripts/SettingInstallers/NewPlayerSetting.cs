using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Setting/NewPlayerSetting",fileName ="NewPlayerSetting")]
public class NewPlayerSetting : ScriptableObject
{
    [SerializeField]
    private int 初始金币数;
    [SerializeField]
    private int 初始汤勺数;
    [SerializeField]
    private int[] 初始装备ID;

    public int InitialGold { get { return 初始金币数; } }
    public int InitialSpoon { get { return 初始汤勺数; } }
    public int[] InitialEquipmentID { get { return 初始装备ID; } }
}
