using UnityEngine;
using System.Collections;

public class OptionsUI : MonoSingleton<OptionsUI>
{
    public Texture optionsButton, backButton, musicButton, sfxButton, pNButton, achievementsButton, strikeOut;
    public Vector2 optionsButtonPos, optionsButtonSize, backButtonPos, backButtonSize;
    public Vector2 buttonSize, strikeOutSize;
    public Vector2 musicPos, sfxPos, pNPos, achievementsPos, strikeOut1Pos, strikeOut2Pos, strikeOut3Pos;
    public Texture banner;
    public Vector2 bottomBannerPos, bottomBannerSize, labelNamePos, labelONOFFPos, labelNameSize, labelONOFFSize;
    public Vector2 topBannerPos, topBannerSize;
    public int optionsScreenPick, labelPick = 0;
    public string labelName, labelOnOff;
    private float originalWidth = 1366;
    private float originalHeight = 768;
    private Vector3 scale;
    private Vector2 sfxButtonSize, musicButtonSize, achieveButtonSize, pushNotButtonSize;

    private bool buttonPresses, shopBP, backBP, achieveBP, sfxBP, musicBP, pushNotBP;

    void Start()
    {
        sfxButtonSize = buttonSize;
        musicButtonSize = buttonSize;
        achieveButtonSize = buttonSize;
        pushNotButtonSize = buttonSize;
    }

    void Update()
    {
        //if a buton is pressed
        if (buttonPresses)
        {
            //and if the enlarge timer has finished
            if (Utility.Instance.CheckEnlargeTimer() == true)
            {
                if(shopBP)
                {
                    Debug.Log("Touched: shop");
                    GameState.Instance.shopMenu = true;
                    ShopUI.Instance.shopScreenPick = 6;
                    GameState.Instance.optionsMenu = false;
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //resize and scale the button to original values
                    ShopUI.Instance.shopButtonSize = Utility.Instance.ResetButtonScale();
                    ShopUI.Instance.shopButtonPos = Utility.Instance.ResetButtonPosition();
                    //reset the button presses
                    shopBP = false;
                    buttonPresses = false;
                }
                if (backBP)
                {
                    Debug.Log("Touched: back");
                    GameState.Instance.optionsMenu = false;
                    if (optionsScreenPick == 2)
                    {
                        GameState.Instance.treeSelectMenu = true;
                    }
                    if (optionsScreenPick == 3)
                    {
                        GameState.Instance.puzzleSelectMenu = true;
                    }
                    if (optionsScreenPick == 4)
                    {
                        GameState.Instance.pausedMenu = true;
                    }
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //resize and scale the button to original values
                    backButtonSize = Utility.Instance.ResetButtonScale();
                    backButtonPos = Utility.Instance.ResetButtonPosition();
                    //reset the button presses
                    backBP = false;
                    buttonPresses = false;
                }
                if(achieveBP)
                {
                    Debug.Log("Touched: Achievements");
                    GameState.Instance.achievmentMenu = true;
                    GameState.Instance.saveData.DeleteAllKeys();
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //resize and scale the button to original values
                    achieveButtonSize = Utility.Instance.ResetButtonScale();
                    achievementsPos = Utility.Instance.ResetButtonPosition();
                    //reset the button presses
                    achieveBP = false;
                    buttonPresses = false;
                }
                if(sfxBP)
                {
                    if (AudioManager.Instance.sfxOn == true)
                    {
                        AudioManager.Instance.sfxOn = false;
                    }
                    else
                    {
                        AudioManager.Instance.sfxOn = true;
                    }
                    GameState.Instance.saveData.SaveSFXOption(AudioManager.Instance.sfxOn);
                    labelPick = 1;
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //resize and scale the button to original values
                    sfxButtonSize = Utility.Instance.ResetButtonScale();
                    sfxPos = Utility.Instance.ResetButtonPosition();
                    //reset the button presses
                    sfxBP = false;
                    buttonPresses = false;
                }
                if(musicBP)
                {
                    if (AudioManager.Instance.musicOn == true)
                    {
                        AudioManager.Instance.musicOn = false;
                    }
                    else
                    {
                        AudioManager.Instance.musicOn = true;
                    }
                    GameState.Instance.saveData.SaveMusicOption(AudioManager.Instance.musicOn);
                    labelPick = 2;

                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //resize and scale the button to original values
                    musicButtonSize = Utility.Instance.ResetButtonScale();
                    musicPos = Utility.Instance.ResetButtonPosition();
                    //reset the button presses
                    musicBP = false;
                    buttonPresses = false;
                }
                if(pushNotBP)
                {
                    if (AudioManager.Instance.pNOn == true)
                    {
                        AudioManager.Instance.pNOn = false;
                    }
                    else
                    {
                        AudioManager.Instance.pNOn = true;
                    }
                    GameState.Instance.saveData.SavePushNotificationOption(AudioManager.Instance.pNOn);
                    labelPick = 3;

                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //resize and scale the button to original values
                    pushNotButtonSize = Utility.Instance.ResetButtonScale();
                    pNPos = Utility.Instance.ResetButtonPosition();
                    //reset the button presses
                    pushNotBP = false;
                    buttonPresses = false;
                }
            }
        }
    }

