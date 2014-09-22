using UnityEngine;
using System.Collections;

public class StartScreenUI : MonoBehaviour
{
    //PUBLIC
    //Background variables
    public Timer logoTimer;
    public bool timeCheck;
    public Texture ADGLogo;
    public Vector2 adgLogoPos, adgLogoSize;
    public string adgFooter;
    public Vector2 adgFooterPos, adgFooterSize;
    public string adgARR;  
    public Vector2 adgARRPos, adgARRSize;
    public Texture copyRight;
    public Vector2 copyRightPos, copyRightSize; 
    public Texture backgroundScreen;
    public Vector2 backgroundScreenPos, backgroundScreenSize;
    public Texture mmLogoScreen;
    public Vector2 mmLogoPos, mmLogoSize;
    public Texture mmSquirrelScreen;
    public Vector2 mmSquirrelPos, mmSquirrelSize;
    public Texture banner;
    public Vector2 bottomBannerPos, bottomBannerSize;
    public Vector2 mmBottomBannerPos, mmBottomBannerSize;
    public Vector2 topBannerPos, topBannerSize;
    public Vector2 mmOptionsPos, mmOptionsSize;
    public Vector2 mmShopPos, mmShopSize;
    //Button Variables
    public Texture playButton;
    public Vector2 playButtonPos, playButtonSize;
    public Texture backButton, menuButton;
    public Vector2 backButtonPos, backButtonSize;
    //Acorns variables
    public Texture bronzeAcorn;
    public Vector2 bronzeAcornPos, acornSize;
    public Texture silverAcorn;
    public Vector2 silverAcornPos;
    public Texture goldAcorn;
    public Vector2 goldAcornPos;
    public Vector2 bronzeAcornTextPos, acornTextSize;
    public Texture lockedAcorn;
    public string bronzeAcornTextCaption;
    public Vector2 silverAcornTextPos;
    public string silverAcornTextCaption;
    public Vector2 goldAcornTextPos;
    public string goldAcornTextCaption;
    //Puzzle select variables
    public Texture blueAcorn, acornChoice;
    public Vector2 pAcornSize, pAcorn1Pos, pAcorn2Pos, pAcorn3Pos, pAcorn4Pos, pAcorn5Pos,
                   pAcorn6Pos, pAcorn7Pos, pAcorn8Pos, pAcorn9Pos, pAcorn10Pos, pAcorn11Pos, pAcorn12Pos;
    public Vector2 acornNoOffset, acornNoSize;
    //carousel variables
    public Vector2 carouselButtonSizeLarge, carouselButtonSizeSmall;
    public Vector2 carouselLeftPos, carouselMiddlePos, carouselRightPos;
    public int currentTreeSelected, carouselLeftTree, carouselRightTree;  

    //PRIVATE
    //Screen Scale variables
    private float originalWidth = 1366;
    private float originalHeight = 768;
    private Vector3 scale;
    //Puzzle select variables
    private Vector2 pAcorn1Size, pAcorn2Size, pAcorn3Size, pAcorn4Size, pAcorn5Size, pAcorn6Size,
                    pAcorn7Size, pAcorn8Size, pAcorn9Size, pAcorn10Size, pAcorn11Size, pAcorn12Size;
    //Button variables
    private bool buttonPresses, optionsBP, shopBP, playBP, backBP, acornBP;
    private int shopBPNum, optionsBPNum, backBPNum, acornBPNum;

