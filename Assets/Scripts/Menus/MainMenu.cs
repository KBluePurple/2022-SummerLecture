using UnityEngine;

public class MainMenu : Menu<MainMenu>
{
    public void OnPlayPressed()
    {
        Debug.Log($"게임 시작");
    }

    public void OnSettngPressed()
    {
        SettingMenu.Open();
    }

    public void OnCreditPressed()
    {
        CreditMenu.Open();
    }

    public override void OnBackPressed()
    {
        #if UNITY_EDITOR
        #else
        Application.Quit();
        #endif
    }
}