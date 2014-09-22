using UnityEngine;
using System.Collections;

public class GameState : MonoSingleton<GameState>
{
    #region Public Variables
    public IS_SaveData saveData;            //SaveData instance  
    public GUISkin customSkin,              //The custom Skin for the UI
                   baseSkin;                //The base Skin to be saved incase of it being needed
    public Transform gameState,             //Transform for the Game State Instance
                     shopTrans,             //Transform for the shop UI Instance
                     optionsTrans,          //Transform for the options UI Instance
                     utilityTrans,          //Transform for the Ultility Instance
                     playerInventoryTrans,  //Transform for the Player Inventory Instance
                     //Tranforms for each Tree
                     tree1Trans, tree2Trans, tree3Trans, tree4Trans, tree5Trans,
                     nutsTrans,             //Transform for the Nut Instances
                     gesturesTrans;         //Transform for the Gestures Input Instances
    public int currentTreeno,               //Current Tree Number active 
               currentPuzzleno,             //Current Puzzle Number active 
               currentItemno,               //Current Item Number active 
               currentPuzzleAcornNo,        //Current Acorn Number active 
               maxTrees,                    //The current max about of Tree's
               maxItems,                    //The current max amount of Item's(Nuts)
               puzzlesCompleted = 0;        //The overall amount of puzzles completed
    public string currentScene,             //The current active scene name
                  nextScene;                //The next active scene name    
    public bool treeSelectMenu,             //True  = Tree Select menu active
                puzzleSelectMenu,           //True  = Puzzle Select menu active
                shopMenu,                   //True  = Shop menu active
                optionsMenu,                //True  = Options menu active
                pausedMenu,                 //True  = Paused menu active
                endGameMenu,                //True  = End Game menu active
                deathMenu,                  //True  = Death menu active
                achievmentMenu,             //True  = Achievement menu active
                firstPlay,                  //Check for if it is the first play through
                paused,                     //Check for if the game is paused
                logoTimed = true;           //Check for if the Logo time has been completed
    public Tree currentTree,                //The instance of the current active Tree
                nextTree,                   //The instance of the next active Tree
                //Tree instances generated from transforms
                tree1, tree2, tree3, tree4, tree5;
    public Puzzle currentPuzzle,            //The instance of the current active Puzzle
                  nextPuzzle;               //The instance of the next active Puzzle
    public NutInventory playerInventory;    //The instance of the players Nut Inventory
    public SwipeGesture sGesture;           //Instance of the swipe gesture for Touch Input
    #endregion

    void Awake()
    {
        //Load Acorn Data
        saveData.LoadAcornData();
        //Load First Play check
        saveData.LoadFirstPlay();
        //Load Options choices
        saveData.LoadOptions();
        //Load Device specific Nut Inventory
        saveData.LoadNutInventory();
    }

    void Start()
    {
        //If there is a first Tree
        if (tree1 != null)
        {
            //Set up the current Tree, scene and Next scene to the first Tree's puzzles
            currentTree = tree1Trans.GetComponent<Tree>();
            currentScene = currentTree.puzzle1.name;
            nextScene = currentTree.puzzle2.name;
        }
        //Else if there isnt a first tree
        else
        {
            //Log error message
            Debug.Log("Tree 1  = null");
        }

        //If there is a second Tree
        if (tree2 != null)
        {
            //Set next tree to the second Tree
            nextTree = tree2;
        }
        //Else if there isnt a second Tree
        else
        {
            //Set the next Tree to Null
            nextTree = null;
        }  
        //Set current Tree number and current puzzle number to 1
        currentTreeno = 1;
        currentPuzzleno = 1;        
    }

