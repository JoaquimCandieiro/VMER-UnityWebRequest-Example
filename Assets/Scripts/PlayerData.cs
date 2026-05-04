using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [Serializable]
    public class PlayerDataInfoArray
    {
        public PlayerDataInfo[] _playerDataInfoArray;
    }

    [Serializable]
    public class PlayerDataInfo
    {
        public string name = "NaN";
        public int lives = -1;
        public float health = -1f;
    }

    public static PlayerDataInfoArray CreateClassFromJson(string json)
    {
        return JsonUtility.FromJson<PlayerDataInfoArray>(json);
    }
}


