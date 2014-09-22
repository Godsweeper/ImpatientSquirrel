using UnityEngine;
using System.Collections;

public class PuzzleUI : MonoSingleton<PuzzleUI> 
{
    public Vector2 gameTimePos, gameTimeSize;
    public Texture pauseButton;
    public Vector2 pausePos, pauseSize;
    public Texture backgroundScreen;
    public Vector2 backgroundScreenPos, backgroundScreenSize;
    public Texture squirrelHeadLoose;
    public Vector2 squirrelHeadPos, squirrelHeadSize;
    public string tryAgainCaption;
    public Vector2 tryAgainPos, tryAgainSize;
    public Texture unPauseButton;
    public Vector2 unPausePos, unPauseSize;
    public Texture shopButton;
    public Vector2 shopPos, shopSize;
    public Texture replayButton;
    public Vector2 replayPos, replaySize, successReplayPos, successReplaySize, looseReplayPos, looseReplaySize;
    public Texture nextButton;
    public Vector2 nextPos, nextSize, successNextPos, successNextSize;
    public Texture homeButton;
    public Vector2 homePos, homeSize;

    public Texture starburst;
    public Vector2 starburstPos, starburstSize;
    public Texture banner;
    public Vector2 bannerPos, bannerSize;
    public Vector2 topBannerPos, topBannerSize;

    public Texture goldAcorn, silverAcorn, bronzeAcorn;
    public Vector2 successAcornPos, successAcornSize;
    public Vector2 nextUpAcornPos, nextUpAcornSize;
    public string  nextAcornTimeCaption;
    public Vector2 successTimePos, successTimeSize;
    public Vector2 nextAcornTimePos, nextAcornTimeSize;
    public Vector2 nextAcornPos, nextAcornSize;

    public Texture rewindNut, slowTimeNut, crystalNut;
    public Vector2 rewindNutPos, slowTimeNutPos, crystalNutPos, nutUISize;

    public Texture countdown1, countdown2, countdown3, countdownGo;
    public Vector2 countdownNoPos, countdownNoSize, countdownGoPos, countdownGoSize;

    public Vector2 tutorialExitPos, tutorialExitSize;
    public Texture2D exitButton;
    public Vector2 tutorialImagePos, tutorialImageSize;
    public Timer tutorialTimer;
    public bool tutorialStarted, timeCheck, currentTutorialScreen;

    private float originalWidth = 1366;
    private float originalHeight = 768;
    private Vector3 scale;

    //Button variables
    private bool buttonPresses, pauseBP, rewindNutBP, slowTimeNutBP, crystalNutBP, unpauseBP, 
                 mainMenuBP, shopBP, nextBP, replayBP, tutorialExitBP;
    private int shopBPNum, menuBPNum, replayBPNum;
    private Vector2 rewindNutSize, slowTimeNutSize, crystalNutSize;

    void Awake()
    {
        GameState.Instance.gesturesTrans.GetComponent<ScreenRaycaster>().Cameras[0] = Camera.main.camera;
        rewindNutSize = nutUISize;
        slowTimeNutSize = nutUISize;
        crystalNutSize = nutUISize;
        Time.timeScale = 1.0f;
        //Time.fixedDeltaTime = 0.02F * Time.timeScale;
        GameManager.Instance.tutorialFinished = false;
        tutorialTimer = new Timer();
        tutorialTimer.setTimer(1);
		//mytouchlogic = GameObject.Find("Gestures").GetComponent<MyTouchLogic>();

    }

