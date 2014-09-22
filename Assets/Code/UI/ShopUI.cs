using UnityEngine;
using System.Collections;

public class ShopUI : MonoSingleton<ShopUI>
{
    public Texture shopButton, backButton;
    public Vector2 shopButtonPos, shopButtonSize, backButtonPos, backButtonSize;
    public Texture buyButton;
    public Vector2 buyButtonPos, buyButtonSize;
    public Texture amountNut;
    public Vector2 amountNutPos, amountNutSize, amountNutLabelPos, amountNutLabelSize;
    public int nutAmount;

    public Texture banner;
    public Vector2 bottomBannerPos, bottomBannerSize;
    public Vector2 topBannerPos, topBannerSize;
    public int shopScreenPick;

    //carousel variables
    public Vector2 carouselButtonSizeLarge, carouselButtonSizeSmall;
    public Vector2 carouselLeftPos, carouselMiddlePos, carouselRightPos;
    public int currentItemSelected, carouselLeftItem, carouselRightItem;  

    private float originalWidth = 1366;
    private float originalHeight = 768;
    private Vector3 scale;

    private bool buttonPresses, buyBP, backBP;   
	

    void Update()
    {   

        //if a buton is pressed
        if (buttonPresses)
        {
            //and if the enlarge timer has finished
            if (Utility.Instance.CheckEnlargeTimer() == true)
            {
                if (backBP)
                {
                    Debug.Log("Touched: back");
                    GameState.Instance.shopMenu = false;
                    if (shopScreenPick == 2)
                    {
                        GameState.Instance.treeSelectMenu = true;
                    }
                    if (shopScreenPick == 3)
                    {
                        GameState.Instance.puzzleSelectMenu = true;
                    }
                    if (shopScreenPick == 4)
                    {
                        GameState.Instance.pausedMenu = true;
                    }
                    if (shopScreenPick == 5)
                    {
                        GameState.Instance.endGameMenu = true;
                    }
                    if (shopScreenPick == 6)
                    {
                        GameState.Instance.optionsMenu = true;
                    }
                    if (shopScreenPick == 7)
                    {
                        GameState.Instance.deathMenu = true;
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
                if(buyBP)
                {
                    GameState.Instance.playerInventory.BuyNut(currentItemSelected, 1);
                    if (currentItemSelected == 1)
                    {
                        GameState.Instance.saveData.SaveCrystalNutAmount(GameState.Instance.playerInventory.crystalNutCount);
                        //crystal nut
                    }
                    else if (currentItemSelected == 2)
                    {
                        GameState.Instance.saveData.SaveRewindNutAmount(GameState.Instance.playerInventory.rewindNutCount);
                        //rewind
                    }
                    else if (currentItemSelected == 3)
                    {
                        GameState.Instance.saveData.SaveSlowTimeNutAmount(GameState.Instance.playerInventory.slowTimeNutCount);
                        //slow time
                    }
                    //reset the Enlarge Timer
                    Utility.Instance.ResetEnlargeTimer();
                    //resize and scale the button to original values
                    buyButtonSize = Utility.Instance.ResetButtonScale();
                    buyButtonPos = Utility.Instance.ResetButtonPosition();
                    //reset the button presses
                    buyBP = false;
                    buttonPresses = false;
                }
            }
        }
    }
    
    void OnGUI()
    {
        GUI.skin = GameState.Instance.customSkin;
        //Scale UI based on original resolution
        scale.x = Screen.width / originalWidth; // calculate hor scale
        scale.y = Screen.height / originalHeight; // calculate vert scale
        scale.z = 1;
        Matrix4x4 svMat = GUI.matrix;
        // substitute matrix - only scale is altered from standard
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

        if (GameState.Instance.shopMenu == true)
        {
            //top banner
            GUI.DrawTexture(new Rect(topBannerPos.x, topBannerPos.y, topBannerSize.x, topBannerSize.y), banner, ScaleMode.StretchToFill, true, 0);
            //bottom banner
            GUI.DrawTexture(new Rect(bottomBannerPos.x, bottomBannerPos.y, bottomBannerSize.x, bottomBannerSize.y), banner, ScaleMode.StretchToFill, true, 0);

            /*
             * ITEM CAROUSEL START
             */           
            //currentItemSelected = (int)GUI.HorizontalSlider(new Rect(topBannerPos.x, topBannerPos.y, topBannerSize.x / 2, topBannerSize.y), currentItemSelected, 1, GameState.Instance.maxItems);
            if (currentItemSelected - 1 < 1)
            {
                //carouselLeftItem = GameState.Instance.maxItems;
                carouselLeftItem = 0;
            }
            else
            {
                carouselLeftItem = currentItemSelected - 1;
            }

            if (currentItemSelected + 1 > GameState.Instance.maxItems)
            {
                carouselRightItem = 0;
            }
            else
            {
                carouselRightItem = currentItemSelected + 1;
            }

            // CAROUSEL LEFT 
            if (carouselLeftItem == 1)
            {
                //Item 1 button
				if (GUI.Button(new Rect(carouselLeftPos.x, carouselLeftPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.playerInventory.crystalNut.itemButton, "label") || MyTouchLogic.mytouchlogic.swipeRight)
                {
                    Debug.Log("Touched: Crystal Nut");
                    currentItemSelected = 1;
					MyTouchLogic.mytouchlogic.swipeRight = false;
                }
            }
            else if (carouselLeftItem == 2)
            {
                //Item 2 button
				if (GUI.Button(new Rect(carouselLeftPos.x, carouselLeftPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.playerInventory.rewindNut.itemButton, "label") || MyTouchLogic.mytouchlogic.swipeRight)
                {
                    Debug.Log("Touched: Rewind Nut");
                    currentItemSelected = 2;
					MyTouchLogic.mytouchlogic.swipeRight = false;
                }
            }
            else if (carouselLeftItem == 3)
            {
                //Item 3 button
				if (GUI.Button(new Rect(carouselLeftPos.x, carouselLeftPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.playerInventory.slowTimeNut.itemButton, "label") || MyTouchLogic.mytouchlogic.swipeRight)
                {
                    Debug.Log("Touched: Slow Time Nut");
                    currentItemSelected = 3;
					MyTouchLogic.mytouchlogic.swipeRight = false;
                }
            }
            
            // CAROUSEL Right
            if (carouselRightItem == 1)
            {
                //Item 1 button
				if (GUI.Button(new Rect(carouselRightPos.x, carouselRightPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.playerInventory.crystalNut.itemButton, "label") || MyTouchLogic.mytouchlogic.swipeLeft)
                {
                    Debug.Log("Touched: Crystal Nut");
                    currentItemSelected = 1;
					MyTouchLogic.mytouchlogic.swipeLeft = false;
                }
            }
            else if (carouselRightItem == 2)
            {
                //Item 2 button
				if (GUI.Button(new Rect(carouselRightPos.x, carouselRightPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.playerInventory.rewindNut.itemButton, "label") || MyTouchLogic.mytouchlogic.swipeLeft)
                {
                    Debug.Log("Touched: Rewind Nut");
                    currentItemSelected = 2;
					MyTouchLogic.mytouchlogic.swipeLeft = false;
                }
            }
            else if (carouselRightItem == 3)
            {
                //Item 2 button
				if (GUI.Button(new Rect(carouselRightPos.x, carouselRightPos.y, carouselButtonSizeSmall.x, carouselButtonSizeSmall.y), GameState.Instance.playerInventory.slowTimeNut.itemButton, "label") || MyTouchLogic.mytouchlogic.swipeLeft)
                {
                    Debug.Log("Touched: Item 3");
                    currentItemSelected = 3;
					MyTouchLogic.mytouchlogic.swipeLeft = false;
                }
            }
            GameState.Instance.currentItemno = currentItemSelected;
            // CAROUSEL MIDDLE
            if (currentItemSelected == 1)
            {
                //Item 1 button
                if (GUI.Button(new Rect(carouselMiddlePos.x, carouselMiddlePos.y, carouselButtonSizeLarge.x, carouselButtonSizeLarge.y), GameState.Instance.playerInventory.crystalNut.itemButton, "label"))
                {
                    Debug.Log("Touched: Item 1");
                    
                }
            }
            else if (currentItemSelected == 2)
            {
                //Item 2 button
                if (GUI.Button(new Rect(carouselMiddlePos.x, carouselMiddlePos.y, carouselButtonSizeLarge.x, carouselButtonSizeLarge.y), GameState.Instance.playerInventory.rewindNut.itemButton, "label"))
                {
                    Debug.Log("Touched: Item 2");
                    
                }
            }
            else if (currentItemSelected == 3)
            {
                //Item 3 button
                if (GUI.Button(new Rect(carouselMiddlePos.x, carouselMiddlePos.y, carouselButtonSizeLarge.x, carouselButtonSizeLarge.y), GameState.Instance.playerInventory.slowTimeNut.itemButton, "label"))
                {
                    Debug.Log("Touched: Item 3");
                    
                }
            }

            
            /*
            * ITEM CAROUSEL END
            */

            if (GUI.Button(new Rect(buyButtonPos.x, buyButtonPos.y, buyButtonSize.x, buyButtonSize.y), buyButton, "label"))
            {
                if (buttonPresses == false)
                {
                    buyButtonSize = Utility.Instance.EnlargeButtonScale(buyButtonSize);
                    buyButtonPos = Utility.Instance.EnlargeButtonPosition(buyButtonPos);
                    Utility.Instance.StartEnlargeTimer();
                    buttonPresses = true;
                    buyBP = true;
                }                
            } 

            //Nut Amount!
            GUI.DrawTexture(new Rect(amountNutPos.x, amountNutPos.y, amountNutSize.x, amountNutSize.y), amountNut, ScaleMode.StretchToFill, true, 0);                     
            nutAmount = GameState.Instance.playerInventory.GetNutAmount(currentItemSelected);
            GUI.Label(new Rect(amountNutLabelPos.x, amountNutLabelPos.y, amountNutLabelSize.x, amountNutLabelSize.y), nutAmount.ToString());
            
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
        }
        // restore matrix before returning
        GUI.matrix = svMat; // restore matrix
    }
}
