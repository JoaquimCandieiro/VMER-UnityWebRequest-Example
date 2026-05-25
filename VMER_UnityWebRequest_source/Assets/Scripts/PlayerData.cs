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
        public string name = "teste";
        public int lives = 99;
        public float health = 100f;
    }

    public static PlayerDataInfoArray CreateClassFromJson(string json)
    {
        return JsonUtility.FromJson<PlayerDataInfoArray>(json);
    }

    public static string CreateJsonFromClass(PlayerDataInfo playerDataInfo)
    {
        return JsonUtility.ToJson(playerDataInfo);
    }
}


