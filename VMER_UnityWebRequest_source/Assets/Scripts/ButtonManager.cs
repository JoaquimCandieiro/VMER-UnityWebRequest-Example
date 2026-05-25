using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private WebRequestManager _webRequestManager;

    private void Awake()
    {
        
    }

    public void OnButtonEventClick(string buttonType)
    {
        //Debug.Log($"Button {buttonType} Clicked!");
        _webRequestManager.OnButtonClicked(buttonType);
    }
}
