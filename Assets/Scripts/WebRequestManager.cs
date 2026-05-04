using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestManager : MonoBehaviour
{
    [SerializeField] private string _serverPath = "http://localhost:8080";
    [SerializeField] private string _getUrl = "/get-data";

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
            PostRequest();
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

        // check for errors
        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Error: {webRequest.error}");
        }
        // If no errors, process the response
        else
        {
            Debug.Log($"Received: {webRequest.downloadHandler.text}");

            string responseText = webRequest.downloadHandler.text;
            PlayerData.PlayerDataInfoArray playerDataInfoArray = PlayerData.CreateClassFromJson(responseText);
            //Debug.Log($"Parsed-form:\nPlayer Name: {playerDataInfo.name}, Lives: {playerDataInfo.lives}, Health: {playerDataInfo.health}");

            for (int i = 0; i < playerDataInfoArray._playerDataInfoArray.Length; i++)
            {
                PlayerData.PlayerDataInfo playerDataInfo = playerDataInfoArray._playerDataInfoArray[i];
                Debug.Log($"Player Name: {playerDataInfo.name}, Lives: {playerDataInfo.lives}, Health: {playerDataInfo.health}");
            }
        }
    }

    private void PostRequest()
    {

    }
}