    void Update()
    {
        //if a buton is pressed
        if (buttonPresses)
        {
            //and if the enlarge timer has finished
            if (Utility.Instance.CheckEnlargeTimer() == true)
            {
                //if the button was the options button
                if (pauseBP)
                {
                    Debug.Log("Touched: pause");
                    if (GameManager.Instance.paused == false)
                    {
                        GameManager.Instance.paused = true;
                        GameState.Instance.pausedMenu = true;
                    }
                    //resize and scale the button to original values
                    pauseSize = Utility.Instance.ResetButtonScale();
                    pausePos = Utility.Instance.ResetButtonPosition();
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    pauseBP = false;
                    buttonPresses = false;
                }
                if(rewindNutBP)
                {
                    Debug.Log("Touched: Rewin Nut");
                    // GameState.Instance.playerInventory.rewindNut.NutEffect();

                    //resize and scale the button to original values
                    rewindNutSize = Utility.Instance.ResetButtonScale();
                    rewindNutPos = Utility.Instance.ResetButtonPosition();
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    rewindNutBP = false;
                    buttonPresses = false;
                }
                if(slowTimeNutBP)
                {
                    Debug.Log("Touched: Slow Time");
                    GameState.Instance.playerInventory.slowTimeNut.NutEffect();

                    //resize and scale the button to original values
                    slowTimeNutSize = Utility.Instance.ResetButtonScale();
                    slowTimeNutPos = Utility.Instance.ResetButtonPosition();
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    slowTimeNutBP = false;
                    buttonPresses = false;
                }
                if (crystalNutBP)
                {
                    Debug.Log("Touched: Crsyatl Nut");
                    GameState.Instance.playerInventory.crystalNut.NutEffect();

                    //resize and scale the button to original values
                    crystalNutSize = Utility.Instance.ResetButtonScale();
                    crystalNutPos = Utility.Instance.ResetButtonPosition();
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    crystalNutBP = false;
                    buttonPresses = false;
                }
                if (unpauseBP)
                {
                    Debug.Log("Touched: unpause");
                    GameManager.Instance.paused = false;
                    GameManager.Instance.startTime = Time.time - GameManager.Instance.gameTime;
                    //GameManager.Instance.ms = ((Time.time * 1000) - (GameManager.Instance.startTime * 1000)) % 1000;
                    GameState.Instance.pausedMenu = false;

                    //resize and scale the button to original values
                    unPauseSize = Utility.Instance.ResetButtonScale();
                    unPausePos = Utility.Instance.ResetButtonPosition();
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    unpauseBP = false;
                    buttonPresses = false;
                }
                if (mainMenuBP)
                {
                    Debug.Log("Touched: home");
                    if (menuBPNum == 1)
                    {
                        //pause menu home button
                        GameState.Instance.puzzleSelectMenu = false;
                        GameState.Instance.pausedMenu = false;
                        GameManager.Instance.paused = false;
                    }
                    else if(menuBPNum == 2)
                    {
                        //death menu home button
                        GameState.Instance.puzzleSelectMenu = true;
                        GameManager.Instance.gameEnd = false;
                        GameState.Instance.deathMenu = false;
                    }
                    else if(menuBPNum == 3)
                    {
                        GameState.Instance.puzzleSelectMenu = true;
                        GameManager.Instance.gameEnd = false;
                        GameState.Instance.endGameMenu = false;
                    }              
                    GameState.Instance.startMainMenu();

                    //resize and scale the button to original values
                    homeSize = Utility.Instance.ResetButtonScale();
                    homePos = Utility.Instance.ResetButtonPosition();
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    mainMenuBP = false;
                    buttonPresses = false;
                }
                if (shopBP)
                {
                    Debug.Log("Touched: shop");
                    if(shopBPNum == 4)
                    {
                        ShopUI.Instance.shopScreenPick = 4;
                        GameState.Instance.pausedMenu = false;
                    }
                    else if(shopBPNum == 5)
                    {
                        ShopUI.Instance.shopScreenPick = 5;
                        GameState.Instance.endGameMenu = false; 
                    }
                    else if(shopBPNum == 7)
                    {
                        ShopUI.Instance.shopScreenPick = 7;
                        GameState.Instance.deathMenu = false;   
                    }
                    GameState.Instance.shopMenu = true;                  

                    //resize and scale the button to original values
                    ShopUI.Instance.shopButtonSize = Utility.Instance.ResetButtonScale();
                    shopPos = Utility.Instance.ResetButtonPosition();
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    shopBP = false;
                    buttonPresses = false;
                }
                if (nextBP)
                {
                    Debug.Log("Touched: next puzzle");
                    GameManager.Instance.gameEnd = false;
                    GameState.Instance.endGameMenu = false;
                    if ((GameState.Instance.currentPuzzleno + 1) <= GameState.Instance.currentTree.noOfPuzzles)
                    {
                        GameState.Instance.currentPuzzleno++;
                    }
                    else
                    {
                        if ((GameState.Instance.currentTreeno + 1) <= GameState.Instance.maxTrees)
                        {
                            GameState.Instance.currentTreeno++;
                            GameState.Instance.currentPuzzleno = 1;
                        }
                    }
                    GameState.Instance.startScene(GameState.Instance.nextScene);

                    //resize and scale the button to original values
                    successNextSize = Utility.Instance.ResetButtonScale();
                    successNextPos = Utility.Instance.ResetButtonPosition();
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    nextBP = false;
                    buttonPresses = false;
                }
                if(replayBP)
                {
                    Debug.Log("Touched: replay");
                    GameState.Instance.startScene(GameState.Instance.currentScene);  
                    if (replayBPNum == 1)
                    {
                        GameManager.Instance.paused = false;
                        GameState.Instance.pausedMenu = false;
                        //resize and scale the button to original values
                        replaySize = Utility.Instance.ResetButtonScale();
                        replayPos = Utility.Instance.ResetButtonPosition();
                    }
                    else if(replayBPNum == 2)
                    {
                        GameManager.Instance.gameEnd = false;
                        GameState.Instance.deathMenu = false;
                        //resize and scale the button to original values
                        looseReplaySize = Utility.Instance.ResetButtonScale();
                        looseReplayPos = Utility.Instance.ResetButtonPosition();
                    }
                    else if (replayBPNum == 3)
                    {
                        GameManager.Instance.gameEnd = false;
                        GameState.Instance.endGameMenu = false;
                        successReplaySize = Utility.Instance.ResetButtonScale();
                        successReplayPos = Utility.Instance.ResetButtonPosition();
                    }                                 
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    replayBP = false;
                    buttonPresses = false;
                }
                if(tutorialExitBP)
                {
                    GameManager.Instance.tutorialFinished = true;
                    tutorialExitSize = Utility.Instance.ResetButtonScale();
                    tutorialExitPos = Utility.Instance.ResetButtonPosition();
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //reset the button presses
                    tutorialExitBP = false;
                    buttonPresses = false;
                }
            }
        }

    }

