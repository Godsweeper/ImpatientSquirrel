using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour
{    
    #region Public Variables
    public string activeState,      //The current active state
                  previousState,    //The previous active state
                  nextState;        //the next state in line
    #endregion
    #region Private Variables
    private static GameStateManager instance; //Instance of the GameStateManager
    #endregion

    // Creates an instance of gamestate as a gameobject if an instance does not exist
    public static GameStateManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameStateManager").AddComponent<GameStateManager>();
            }
            return instance;
        }
    }

    // Sets the instance to null when the application quits
    public void OnApplicationQuit()
    {
        instance = null;
    }

    // Creates a new game state
    public void startState()
    {
        print("Creating a new game state");
        // Load the level currently active
        Application.LoadLevel(activeState);
    }

    // Returns the currently active level
    public string getState()
    {
        return activeState;
    }
    // Retrns the previous active level
    public string getPreviousState()
    {
        return previousState;
    }

    // Returns the next active level
    public string getNextState()
    {
        return nextState;
    }

    
    // Sets the currently active level to a new value    
    public void LoadState(string nextState)
    {
        SetPreviousState();
        SetNextState(nextState);
        activeState = nextState;
    }
    
    //Sets the next state
    public void SetNextState(string nextState)
    {
        // Set activeLevel to newLevel
        activeState = nextState;
    }

    //sets the previous state
    public void SetPreviousState()
    {
        // Set previousLevel to the activeLevel
        previousState = activeState;
    }
}