    void FixedUpdate()
    {
        //Update the Current Tree and Next Tree based on what Tree is selected
        if (currentTreeno == 1)
        {
            currentTree = tree1;
            nextTree = tree2;
        }
        else if (currentTreeno == 2)
        {
            currentTree = tree2;
            nextTree = tree3;
        }
        else if (currentTreeno == 3)
        {
            currentTree = tree3;
            nextTree = tree4;
        }
        else if (currentTreeno == 4)
        {
            currentTree = tree4;
            nextTree = tree5;
        }
        else if(currentTreeno == 5)
        {
            currentTree = tree5;
            nextTree = tree5;
        }

        //Update the Current Puzzle and Next Puzzle based on what Puzzle is selected
        if (currentPuzzleno == 1)
        {
            currentPuzzle = currentTree.puzzle1.GetComponent<Puzzle>();
            nextPuzzle = currentTree.puzzle2.GetComponent<Puzzle>();
        }
        else if (currentPuzzleno == 2)
        {
            currentPuzzle = currentTree.puzzle2.GetComponent<Puzzle>();
            nextPuzzle = currentTree.puzzle3.GetComponent<Puzzle>();
        }
        else if (currentPuzzleno == 3)
        {
            currentPuzzle = currentTree.puzzle3.GetComponent<Puzzle>();
            nextPuzzle = currentTree.puzzle4.GetComponent<Puzzle>();
        }
        else if (currentPuzzleno == 4)
        {
            currentPuzzle = currentTree.puzzle4.GetComponent<Puzzle>();
            nextPuzzle = currentTree.puzzle5.GetComponent<Puzzle>();
        }
        else if (currentPuzzleno == 5)
        {
            currentPuzzle = currentTree.puzzle5.GetComponent<Puzzle>();
            nextPuzzle = currentTree.puzzle6.GetComponent<Puzzle>();
        }
        else if (currentPuzzleno == 6)
        {
            currentPuzzle = currentTree.puzzle6.GetComponent<Puzzle>();
            nextPuzzle = currentTree.puzzle7.GetComponent<Puzzle>();
        }
        else if (currentPuzzleno == 7)
        {
            currentPuzzle = currentTree.puzzle7.GetComponent<Puzzle>();
            nextPuzzle = currentTree.puzzle8.GetComponent<Puzzle>();
        }
        else if (currentPuzzleno == 8)
        {
            currentPuzzle = currentTree.puzzle8.GetComponent<Puzzle>();
            nextPuzzle = currentTree.puzzle9.GetComponent<Puzzle>();
        }
        else if (currentPuzzleno == 9)
        {
            currentPuzzle = currentTree.puzzle9.GetComponent<Puzzle>();
            nextPuzzle = currentTree.puzzle10.GetComponent<Puzzle>();
        }
        else if (currentPuzzleno == 10)
        {
            currentPuzzle = currentTree.puzzle10.GetComponent<Puzzle>();
            nextPuzzle = currentTree.puzzle11.GetComponent<Puzzle>();
        }
        else if (currentPuzzleno == 11)
        {
            currentPuzzle = currentTree.puzzle11.GetComponent<Puzzle>();
            nextPuzzle = currentTree.puzzle12.GetComponent<Puzzle>();
        }
        else if (currentPuzzleno == 12)
        {
            if (nextTree != null)
            {
                currentPuzzle = currentTree.puzzle12.GetComponent<Puzzle>();
                nextPuzzle = nextTree.puzzle1.GetComponent<Puzzle>();
            }
            else
            {
                currentPuzzle = currentTree.puzzle12.GetComponent<Puzzle>();
                nextPuzzle = currentTree.puzzle12.GetComponent<Puzzle>();
            }
        }
        currentScene = currentPuzzle.puzzleName;
        nextScene = nextPuzzle.puzzleName;
    }

    //Function that stops Unity from destorying objects that are required in every scene
    public void DontDestroyOnLoad()
    {
        DontDestroyOnLoad(GameStateManager.Instance);       //Gamestate Manager
        DontDestroyOnLoad(gameState.gameObject);            //GameState Gameobject
        DontDestroyOnLoad(optionsTrans.gameObject);         //Options UI Gameobject
        DontDestroyOnLoad(shopTrans.gameObject);            //Shop UI GameObject
        DontDestroyOnLoad(tree1Trans.gameObject);           //First Tree Gameobject
        DontDestroyOnLoad(tree2Trans.gameObject);           //Second Tree Gameobject
        DontDestroyOnLoad(tree3Trans.gameObject);           //Third Tree Gameobject
        DontDestroyOnLoad(tree4Trans.gameObject);           //Fourth Tree Gameobject
        DontDestroyOnLoad(tree5Trans.gameObject);           //Fifth Tree Gameobject
        DontDestroyOnLoad(playerInventoryTrans.gameObject); //Player Inventory Gameobject
        DontDestroyOnLoad(nutsTrans.gameObject);            //Nut prefabs Gameobject
        DontDestroyOnLoad(utilityTrans.gameObject);         //Utility Gameobject
        DontDestroyOnLoad(saveData.gameObject);             //Save/Load Data Gameobject
        DontDestroyOnLoad(gesturesTrans.gameObject);        //Input Gameobject
        AudioManager.Instance.DontDestroyOnLoad();          //Audio Manager Gameobject
    }

    //Function to load the Main Menu Scene
    public void startMainMenu()
    {
        print("Starting Main Menu");
        DontDestroyOnLoad();
        GameStateManager.Instance.LoadState("StartScreen");
        GameStateManager.Instance.startState();
    }

    //Function to load a scene based on a string parameter 
    public void startScene(string level)
    {
        print("Starting Scene: " + level);
        DontDestroyOnLoad();
        GameStateManager.Instance.LoadState(level);
        GameStateManager.Instance.startState();        
    }
}