    void OnGUI()
    {   
        //Scale UI based on original resolution
        scale.x = Screen.width / originalWidth; // calculate hor scale
        scale.y = Screen.height / originalHeight; // calculate vert scale
        scale.z = 1;
        Matrix4x4 svMat = GUI.matrix;
        // substitute matrix - only scale is altered from standard
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

        if (GameState.Instance.optionsMenu == true)
        {
            //top banner
            GUI.DrawTexture(new Rect(topBannerPos.x, topBannerPos.y, topBannerSize.x, topBannerSize.y), banner, ScaleMode.StretchToFill, true, 0);
            //bottom banner
            GUI.DrawTexture(new Rect(bottomBannerPos.x, bottomBannerPos.y, bottomBannerSize.x, bottomBannerSize.y), banner, ScaleMode.StretchToFill, true, 0);
            
            //SFX button
            if (GUI.Button(new Rect(sfxPos.x, sfxPos.y, sfxButtonSize.x, sfxButtonSize.y), sfxButton, "label"))
            {
                if (buttonPresses == false)
                {
                    sfxButtonSize = Utility.Instance.EnlargeButtonScale(sfxButtonSize);
                    sfxPos = Utility.Instance.EnlargeButtonPosition(sfxPos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    sfxBP = true;
                }                
            }

            //Music button
            if (GUI.Button(new Rect(musicPos.x, musicPos.y, musicButtonSize.x, musicButtonSize.y), musicButton, "label"))
            {
                if (buttonPresses == false)
                {
                    musicButtonSize = Utility.Instance.EnlargeButtonScale(musicButtonSize);
                    musicPos = Utility.Instance.EnlargeButtonPosition(musicPos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    musicBP = true;
                }                
            }

            //Push Notifications button
            if (GUI.Button(new Rect(pNPos.x, pNPos.y, pushNotButtonSize.x, pushNotButtonSize.y), pNButton, "label"))
            {
                if (buttonPresses == false)
                {
                    pushNotButtonSize = Utility.Instance.EnlargeButtonScale(pushNotButtonSize);
                    pNPos = Utility.Instance.EnlargeButtonPosition(pNPos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    pushNotBP = true;
                }                
            }
            //Achievements button
            if (GUI.Button(new Rect(achievementsPos.x, achievementsPos.y, achieveButtonSize.x, achieveButtonSize.y), achievementsButton, "label"))
            {
                if (buttonPresses == false)
                {
                    achieveButtonSize = Utility.Instance.EnlargeButtonScale(achieveButtonSize);
                    achievementsPos = Utility.Instance.EnlargeButtonPosition(achievementsPos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    achieveBP = true;
                }                 
            }
            
            //back button
            if (GUI.Button(new Rect(backButtonPos.x, backButtonPos.y, backButtonSize.x, backButtonSize.y), backButton, "label"))
            {
                if (buttonPresses == false)
                {
                    backButtonSize = Utility.Instance.EnlargeButtonScale(backButtonSize);
                    backButtonPos = Utility.Instance.EnlargeButtonPosition(backButtonPos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    backBP = true;
                }                
            }

            //Shop button
            if (GUI.Button(new Rect(ShopUI.Instance.shopButtonPos.x, ShopUI.Instance.shopButtonPos.y, ShopUI.Instance.shopButtonSize.x, ShopUI.Instance.shopButtonSize.y), ShopUI.Instance.shopButton, "label"))
            {
                if (buttonPresses == false)
                {
                    ShopUI.Instance.shopButtonSize = Utility.Instance.EnlargeButtonScale(ShopUI.Instance.shopButtonSize);
                    ShopUI.Instance.shopButtonPos = Utility.Instance.EnlargeButtonPosition(ShopUI.Instance.shopButtonPos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    shopBP = true;
                }
            }

            if(labelPick == 1 )
            {
                labelName = "SFX";
                if (AudioManager.Instance.sfxOn == false)
                {
                    labelOnOff = "Off";
                }
                else
                {
                    labelOnOff = "On"; 
                }
            }
            else if(labelPick == 2)
            {
                labelName = "Music";
                if (AudioManager.Instance.musicOn == false)
                {
                    labelOnOff = "Off";
                }
                else
                {
                    labelOnOff = "On";
                }
            }
            else if (labelPick == 3)
            {
                labelName = "Notifications";
                if (AudioManager.Instance.pNOn == false)
                {
                    labelOnOff = "Off";
                }
                else
                {
                    labelOnOff = "On";
                }
            }

            if (labelPick > 0)
            {
                GUI.Label(new Rect(labelNamePos.x, labelNamePos.y, labelNameSize.x, labelNameSize.y), labelName);
                GUI.Label(new Rect(labelONOFFPos.x, labelONOFFPos.y, labelONOFFSize.x, labelONOFFSize.y), labelOnOff);
            }

            if (AudioManager.Instance.sfxOn == false)
            {
                GUI.DrawTexture(new Rect(strikeOut1Pos.x, strikeOut1Pos.y, strikeOutSize.x, strikeOutSize.y), strikeOut, ScaleMode.StretchToFill, true, 0);
            }
            if (AudioManager.Instance.musicOn == false)
            {
                GUI.DrawTexture(new Rect(strikeOut2Pos.x, strikeOut2Pos.y, strikeOutSize.x, strikeOutSize.y), strikeOut, ScaleMode.StretchToFill, true, 0);
            }
            if (AudioManager.Instance.pNOn == false)
            {
                GUI.DrawTexture(new Rect(strikeOut3Pos.x, strikeOut3Pos.y, strikeOutSize.x, strikeOutSize.y), strikeOut, ScaleMode.StretchToFill, true, 0);
            }
        }
        
        // restore matrix before returning
        GUI.matrix = svMat; // restore matrix
    }
}