	void Start()
    {
        GameState.Instance.gesturesTrans.GetComponent<ScreenRaycaster>().Cameras[0] = Camera.main.camera;
        //Intialise acorn button variables
        pAcorn1Size = pAcornSize; pAcorn2Size = pAcornSize; pAcorn3Size = pAcornSize; pAcorn4Size = pAcornSize; pAcorn5Size = pAcornSize; pAcorn6Size = pAcornSize;
        pAcorn7Size = pAcornSize; pAcorn8Size = pAcornSize; pAcorn9Size = pAcornSize; pAcorn10Size = pAcornSize; pAcorn11Size = pAcornSize; pAcorn12Size = pAcornSize;
        logoTimer = new Timer();        
        logoTimer.setTimer(3);
        logoTimer.startTimer();
        currentTreeSelected = 1;
        Time.timeScale = 1.0f;
    }
    void Update()
	{   
        logoTimer.UpdateTimer();
        timeCheck = logoTimer.checkTimer();
        if (timeCheck)
        {
            GameState.Instance.logoTimed = false;
        }
        //if a buton is pressed
        if (buttonPresses)
        {
            //and if the enlarge timer has finished
            if (Utility.Instance.CheckEnlargeTimer() == true)
            {
                //if the button was the options button
                if (optionsBP)
                {
                    Debug.Log("Touched: options");
                    //set options menu to true
                    GameState.Instance.optionsMenu = true;
                    if (optionsBPNum == 1)
                    {                  
                        OptionsUI.Instance.optionsScreenPick = 1;
                        //resize and scale the button to original values
                        mmOptionsSize = Utility.Instance.ResetButtonScale();
                        mmOptionsPos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (optionsBPNum == 2)
                    {
                        OptionsUI.Instance.optionsScreenPick = 2;
                        GameState.Instance.treeSelectMenu = false;
                        //resize and scale the button to original values
                        OptionsUI.Instance.optionsButtonSize = Utility.Instance.ResetButtonScale();
                        OptionsUI.Instance.optionsButtonPos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (optionsBPNum == 3)
                    {
                        OptionsUI.Instance.optionsScreenPick = 2;
                        GameState.Instance.puzzleSelectMenu = false;
                        //resize and scale the button to original values
                        OptionsUI.Instance.optionsButtonSize = Utility.Instance.ResetButtonScale();
                        OptionsUI.Instance.optionsButtonPos = Utility.Instance.ResetButtonPosition();
                    }                
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    optionsBP = false;
                    buttonPresses = false;
                }
                //if the button was the shop button
                if (shopBP)
                {
                    Debug.Log("Touched: shop");
                    //set shop menu to true
                    GameState.Instance.shopMenu = true;
                    if (shopBPNum == 1)
                    {
                        ShopUI.Instance.shopScreenPick = 1;
                        //resize and scale the button to original values
                        mmShopSize = Utility.Instance.ResetButtonScale();
                        mmShopPos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (shopBPNum == 2)
                    {
                        ShopUI.Instance.shopScreenPick = 2;
                        GameState.Instance.treeSelectMenu = false;
                        //resize and scale the button to original values
                        ShopUI.Instance.shopButtonSize = Utility.Instance.ResetButtonScale();
                        ShopUI.Instance.shopButtonPos = Utility.Instance.ResetButtonPosition();
                    }
                    else if(shopBPNum == 3)
                    {
                        ShopUI.Instance.shopScreenPick = 3;
                        GameState.Instance.puzzleSelectMenu = false;
                        //resize and scale the button to original values
                        ShopUI.Instance.shopButtonSize = Utility.Instance.ResetButtonScale();
                        ShopUI.Instance.shopButtonPos = Utility.Instance.ResetButtonPosition();
                    }
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    shopBP = false;
                    buttonPresses = false;
                }
                //if the button was the play button
                if (playBP)
                {
                    Debug.Log("Touched: play");
                    if (GameState.Instance.firstPlay == false)
                    {
                        GameState.Instance.startScene(GameState.Instance.currentTree.puzzle1.name);
                        GameState.Instance.firstPlay = true;
                        GameState.Instance.saveData.SaveFirstPlay(GameState.Instance.firstPlay);
                        //reset the Enlarge Timer
                        Utility.Instance.ResetEnlargeTimer();
                        playButtonSize = Utility.Instance.ResetButtonScale();
                        playButtonPos = Utility.Instance.ResetButtonPosition();
                        //reset the button presses
                        playBP = false;
                        buttonPresses = false;                        
                    }
                    else
                    {
                        GameState.Instance.treeSelectMenu = true;
                        //reset the Enlarge Timer
                        Utility.Instance.ResetEnlargeTimer();
                        //resize and scale the button to original values
                        playButtonSize = Utility.Instance.ResetButtonScale();
                        playButtonPos = Utility.Instance.ResetButtonPosition();
                        //reset the button presses
                        playBP = false;
                        buttonPresses = false;
                    }
                }
                if (backBP)
                {
                    if(backBPNum == 1)
                    {
                        GameState.Instance.treeSelectMenu = false;                        
                    }
                    else if(backBPNum == 2)
                    {
                        GameState.Instance.puzzleSelectMenu = false;
                        GameState.Instance.treeSelectMenu = true;
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
                if(acornBP)
                {
                    if(acornBPNum == 1)
                    {
                        if (GameState.Instance.currentTree.puzzle1.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 1;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle1.name);
                        }
                        pAcorn1Size = Utility.Instance.ResetButtonScale();
                        pAcorn1Pos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (acornBPNum == 2)
                    {
                        if (GameState.Instance.currentTree.puzzle2.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 2;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle2.name);
                        }
                        pAcorn2Size = Utility.Instance.ResetButtonScale();
                        pAcorn2Pos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (acornBPNum == 3)
                    {
                        if (GameState.Instance.currentTree.puzzle3.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 3;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle3.name);
                        }
                        pAcorn3Size = Utility.Instance.ResetButtonScale();
                        pAcorn3Pos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (acornBPNum == 4)
                    {
                        if (GameState.Instance.currentTree.puzzle4.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 4;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle4.name);
                        }
                        pAcorn4Size = Utility.Instance.ResetButtonScale();
                        pAcorn4Pos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (acornBPNum == 5)
                    {
                        if (GameState.Instance.currentTree.puzzle5.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 5;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle5.name);
                        }
                        pAcorn5Size = Utility.Instance.ResetButtonScale();
                        pAcorn5Pos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (acornBPNum == 6)
                    {
                        if (GameState.Instance.currentTree.puzzle6.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 6;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle6.name);
                        }
                        pAcorn6Size = Utility.Instance.ResetButtonScale();
                        pAcorn6Pos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (acornBPNum == 7)
                    {
                        if (GameState.Instance.currentTree.puzzle7.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 7;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle7.name);
                        }
                        pAcorn7Size = Utility.Instance.ResetButtonScale();
                        pAcorn7Pos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (acornBPNum == 8)
                    {
                        if (GameState.Instance.currentTree.puzzle8.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 8;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle8.name);
                        }
                        pAcorn8Size = Utility.Instance.ResetButtonScale();
                        pAcorn8Pos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (acornBPNum == 9)
                    {
                        if (GameState.Instance.currentTree.puzzle9.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 9;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle9.name);
                        }
                        pAcorn9Size = Utility.Instance.ResetButtonScale();
                        pAcorn9Pos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (acornBPNum == 10)
                    {
                        if (GameState.Instance.currentTree.puzzle10.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 10;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle10.name);
                        }
                        pAcorn10Size = Utility.Instance.ResetButtonScale();
                        pAcorn10Pos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (acornBPNum == 11)
                    {
                        if (GameState.Instance.currentTree.puzzle11.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 11;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle11.name);
                        }
                        pAcorn11Size = Utility.Instance.ResetButtonScale();
                        pAcorn11Pos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (acornBPNum == 12)
                    {
                        if (GameState.Instance.currentTree.puzzle12.GetComponent<Puzzle>().locked == false)
                        {
                            GameState.Instance.currentPuzzleno = 12;
                            GameState.Instance.startScene(GameState.Instance.currentTree.puzzle12.name);
                        }
                        pAcorn12Size = Utility.Instance.ResetButtonScale();
                        pAcorn12Pos = Utility.Instance.ResetButtonPosition();
                    }
                    acornBP = false;
                    buttonPresses = false;
                }
            }
        }    
    }    

    void OnGUI()
    {
        GameState.Instance.baseSkin = GUI.skin;
        GUI.skin = GameState.Instance.customSkin;
        //Scale UI based on original resolution
        scale.x = Screen.width / originalWidth; // calculate hor scale
        scale.y = Screen.height / originalHeight; // calculate vert scale
        scale.z = 1;
        Matrix4x4 svMat = GUI.matrix;
        // substitute matrix - only scale is altered from standard
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
                
        if (GameState.Instance.logoTimed == true)
        {
            GUI.DrawTexture(new Rect(adgLogoPos.x, adgLogoPos.y, adgLogoSize.x, adgLogoSize.y), ADGLogo, ScaleMode.StretchToFill, true, 0);
            GUI.color = Color.black;
            GUI.Label(new Rect(adgFooterPos.x, adgFooterPos.y, adgFooterSize.x, adgFooterSize.y), adgFooter);
            GUI.DrawTexture(new Rect(copyRightPos.x, copyRightPos.y, copyRightSize.x, copyRightSize.y), copyRight, ScaleMode.StretchToFill, true, 0);
            GUI.Label(new Rect(adgARRPos.x, adgARRPos.y, adgARRSize.x, adgARRSize.y), adgARR);
            GUI.color = Color.white;
        }
        else
        {
            //background texture
            GUI.DrawTexture(new Rect(backgroundScreenPos.x, backgroundScreenPos.y, backgroundScreenSize.x, backgroundScreenSize.y), backgroundScreen, ScaleMode.StretchToFill, true, 0);
            if (GameState.Instance.puzzleSelectMenu == true)
            {
                //top banner
                GUI.DrawTexture(new Rect(topBannerPos.x, topBannerPos.y, topBannerSize.x, topBannerSize.y), banner, ScaleMode.StretchToFill, true, 0);
                //bottom banner
                GUI.DrawTexture(new Rect(bottomBannerPos.x, bottomBannerPos.y, bottomBannerSize.x, bottomBannerSize.y), banner, ScaleMode.StretchToFill, true, 0);

                //Puzzle 1 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle1.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn1Pos.x, pAcorn1Pos.y, pAcorn1Size.x, pAcorn1Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn1Size = Utility.Instance.EnlargeButtonScale(pAcorn1Size);
                        pAcorn1Pos = Utility.Instance.EnlargeButtonPosition(pAcorn1Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 1;
                        buttonPresses = true;
                        acornBP = true;
                    }                    
                }
                //Puzzle 2 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle2.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn2Pos.x, pAcorn2Pos.y, pAcorn2Size.x, pAcorn2Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn2Size = Utility.Instance.EnlargeButtonScale(pAcorn2Size);
                        pAcorn2Pos = Utility.Instance.EnlargeButtonPosition(pAcorn2Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 2;
                        buttonPresses = true;
                        acornBP = true;
                    }                    
                }
                //Puzzle 3 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle3.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn3Pos.x, pAcorn3Pos.y, pAcorn3Size.x, pAcorn3Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn3Size = Utility.Instance.EnlargeButtonScale(pAcorn3Size);
                        pAcorn3Pos = Utility.Instance.EnlargeButtonPosition(pAcorn3Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 3;
                        buttonPresses = true;
                        acornBP = true;
                    }                    
                }
                //Puzzle 4 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle4.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn4Pos.x, pAcorn4Pos.y, pAcorn4Size.x, pAcorn4Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn4Size = Utility.Instance.EnlargeButtonScale(pAcorn4Size);
                        pAcorn4Pos = Utility.Instance.EnlargeButtonPosition(pAcorn4Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 4;
                        buttonPresses = true;
                        acornBP = true;
                    }                     
                }
                //Puzzle 5 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle5.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn5Pos.x, pAcorn5Pos.y, pAcorn5Size.x, pAcorn5Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn5Size = Utility.Instance.EnlargeButtonScale(pAcorn5Size);
                        pAcorn5Pos = Utility.Instance.EnlargeButtonPosition(pAcorn5Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 5;
                        buttonPresses = true;
                        acornBP = true;
                    }                     
                }
                //Puzzle 6 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle6.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn6Pos.x, pAcorn6Pos.y, pAcorn6Size.x, pAcorn6Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn6Size = Utility.Instance.EnlargeButtonScale(pAcorn6Size);
                        pAcorn6Pos = Utility.Instance.EnlargeButtonPosition(pAcorn6Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 6;
                        buttonPresses = true;
                        acornBP = true;
                    }                     
                }
                //Puzzle 7 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle7.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn7Pos.x, pAcorn7Pos.y, pAcorn7Size.x, pAcorn7Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn7Size = Utility.Instance.EnlargeButtonScale(pAcorn7Size);
                        pAcorn7Pos = Utility.Instance.EnlargeButtonPosition(pAcorn7Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 7;
                        buttonPresses = true;
                        acornBP = true;
                    }                     
                }
                //Puzzle 8 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle8.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn8Pos.x, pAcorn8Pos.y, pAcorn8Size.x, pAcorn8Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn8Size = Utility.Instance.EnlargeButtonScale(pAcorn8Size);
                        pAcorn8Pos = Utility.Instance.EnlargeButtonPosition(pAcorn8Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 8;
                        buttonPresses = true;
                        acornBP = true;
                    }                   
                }
                //Puzzle 9 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle9.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn9Pos.x, pAcorn9Pos.y, pAcorn9Size.x, pAcorn9Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn9Size = Utility.Instance.EnlargeButtonScale(pAcorn9Size);
                        pAcorn9Pos = Utility.Instance.EnlargeButtonPosition(pAcorn9Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 9;
                        buttonPresses = true;
                        acornBP = true;
                    }                    
                }
                //Puzzle 10 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle10.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn10Pos.x, pAcorn10Pos.y, pAcorn10Size.x, pAcorn10Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn10Size = Utility.Instance.EnlargeButtonScale(pAcorn10Size);
                        pAcorn10Pos = Utility.Instance.EnlargeButtonPosition(pAcorn10Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 10;
                        buttonPresses = true;
                        acornBP = true;
                    }                     
                }
                //Puzzle 11 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle11.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn11Pos.x, pAcorn11Pos.y, pAcorn11Size.x, pAcorn11Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn11Size = Utility.Instance.EnlargeButtonScale(pAcorn11Size);
                        pAcorn11Pos = Utility.Instance.EnlargeButtonPosition(pAcorn11Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 11;
                        buttonPresses = true;
                        acornBP = true;
                    }                     
                }
                //Puzzle 12 button
                ChooseAcornColour(GameState.Instance.currentTree.puzzle12.GetComponent<Puzzle>());
                if (GUI.Button(new Rect(pAcorn12Pos.x, pAcorn12Pos.y, pAcorn12Size.x, pAcorn12Size.y), acornChoice, "label"))
                {
                    if (buttonPresses == false)
                    {
                        pAcorn12Size = Utility.Instance.EnlargeButtonScale(pAcorn12Size);
                        pAcorn12Pos = Utility.Instance.EnlargeButtonPosition(pAcorn12Pos);
                        Utility.Instance.StartEnlargeTimer();
                        acornBPNum = 12;
                        buttonPresses = true;
                        acornBP = true;
                    }                     
                }
                GUI.Label(new Rect(pAcorn1Pos.x + acornNoOffset.x, pAcorn1Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "1");
                GUI.Label(new Rect(pAcorn2Pos.x + acornNoOffset.x, pAcorn2Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "2");
                GUI.Label(new Rect(pAcorn3Pos.x + acornNoOffset.x, pAcorn3Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "3");
                GUI.Label(new Rect(pAcorn4Pos.x + acornNoOffset.x, pAcorn4Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "4");
                GUI.Label(new Rect(pAcorn5Pos.x + acornNoOffset.x, pAcorn5Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "5");
                GUI.Label(new Rect(pAcorn6Pos.x + acornNoOffset.x, pAcorn6Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "6");
                GUI.Label(new Rect(pAcorn7Pos.x + acornNoOffset.x, pAcorn7Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "7");
                GUI.Label(new Rect(pAcorn8Pos.x + acornNoOffset.x, pAcorn8Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "8");
                GUI.Label(new Rect(pAcorn9Pos.x + acornNoOffset.x, pAcorn9Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "9");
                GUI.Label(new Rect(pAcorn10Pos.x + acornNoOffset.x, pAcorn10Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "10");
                GUI.Label(new Rect(pAcorn11Pos.x + acornNoOffset.x, pAcorn11Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "11");
                GUI.Label(new Rect(pAcorn12Pos.x + acornNoOffset.x, pAcorn12Pos.y + acornNoOffset.y, acornNoSize.x, acornNoSize.y), "12");
                //back button
                if (GUI.Button(new Rect(backButtonPos.x, backButtonPos.y, backButtonSize.x, backButtonSize.y), backButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        backButtonSize = Utility.Instance.EnlargeButtonScale(backButtonSize);
                        backButtonPos = Utility.Instance.EnlargeButtonPosition(backButtonPos);
                        Utility.Instance.StartEnlargeTimer();
                        backBPNum = 2;
                        buttonPresses = true;
                        backBP = true;
                    }
                }
                //Options button
                if (GUI.Button(new Rect(OptionsUI.Instance.optionsButtonPos.x, OptionsUI.Instance.optionsButtonPos.y, OptionsUI.Instance.optionsButtonSize.x, OptionsUI.Instance.optionsButtonSize.y), OptionsUI.Instance.optionsButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        OptionsUI.Instance.optionsButtonSize = Utility.Instance.EnlargeButtonScale(OptionsUI.Instance.optionsButtonSize);
                        OptionsUI.Instance.optionsButtonPos = Utility.Instance.EnlargeButtonPosition(OptionsUI.Instance.optionsButtonPos);
                        Utility.Instance.StartEnlargeTimer();
                        optionsBPNum = 3;
                        buttonPresses = true;
                        optionsBP = true;
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
                        shopBPNum = 3;
                        buttonPresses = true;
                        shopBP = true;
                    }
                }
            }
            else if (GameState.Instance.treeSelectMenu == true)
            {
                //top banner
                GUI.DrawTexture(new Rect(topBannerPos.x, topBannerPos.y, topBannerSize.x, topBannerSize.y), banner, ScaleMode.StretchToFill, true, 0);
                //bottom banner
                GUI.DrawTexture(new Rect(bottomBannerPos.x, bottomBannerPos.y, bottomBannerSize.x, bottomBannerSize.y), banner, ScaleMode.StretchToFill, true, 0);
				//Start looking for swipes
				/*
                 * TREE CAROUSEL START
                 */
                if (currentTreeSelected - 1 < 1)
                {
                    //carouselLeftTree = GameState.Instance.maxTrees;
					carouselLeftTree = 0;
                }
                else
                {
                    carouselLeftTree = currentTreeSelected - 1;
                }

                if (currentTreeSelected + 1 > GameState.Instance.maxTrees)
                {
                    //carouselRightTree = 1;
					carouselRightTree = 0;
                }
                else
                {
                    carouselRightTree = currentTreeSelected + 1;
                }

                // CAROUSEL LEFT 
                if (carouselLeftTree == 1)
                {
                    //Tree 1 button
					if (GUI.Button(new Rect(carouselLeftPos.x, carouselLeftPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.tree1.treeButton, "label") ||  MyTouchLogic.mytouchlogic.swipeRight)
					{
						Debug.Log("Touched: Tree 1");
                        currentTreeSelected = 1;
						MyTouchLogic.mytouchlogic.swipeRight = false;
                    }
                }
                else if (carouselLeftTree == 2)
                {
                    //Tree 2 button
					if (GUI.Button(new Rect(carouselLeftPos.x, carouselLeftPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.tree2.treeButton, "label") || MyTouchLogic.mytouchlogic.swipeRight)
					{
						Debug.Log("Touched: Tree 2");
                        currentTreeSelected = 2;
						MyTouchLogic.mytouchlogic.swipeRight = false;
                    }
                }
                else if (carouselLeftTree == 3)
                {
                    //Tree 3 button
					if (GUI.Button(new Rect(carouselLeftPos.x, carouselLeftPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.tree3.treeButton, "label") || MyTouchLogic.mytouchlogic.swipeRight)
                    {
                        Debug.Log("Touched: Tree 3");
                        currentTreeSelected = 3;
						MyTouchLogic.mytouchlogic.swipeRight = false;
                    }
                }
                else if (carouselLeftTree == 4)
                {
                    //Tree 4 button
					if (GUI.Button(new Rect(carouselLeftPos.x, carouselLeftPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.tree4.treeButton, "label") || MyTouchLogic.mytouchlogic.swipeRight)
					{
						Debug.Log("Touched: Tree 4");
                        currentTreeSelected = 4;
						MyTouchLogic.mytouchlogic.swipeRight = false;
                    }
                }
                else if (carouselLeftTree == 5)
                {
                    //Tree 5 button
					if (GUI.Button(new Rect(carouselLeftPos.x, carouselLeftPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.tree5.treeButton, "label") || MyTouchLogic.mytouchlogic.swipeRight)
					{
						Debug.Log("Touched: Tree 5");
                        currentTreeSelected = 5;
						MyTouchLogic.mytouchlogic.swipeRight = false;
                    }
                }
                // CAROUSEL Right
                if (carouselRightTree == 1)
                {
                    //Tree 1 button
					if (GUI.Button(new Rect(carouselRightPos.x, carouselRightPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.tree1.treeButton, "label") || MyTouchLogic.mytouchlogic.swipeLeft)
					{
						Debug.Log("Touched: Tree 1");
                        currentTreeSelected = 1;
						MyTouchLogic.mytouchlogic.swipeLeft = false;
                    }
                }
                else if (carouselRightTree == 2)
                {
                    //Tree 2 button
					if (GUI.Button(new Rect(carouselRightPos.x, carouselRightPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.tree2.treeButton, "label") || MyTouchLogic.mytouchlogic.swipeLeft)
					{
						Debug.Log("Touched: Tree 2");
                        currentTreeSelected = 2;
						MyTouchLogic.mytouchlogic.swipeLeft = false;
                    }
                }
                else if (carouselRightTree == 3)
                {
                    //Tree 3 button
					if (GUI.Button(new Rect(carouselRightPos.x, carouselRightPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.tree3.treeButton, "label") || MyTouchLogic.mytouchlogic.swipeLeft)
					{
						Debug.Log("Touched: Tree 3");
                        currentTreeSelected = 3;
						MyTouchLogic.mytouchlogic.swipeLeft = false;
                    }
                }
                else if (carouselRightTree == 4)
                {
                    //Tree 4 button
					if (GUI.Button(new Rect(carouselRightPos.x, carouselRightPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.tree4.treeButton, "label") || MyTouchLogic.mytouchlogic.swipeLeft)
					{
						Debug.Log("Touched: Tree 4");
                        currentTreeSelected = 4;
						MyTouchLogic.mytouchlogic.swipeLeft = false;
                    }
                }
                else if (carouselRightTree == 5)
                {
                    //Tree 5 button
					if (GUI.Button(new Rect(carouselRightPos.x, carouselRightPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.tree5.treeButton, "label") || MyTouchLogic.mytouchlogic.swipeLeft)
					{
						Debug.Log("Touched: Tree 5");
                        currentTreeSelected = 5;
						MyTouchLogic.mytouchlogic.swipeLeft = false;
                    }
                }

                GameState.Instance.currentTreeno = currentTreeSelected;
                // CAROUSEL MIDDLE
                if (currentTreeSelected == 1)
                {
                    //Tree 1 button
                    if (GUI.Button(new Rect(carouselMiddlePos.x, carouselMiddlePos.y, carouselButtonSizeLarge.x, carouselButtonSizeLarge.y), GameState.Instance.tree1.treeButton, "label"))
                    {
                        Debug.Log("Touched: Tree 1");
                        GameState.Instance.treeSelectMenu = false;
                        GameState.Instance.puzzleSelectMenu = true;
                    }
                }
                else if (currentTreeSelected == 2)
                {
                    //Tree 2 button
                    if (GUI.Button(new Rect(carouselMiddlePos.x, carouselMiddlePos.y, carouselButtonSizeLarge.x, carouselButtonSizeLarge.y), GameState.Instance.tree2.treeButton, "label"))
                    {
                        Debug.Log("Touched: Tree 2");
                        GameState.Instance.treeSelectMenu = false;
                        GameState.Instance.puzzleSelectMenu = true;
                    }
                }
                else if (currentTreeSelected == 3)
                {
                    //Tree 3 button
                    if (GUI.Button(new Rect(carouselMiddlePos.x, carouselMiddlePos.y, carouselButtonSizeLarge.x, carouselButtonSizeLarge.y), GameState.Instance.tree3.treeButton, "label"))
                    {
                        Debug.Log("Touched: Tree 3");
                        GameState.Instance.treeSelectMenu = false;
                        GameState.Instance.puzzleSelectMenu = true;
                    }
                }
                else if (currentTreeSelected == 4)
                {
                    //Tree 4 button
                    if (GUI.Button(new Rect(carouselMiddlePos.x, carouselMiddlePos.y, carouselButtonSizeLarge.x, carouselButtonSizeLarge.y), GameState.Instance.tree4.treeButton, "label"))
                    {
                        Debug.Log("Touched: Tree 4");
                        GameState.Instance.treeSelectMenu = false;
                        GameState.Instance.puzzleSelectMenu = true;
                    }
                }
                else if (currentTreeSelected == 5)
                {
                    //Tree 5 button
                    if (GUI.Button(new Rect(carouselMiddlePos.x, carouselMiddlePos.y, carouselButtonSizeLarge.x, carouselButtonSizeLarge.y), GameState.Instance.tree5.treeButton, "label"))
                    {
                        Debug.Log("Touched: Tree 5");
                        GameState.Instance.treeSelectMenu = false;
                        GameState.Instance.puzzleSelectMenu = true;
                    }
                }

                /*
                * TREE CAROUSEL END
                */

                //Bronze Acorn
                GUI.DrawTexture(new Rect(bronzeAcornPos.x, bronzeAcornPos.y, acornSize.x, acornSize.y), bronzeAcorn, ScaleMode.StretchToFill, true, 0);
                //Silver Acorn
                GUI.DrawTexture(new Rect(silverAcornPos.x, silverAcornPos.y, acornSize.x, acornSize.y), silverAcorn, ScaleMode.StretchToFill, true, 0);
                //Gold Acorn
                GUI.DrawTexture(new Rect(goldAcornPos.x, goldAcornPos.y, acornSize.x, acornSize.y), goldAcorn, ScaleMode.StretchToFill, true, 0);

                GUI.Label(new Rect(bronzeAcornTextPos.x, bronzeAcornTextPos.y, acornTextSize.x, acornTextSize.y), "X");
                GUI.Label(new Rect(silverAcornTextPos.x, silverAcornTextPos.y, acornTextSize.x, acornTextSize.y), "X");
                GUI.Label(new Rect(goldAcornTextPos.x, goldAcornTextPos.y, acornTextSize.x, acornTextSize.y), "X");
                GUI.Label(new Rect(bronzeAcornTextPos.x + 15, bronzeAcornTextPos.y, acornTextSize.x, acornTextSize.y), GameState.Instance.currentTree.noOfBronze.ToString());
                GUI.Label(new Rect(silverAcornTextPos.x + 15, silverAcornTextPos.y, acornTextSize.x, acornTextSize.y), GameState.Instance.currentTree.noOfSilver.ToString());
                GUI.Label(new Rect(goldAcornTextPos.x + 15, goldAcornTextPos.y, acornTextSize.x, acornTextSize.y), GameState.Instance.currentTree.noOfGold.ToString());

                //back button
                if (GUI.Button(new Rect(backButtonPos.x, backButtonPos.y, backButtonSize.x, backButtonSize.y), backButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        backButtonSize = Utility.Instance.EnlargeButtonScale(backButtonSize);
                        backButtonPos = Utility.Instance.EnlargeButtonPosition(backButtonPos);
                        Utility.Instance.StartEnlargeTimer();
                        backBPNum = 1;
                        buttonPresses = true;
                        backBP = true;
                    }                    
                }
                //Options button
                if (GUI.Button(new Rect(OptionsUI.Instance.optionsButtonPos.x, OptionsUI.Instance.optionsButtonPos.y, OptionsUI.Instance.optionsButtonSize.x, OptionsUI.Instance.optionsButtonSize.y), OptionsUI.Instance.optionsButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        OptionsUI.Instance.optionsButtonSize = Utility.Instance.EnlargeButtonScale(OptionsUI.Instance.optionsButtonSize);
                        OptionsUI.Instance.optionsButtonPos = Utility.Instance.EnlargeButtonPosition(OptionsUI.Instance.optionsButtonPos);
                        Utility.Instance.StartEnlargeTimer();
                        optionsBPNum = 2;
                        buttonPresses = true;
                        optionsBP = true;
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
                        shopBPNum = 2;
                        buttonPresses = true;
                        shopBP = true;
                    }              
                }
            }
            else if (GameState.Instance.optionsMenu == false && GameState.Instance.shopMenu == false)
            {
                //logo texture
                GUI.DrawTexture(new Rect(mmLogoPos.x, mmLogoPos.y, mmLogoSize.x, mmLogoSize.y), mmLogoScreen, ScaleMode.StretchToFill, true, 0);
                //squirrel image texture
                GUI.DrawTexture(new Rect(mmSquirrelPos.x, mmSquirrelPos.y, mmSquirrelSize.x, mmSquirrelSize.y), mmSquirrelScreen, ScaleMode.StretchToFill, true, 0);
                //bottom banner
                GUI.DrawTexture(new Rect(mmBottomBannerPos.x, mmBottomBannerPos.y, mmBottomBannerSize.x, mmBottomBannerSize.y), banner, ScaleMode.StretchToFill, true, 0);

                //play button
                if (GUI.Button(new Rect(playButtonPos.x, playButtonPos.y, playButtonSize.x, playButtonSize.y), playButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        playButtonSize = Utility.Instance.EnlargeButtonScale(playButtonSize);
                        playButtonPos = Utility.Instance.EnlargeButtonPosition(playButtonPos);
                        Utility.Instance.StartEnlargeTimer();
                        buttonPresses = true;
                        playBP = true;                        
                    }
                }
                //Options button
                if (GUI.Button(new Rect(mmOptionsPos.x, mmOptionsPos.y, mmOptionsSize.x, mmOptionsSize.y), OptionsUI.Instance.optionsButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        mmOptionsSize = Utility.Instance.EnlargeButtonScale(mmOptionsSize);
                        mmOptionsPos = Utility.Instance.EnlargeButtonPosition(mmOptionsPos);
                        Utility.Instance.StartEnlargeTimer();
                        optionsBPNum = 1;
                        buttonPresses = true;
                        optionsBP = true;
                    }
                }
                //Shop button
                if (GUI.Button(new Rect(mmShopPos.x, mmShopPos.y, mmShopSize.x, mmShopSize.y), ShopUI.Instance.shopButton, "label"))
                {
                    if(buttonPresses == false)
                    {
                        mmShopSize = Utility.Instance.EnlargeButtonScale(mmShopSize);
                        mmShopPos = Utility.Instance.EnlargeButtonPosition(mmShopPos);
                        Utility.Instance.StartEnlargeTimer();
                        shopBPNum = 1;
                        buttonPresses = true;
                        shopBP = true;
                    }
                }
            }
        }
        // restore matrix before returning
        GUI.matrix = svMat; // restore matrix    
    }

    void ChooseAcornColour(Puzzle puzzle)
    {
        if(puzzle.gold == true)
        {
            acornChoice = goldAcorn;
        }
        else if(puzzle.silver == true)
        {
            acornChoice = silverAcorn;
        }
        else if (puzzle.bronze == true)
        {
            acornChoice = bronzeAcorn;
        }
        else if(puzzle.unlockNo > GameState.Instance.puzzlesCompleted)
        {
            acornChoice = lockedAcorn;
            puzzle.locked = true;
        }
        else
        {
            acornChoice = blueAcorn;
            puzzle.locked = false;
        }
    }
}

