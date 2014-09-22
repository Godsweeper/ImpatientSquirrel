using UnityEngine;
using System.Collections;

//A simple countdown timer
public class Timer
{
    #region Public variables
    public float myTimer;               //Timer count
    public bool timerActive = false;    //Timer activation
    #endregion

    //Updates the timer
    public void UpdateTimer() 
    {
        //If timer is active
        if (timerActive == true)
        {
            //If timer is greater than 0
            if(myTimer > 0.0f)
            {
                //update timer
                myTimer -= Time.deltaTime;
            }  
        }
    }

    //Checks if the timer has reached 0
    public bool checkTimer()
    {
        bool timerCheck = new bool();
        //If timer is less than or = 0
        if (myTimer <= 0)
        {
            //Set check to true
            timerCheck = true;
        }
        //return check
        return timerCheck;
    }
    //Check the integer timer
    public int checkTimerNum()
    {
        //return the timer casted into an int
        return (int)myTimer;
    }
    //Check the float timer
    public float checkFullTimerNum()
    {
        //Return the timer
        return myTimer;
    }

    //Pauses the timer 
    public void pauseTimer()
    {
        //Set the timer to inactive
        timerActive = false;
    }

    //Starts the timer
    public void startTimer()
    {
        //If the timer is inactive
        if (timerActive == false)
        {
            //Set the timer to active
            timerActive = true;
        }
    }
    //Set time for the timer
    public void setTimer(float newTimeToCountDown)
    {
        //Sets the time to the parameter value
        myTimer = newTimeToCountDown;
    }

    //Resets the timer with a new time
    public void resetTimer(float newTimeToCountDown)
    {
        //sets the time to the parameter value
        myTimer = newTimeToCountDown;
        //sets timer to inactive
        timerActive = false;
    }
}
