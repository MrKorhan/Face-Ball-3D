using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelOpenClose : MonoBehaviour
{
    public Button settings_button, settings_close_button, market_button;
    public GameObject SettingsPanel;

    public void ClickedSettingsButton()
    {
        settings_button.interactable = false;
        market_button.interactable = false;
        SettingsPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ClickedSettingsClose()
    {
        settings_button.interactable = true;
        market_button.interactable = true;
        SettingsPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