    void FixedUpdate()
    {   
        //if timer hits 0
        if (timeCheck && GameManager.Instance.tutorialFinished == false)
        {
            //switch tutorial screens
            if (currentTutorialScreen == false)
            {
                currentTutorialScreen = true;
            }
            else
            {
                currentTutorialScreen = false;
            }
            //reset timer
            tutorialTimer.resetTimer(1);
            timeCheck = false;
        }
        else
        {
            tutorialTimer.UpdateTimer();
            timeCheck = tutorialTimer.checkTimer();
        }
    }

    void OnGUI()
    {
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        GUI.skin = GameState.Instance.customSkin;
        //Scale UI based on original resolution
        scale.x = Screen.width / originalWidth; // calculate hor scale
        scale.y = Screen.height / originalHeight; // calculate vert scale
        scale.z = 1;
        Matrix4x4 svMat = GUI.matrix;
        // substitute matrix - only scale is altered from standard
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
        //GUI.color = Color.gray;
        //GUI.skin.
        GUI.Label(new Rect(gameTimePos.x, gameTimePos.y, gameTimeSize.x, gameTimeSize.y), GameManager.Instance.gameTimeString);
        GUI.color = Color.white;

        if(GameManager.Instance.tutorialFinished == false && GameState.Instance.currentPuzzle.tutorial == true && GameState.Instance.currentPuzzle.completed == false)
        {
            tutorialTimer.startTimer();           
            if(GameState.Instance.currentPuzzle.tutorialScreens == 1)
            {
                GUI.DrawTexture(new Rect(tutorialImagePos.x, tutorialImagePos.y, tutorialImageSize.x, tutorialImageSize.y), GameState.Instance.currentPuzzle.firstTutorialScreen, ScaleMode.StretchToFill, true, 0);
            }
            else
            {
                if (currentTutorialScreen)
                {
                    GUI.DrawTexture(new Rect(tutorialImagePos.x, tutorialImagePos.y, tutorialImageSize.x, tutorialImageSize.y), GameState.Instance.currentPuzzle.firstTutorialScreen, ScaleMode.StretchToFill, true, 0);
                }
                else
                {
                    GUI.DrawTexture(new Rect(tutorialImagePos.x, tutorialImagePos.y, tutorialImageSize.x, tutorialImageSize.y), GameState.Instance.currentPuzzle.secondTutorialScreen, ScaleMode.StretchToFill, true, 0);
                }
            }
            if (GUI.Button(new Rect(tutorialExitPos.x, tutorialExitPos.y, tutorialExitSize.x, tutorialExitSize.y), exitButton, "label"))
            {
                if (buttonPresses == false)
                {
                    tutorialExitSize = Utility.Instance.EnlargeButtonScale(tutorialExitSize);
                    tutorialExitPos = Utility.Instance.EnlargeButtonPosition(tutorialExitPos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    tutorialExitBP = true;
                } 
            } 
        }
        else if(GameManager.Instance.gameStarted == false)
        {
            if (GameManager.Instance.gameStartTimer.checkFullTimerNum() > 1.5f)
            {
                GUI.DrawTexture(new Rect(countdownNoPos.x, countdownNoPos.y, countdownNoSize.x, countdownNoSize.y), countdown3, ScaleMode.StretchToFill, true, 0);
            }
            else if (GameManager.Instance.gameStartTimer.checkFullTimerNum() > 1.0f)
            {
                GUI.DrawTexture(new Rect(countdownNoPos.x, countdownNoPos.y, countdownNoSize.x, countdownNoSize.y), countdown2, ScaleMode.StretchToFill, true, 0);
            }
            else if (GameManager.Instance.gameStartTimer.checkFullTimerNum() > 0.5f)
            {
                GUI.DrawTexture(new Rect(countdownNoPos.x, countdownNoPos.y, countdownNoSize.x, countdownNoSize.y), countdown1, ScaleMode.StretchToFill, true, 0);
            }
            else
            {
                GUI.DrawTexture(new Rect(countdownGoPos.x, countdownGoPos.y, countdownGoSize.x, countdownGoSize.y), countdownGo, ScaleMode.StretchToFill, true, 0);
            }
        }
        else if (GameManager.Instance.gameEnd == true)
        {
            Time.timeScale = 1.0f;
            //background texture
            GUI.DrawTexture(new Rect(backgroundScreenPos.x, backgroundScreenPos.y, backgroundScreenSize.x, backgroundScreenSize.y), backgroundScreen, ScaleMode.StretchToFill, true, 0);
            
            //End game menu
            if (GameState.Instance.endGameMenu == true)
            {
                GUI.DrawTexture(new Rect(bannerPos.x, bannerPos.y, bannerSize.x, bannerSize.y), banner, ScaleMode.StretchToFill, true, 0);
                GUI.DrawTexture(new Rect(topBannerPos.x, topBannerPos.y, topBannerSize.x, topBannerSize.y), banner, ScaleMode.StretchToFill, true, 0);
                //Time.timeScale = 0.0f;
                //starburst
                GUI.DrawTexture(new Rect(starburstPos.x, starburstPos.y, starburstSize.x, starburstSize.y), starburst, ScaleMode.StretchToFill, true, 0);
                if (GameState.Instance.currentPuzzleAcornNo == 1)
                {
                    GUI.DrawTexture(new Rect(successAcornPos.x, successAcornPos.y, successAcornSize.x, successAcornSize.y), goldAcorn, ScaleMode.StretchToFill, true, 0);
                }
                else if (GameState.Instance.currentPuzzleAcornNo == 2)
                {
                    GUI.DrawTexture(new Rect(successAcornPos.x, successAcornPos.y, successAcornSize.x, successAcornSize.y), silverAcorn, ScaleMode.StretchToFill, true, 0);
                    GUI.DrawTexture(new Rect(nextAcornPos.x, nextAcornPos.y, nextAcornSize.x, nextAcornSize.y), goldAcorn, ScaleMode.StretchToFill, true, 0);
                    nextAcornTimeCaption = GameState.Instance.currentPuzzle.goldTime.ToString();
                    GUI.Label(new Rect(nextAcornTimePos.x, nextAcornTimePos.y, nextAcornTimeSize.x, nextAcornTimeSize.y), nextAcornTimeCaption);
                }
                else if (GameState.Instance.currentPuzzleAcornNo == 3)
                {
                    GUI.DrawTexture(new Rect(successAcornPos.x, successAcornPos.y, successAcornSize.x, successAcornSize.y), bronzeAcorn, ScaleMode.StretchToFill, true, 0);
                    GUI.DrawTexture(new Rect(nextAcornPos.x, nextAcornPos.y, nextAcornSize.x, nextAcornSize.y), silverAcorn, ScaleMode.StretchToFill, true, 0);
                    nextAcornTimeCaption = GameState.Instance.currentPuzzle.silverTime.ToString();
                    GUI.Label(new Rect(nextAcornTimePos.x, nextAcornTimePos.y, nextAcornTimeSize.x, nextAcornTimeSize.y), nextAcornTimeCaption);
                }                
                
                GUI.Label(new Rect(successTimePos.x, successTimePos.y, successTimeSize.x, successTimeSize.y), GameManager.Instance.sucessTimeCaption);
                //replay 
                if (GUI.Button(new Rect(successReplayPos.x, successReplayPos.y, successReplaySize.x, successReplaySize.y), replayButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        successReplaySize = Utility.Instance.EnlargeButtonScale(successReplaySize);
                        successReplayPos = Utility.Instance.EnlargeButtonPosition(successReplayPos);
                        Utility.Instance.StartEnlargeTimer();
                        replayBPNum = 3;
                        buttonPresses = true;
                        replayBP = true;
                    }                    
                }

                //next puzzle button
                if (GUI.Button(new Rect(successNextPos.x, successNextPos.y, successNextSize.x, successNextSize.y), nextButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        successNextSize = Utility.Instance.EnlargeButtonScale(successNextSize);
                        successNextPos = Utility.Instance.EnlargeButtonPosition(successNextPos);
                        Utility.Instance.StartEnlargeTimer();
                        buttonPresses = true;
                        nextBP = true;
                    }                    
                }
                //Shop button
                if (GUI.Button(new Rect(shopPos.x, shopPos.y, ShopUI.Instance.shopButtonSize.x, ShopUI.Instance.shopButtonSize.y), ShopUI.Instance.shopButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        ShopUI.Instance.shopButtonSize = Utility.Instance.EnlargeButtonScale(ShopUI.Instance.shopButtonSize);
                        shopPos = Utility.Instance.EnlargeButtonPosition(shopPos);
                        Utility.Instance.StartEnlargeTimer();
                        shopBPNum = 5;
                        buttonPresses = true;
                        shopBP = true;
                    }                    
                }
                //Home Button
                if (GUI.Button(new Rect(homePos.x, homePos.y, homeSize.x, homeSize.y), homeButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        homeSize = Utility.Instance.EnlargeButtonScale(homeSize);
                        homePos = Utility.Instance.EnlargeButtonPosition(homePos);
                        Utility.Instance.StartEnlargeTimer();
                        menuBPNum = 3;
                        buttonPresses = true;
                        mainMenuBP = true;
                    }       
                }
            }

            if (GameState.Instance.deathMenu == true)
            {
                GUI.DrawTexture(new Rect(bannerPos.x, bannerPos.y, bannerSize.x, bannerSize.y), banner, ScaleMode.StretchToFill, true, 0);
                GUI.DrawTexture(new Rect(topBannerPos.x, topBannerPos.y, topBannerSize.x, topBannerSize.y), banner, ScaleMode.StretchToFill, true, 0);
                GUI.DrawTexture(new Rect(squirrelHeadPos.x, squirrelHeadPos.y, squirrelHeadSize.x, squirrelHeadSize.y), squirrelHeadLoose, ScaleMode.StretchToFill, true, 0);
                
                GUI.Label(new Rect(tryAgainPos.x, tryAgainPos.y, tryAgainSize.x, tryAgainSize.y), tryAgainCaption);
                //Shop button
                if (GUI.Button(new Rect(shopPos.x, shopPos.y, ShopUI.Instance.shopButtonSize.x, ShopUI.Instance.shopButtonSize.y), ShopUI.Instance.shopButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        ShopUI.Instance.shopButtonSize = Utility.Instance.EnlargeButtonScale(ShopUI.Instance.shopButtonSize);
                        shopPos = Utility.Instance.EnlargeButtonPosition(shopPos);
                        Utility.Instance.StartEnlargeTimer();
                        shopBPNum = 7;
                        buttonPresses = true;
                        shopBP = true;
                    }                                 
                }
                //Replay Button
                if (GUI.Button(new Rect(looseReplayPos.x, looseReplayPos.y, looseReplaySize.x, looseReplaySize.y), replayButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        looseReplaySize = Utility.Instance.EnlargeButtonScale(looseReplaySize);
                        looseReplayPos = Utility.Instance.EnlargeButtonPosition(looseReplayPos);
                        Utility.Instance.StartEnlargeTimer();
                        replayBPNum = 2;
                        buttonPresses = true;
                        replayBP = true;
                    }      
                }

                //Home Button
                if (GUI.Button(new Rect(homePos.x, homePos.y, homeSize.x, homeSize.y), homeButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        homeSize = Utility.Instance.EnlargeButtonScale(homeSize);
                        homePos = Utility.Instance.EnlargeButtonPosition(homePos);
                        Utility.Instance.StartEnlargeTimer();
                        menuBPNum = 2;
                        buttonPresses = true;
                        mainMenuBP = true;
                    }                                      
                }
            }

        }
        else if (GameManager.Instance.paused == true)
        {

            //background texture
            GUI.DrawTexture(new Rect(backgroundScreenPos.x, backgroundScreenPos.y, backgroundScreenSize.x, backgroundScreenSize.y), backgroundScreen, ScaleMode.StretchToFill, true, 0);
            
            if (GameState.Instance.pausedMenu == true)
            {
                GUI.DrawTexture(new Rect(bannerPos.x, bannerPos.y, bannerSize.x, bannerSize.y), banner, ScaleMode.StretchToFill, true, 0);
                //unpaused button
                if (GUI.Button(new Rect(unPausePos.x, unPausePos.y, unPauseSize.x, unPauseSize.y), unPauseButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        unPauseSize = Utility.Instance.EnlargeButtonScale(unPauseSize);
                        unPausePos = Utility.Instance.EnlargeButtonPosition(unPausePos);
                        Utility.Instance.StartEnlargeTimer();
                        buttonPresses = true;
                        unpauseBP = true;
                    }
                }
                //Shop button
                if (GUI.Button(new Rect(shopPos.x, shopPos.y, ShopUI.Instance.shopButtonSize.x, ShopUI.Instance.shopButtonSize.y), ShopUI.Instance.shopButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        ShopUI.Instance.shopButtonSize = Utility.Instance.EnlargeButtonScale(ShopUI.Instance.shopButtonSize);
                        shopPos = Utility.Instance.EnlargeButtonPosition(shopPos);
                        Utility.Instance.StartEnlargeTimer();
                        shopBPNum = 4;
                        buttonPresses = true;
                        shopBP = true;
                    }
                }
                //Replay Button
                if (GUI.Button(new Rect(replayPos.x, replayPos.y, replaySize.x, replaySize.y), replayButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        replaySize = Utility.Instance.EnlargeButtonScale(replaySize);
                        replayPos = Utility.Instance.EnlargeButtonPosition(replayPos);
                        Utility.Instance.StartEnlargeTimer();
                        replayBPNum = 1;
                        buttonPresses = true;
                        replayBP = true;
                    }            
                }
                //Home Button
                if (GUI.Button(new Rect(homePos.x, homePos.y, homeSize.x, homeSize.y), homeButton, "label"))
                {
                    if (buttonPresses == false)
                    {
                        homeSize = Utility.Instance.EnlargeButtonScale(homeSize);
                        homePos = Utility.Instance.EnlargeButtonPosition(homePos);
                        Utility.Instance.StartEnlargeTimer();
                        menuBPNum = 1;
                        buttonPresses = true;
                        mainMenuBP = true;
                    }              
                }
                /*
                * ITEM CAROUSEL START
                */
                if (ShopUI.Instance.currentItemSelected - 1 < 1)
                {
                    ShopUI.Instance.carouselLeftItem = 0;
                }
                else
                {
                    ShopUI.Instance.carouselLeftItem = ShopUI.Instance.currentItemSelected - 1;
                }

                if (ShopUI.Instance.currentItemSelected + 1 > GameState.Instance.maxItems)
                {
                    ShopUI.Instance.carouselRightItem = 0;
                }
                else
                {
                    ShopUI.Instance.carouselRightItem = ShopUI.Instance.currentItemSelected + 1;
                }

                // CAROUSEL LEFT 
                if (ShopUI.Instance.carouselLeftItem == 1)
                {
                    //Item 1 button
					if (GUI.Button(new Rect(ShopUI.Instance.carouselLeftPos.x, ShopUI.Instance.carouselLeftPos.y, ShopUI.Instance.carouselButtonSizeSmall.x, ShopUI.Instance.carouselButtonSizeSmall.y), GameState.Instance.playerInventory.crystalNut.itemButton, "label") ||  MyTouchLogic.mytouchlogic.swipeRight)
                    {
                        Debug.Log("Touched: Crystal Nut");
                        ShopUI.Instance.currentItemSelected = 1;
						MyTouchLogic.mytouchlogic.swipeRight = false;

                    }
                }
                else if (ShopUI.Instance.carouselLeftItem == 2)
                {
                    //Item 2 button
					if (GUI.Button(new Rect(ShopUI.Instance.carouselLeftPos.x, ShopUI.Instance.carouselLeftPos.y, ShopUI.Instance.carouselButtonSizeSmall.x, ShopUI.Instance.carouselButtonSizeSmall.y), GameState.Instance.playerInventory.rewindNut.itemButton, "label") ||  MyTouchLogic.mytouchlogic.swipeRight)
                    {
                        Debug.Log("Touched: Rewind Nut");
                        ShopUI.Instance.currentItemSelected = 2;
						MyTouchLogic.mytouchlogic.swipeRight = false;

                    }
                }
                else if (ShopUI.Instance.carouselLeftItem == 3)
                {
                    //Item 3 button
					if (GUI.Button(new Rect(ShopUI.Instance.carouselLeftPos.x, ShopUI.Instance.carouselLeftPos.y, ShopUI.Instance.carouselButtonSizeSmall.x, ShopUI.Instance.carouselButtonSizeSmall.y), GameState.Instance.playerInventory.slowTimeNut.itemButton, "label") ||  MyTouchLogic.mytouchlogic.swipeRight)
                    {
                        Debug.Log("Touched: Slow Time Nut");
                        ShopUI.Instance.currentItemSelected = 3;
						MyTouchLogic.mytouchlogic.swipeRight = false;
                    }
                }

                // CAROUSEL Right
                if (ShopUI.Instance.carouselRightItem == 1)
                {
                    //Item 1 button
					if (GUI.Button(new Rect(ShopUI.Instance.carouselRightPos.x, ShopUI.Instance.carouselRightPos.y, ShopUI.Instance.carouselButtonSizeSmall.x, ShopUI.Instance.carouselButtonSizeSmall.y), GameState.Instance.playerInventory.crystalNut.itemButton, "label") ||  MyTouchLogic.mytouchlogic.swipeLeft)
                    {
                        Debug.Log("Touched: Crystal Nut");
                        ShopUI.Instance.currentItemSelected = 1;
						MyTouchLogic.mytouchlogic.swipeLeft = false;
                    }
                }
                else if (ShopUI.Instance.carouselRightItem == 2)
                {
                    //Item 2 button
					if (GUI.Button(new Rect(ShopUI.Instance.carouselRightPos.x, ShopUI.Instance.carouselRightPos.y, ShopUI.Instance.carouselButtonSizeSmall.x, ShopUI.Instance.carouselButtonSizeSmall.y), GameState.Instance.playerInventory.rewindNut.itemButton, "label") ||  MyTouchLogic.mytouchlogic.swipeLeft)
                    {
                        Debug.Log("Touched: Rewind Nut");
                        ShopUI.Instance.currentItemSelected = 2;
						MyTouchLogic.mytouchlogic.swipeLeft = false;
                    }
                }
                else if (ShopUI.Instance.carouselRightItem == 3)
                {
                    //Item 2 button
					if (GUI.Button(new Rect(ShopUI.Instance.carouselRightPos.x, ShopUI.Instance.carouselRightPos.y, ShopUI.Instance.carouselButtonSizeSmall.x, ShopUI.Instance.carouselButtonSizeSmall.y), GameState.Instance.playerInventory.slowTimeNut.itemButton, "label") ||  MyTouchLogic.mytouchlogic.swipeLeft)
                    {
                        Debug.Log("Touched: Item 3");
                        ShopUI.Instance.currentItemSelected = 3;
						MyTouchLogic.mytouchlogic.swipeLeft = false;
                    }
                }
                GameState.Instance.currentItemno = ShopUI.Instance.currentItemSelected;
                // CAROUSEL MIDDLE
                if (ShopUI.Instance.currentItemSelected == 1)
                {
                    //Item 1 button
                    if (GUI.Button(new Rect(ShopUI.Instance.carouselMiddlePos.x, ShopUI.Instance.carouselMiddlePos.y, ShopUI.Instance.carouselButtonSizeLarge.x, ShopUI.Instance.carouselButtonSizeLarge.y), GameState.Instance.playerInventory.crystalNut.itemButton, "label"))
                    {
                        Debug.Log("Touched: Item 1");
                        //GameState.Instance.playerInventory.crystalNutCount ++;
                    }
                }
                else if (ShopUI.Instance.currentItemSelected == 2)
                {
                    //Item 2 button
                    if (GUI.Button(new Rect(ShopUI.Instance.carouselMiddlePos.x, ShopUI.Instance.carouselMiddlePos.y, ShopUI.Instance.carouselButtonSizeLarge.x, ShopUI.Instance.carouselButtonSizeLarge.y), GameState.Instance.playerInventory.rewindNut.itemButton, "label"))
                    {
                        Debug.Log("Touched: Item 2");
                        //GameState.Instance.playerInventory.rewindNutCount ++;
                    }
                }
                else if (ShopUI.Instance.currentItemSelected == 3)
                {

                    //Item 3 button
                    if (GUI.Button(new Rect(ShopUI.Instance.carouselMiddlePos.x, ShopUI.Instance.carouselMiddlePos.y, ShopUI.Instance.carouselButtonSizeLarge.x, ShopUI.Instance.carouselButtonSizeLarge.y), GameState.Instance.playerInventory.slowTimeNut.itemButton, "label"))
                    {
                        Debug.Log("Touched: Item 3");
                        //GameState.Instance.playerInventory.slowTimeNutCount ++;
                    }
                }
                /*
                * ITEM CAROUSEL END
                */

                //Nut Amount!
                GUI.DrawTexture(new Rect(ShopUI.Instance.amountNutPos.x, ShopUI.Instance.amountNutPos.y, ShopUI.Instance.amountNutSize.x, ShopUI.Instance.amountNutSize.y), ShopUI.Instance.amountNut, ScaleMode.StretchToFill, true, 0);
                ShopUI.Instance.nutAmount = GameState.Instance.playerInventory.GetNutAmount(ShopUI.Instance.currentItemSelected);
                GUI.Label(new Rect(ShopUI.Instance.amountNutLabelPos.x, ShopUI.Instance.amountNutLabelPos.y, ShopUI.Instance.amountNutLabelSize.x, ShopUI.Instance.amountNutLabelSize.y), ShopUI.Instance.nutAmount.ToString());
                                
            }            
        }
        else
        {
            //Crystal Nut button
            if (GUI.Button(new Rect(crystalNutPos.x, crystalNutPos.y, crystalNutSize.x, crystalNutSize.y), crystalNut, "label"))
            {
                if (buttonPresses == false)
                {
                    crystalNutSize = Utility.Instance.EnlargeButtonScale(crystalNutSize);
                    crystalNutPos = Utility.Instance.EnlargeButtonPosition(crystalNutPos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    crystalNutBP = true;
                }               
            }

            //Slow Time Nut button
            if (GUI.Button(new Rect(slowTimeNutPos.x, slowTimeNutPos.y, slowTimeNutSize.x, slowTimeNutSize.y), slowTimeNut, "label"))
            {
                if (buttonPresses == false)
                {
                    slowTimeNutSize = Utility.Instance.EnlargeButtonScale(slowTimeNutSize);
                    slowTimeNutPos = Utility.Instance.EnlargeButtonPosition(slowTimeNutPos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    slowTimeNutBP = true;
                }                 
            }

            //Rewind Nut button
            if (GUI.Button(new Rect(rewindNutPos.x, rewindNutPos.y, rewindNutSize.x, rewindNutSize.y), rewindNut, "label"))
            {
                if (buttonPresses == false)
                {
                    rewindNutSize = Utility.Instance.EnlargeButtonScale(rewindNutSize);
                    rewindNutPos = Utility.Instance.EnlargeButtonPosition(rewindNutPos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    rewindNutBP = true;
                }               
            }

            //pause button
            if (GUI.Button(new Rect(pausePos.x, pausePos.y, pauseSize.x, pauseSize.y), pauseButton, "label"))
            {
                if (buttonPresses == false)
                {
                    pauseSize = Utility.Instance.EnlargeButtonScale(pauseSize);
                    pausePos = Utility.Instance.EnlargeButtonPosition(pausePos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    pauseBP = true;
                }                
            }
        }
        // restore matrix before returning
        GUI.matrix = svMat; // restore matrix
    }
}
