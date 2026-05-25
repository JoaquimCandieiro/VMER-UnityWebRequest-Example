using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestManager : MonoBehaviour
{
    [SerializeField] private string _serverPath = "http://localhost:8080";
    [SerializeField] private string _getUrl = "/get-data";
    [SerializeField] private string _postUrl = "/post-data";
    private void Start()
    {
        
    }

    public void OnButtonClicked(string buttonType)
    {
        Debug.Log($"WebRequestManager received button click: {buttonType}");

        if (buttonType == "get")
        {
            StartCoroutine(GetRequest());
        }
        else if (buttonType == "post")
        {
            StartCoroutine(PostRequest());
        }
    }

    private IEnumerator GetRequest()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(_serverPath + _getUrl);
        // Set a timeout for the request (In seconds)
        webRequest.timeout = 10;
        // Send the request and wait for a response
        yield return webRequest.SendWebRequest();
        Debug.Log("Response after SendWebRequest");

        // Validate the response and process it if it's valid
        if (ValidateResponse(webRequest))
        {
            ProcessRequestDebug(webRequest);
            ProcessRequestGet(webRequest);
        }
    }

    private IEnumerator PostRequest()
    {
        PlayerData.PlayerDataInfo playerDataInfo = new PlayerData.PlayerDataInfo
        {
            name = "Jotha",
            lives = 3,
            health = 100.0f
        };

        string playerInfoJson = PlayerData.CreateJsonFromClass(playerDataInfo);

        UnityWebRequest webRequest = UnityWebRequest.Post(_serverPath + _postUrl, playerInfoJson, "application/json");
        // Set a timeout for the request (In seconds)
        webRequest.timeout = 10;
        // Send the request and wait for a response
        yield return webRequest.SendWebRequest();
        Debug.Log("Response after SendWebRequest");

        // Validate the response and process it if it's valid
        if (ValidateResponse(webRequest))
        {
            ProcessRequestDebug(webRequest);
        }
    }

    private bool ValidateResponse(UnityWebRequest webRequest)
    {
        // Check for errors
        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError || webRequest.result == UnityWebRequest.Result.DataProcessingError)
        {
            Debug.LogError($"Error: {webRequest.error}");
            return false;
        }
        // If no errors, return true
        return true;
    }

    private void ProcessRequestDebug(UnityWebRequest webRequest)
    {
        Debug.Log($"Received: {webRequest.downloadHandler.text}");
    }

    private void ProcessRequestGet(UnityWebRequest webRequest)
    {
        string responseText = webRequest.downloadHandler.text;
        PlayerData.PlayerDataInfoArray playerDataInfoArray = PlayerData.CreateClassFromJson(responseText);
        //Debug.Log($"Parsed-form:\nPlayer Name: {playerDataInfo.name}, Lives: {playerDataInfo.lives}, Health: {playerDataInfo.health}");

        for (int i = 0; i < playerDataInfoArray._playerDataInfoArray.Length; i++)
        {
            PlayerData.PlayerDataInfo playerDataInfo = playerDataInfoArray._playerDataInfoArray[i];
            Debug.Log($"Player Name: {playerDataInfo.name}");
            Debug.Log($"Player Lives: {playerDataInfo.lives}");
            Debug.Log($"Player Health: {playerDataInfo.health}");
        }
    }
}