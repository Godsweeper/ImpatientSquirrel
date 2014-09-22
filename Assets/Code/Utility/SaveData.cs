using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour
{
    //Saves all keys with modified data (since last save) to disk
    public void SaveAllData()
    {
        PlayerPrefs.Save();
    }

    //Delete specific key function
    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    //Delete all keys function (!!!!WARNING!!!! ONLY USE WHEN 100% NEEDED)
    public void DeleteAllKeys()
    {
        PlayerPrefs.DeleteAll();
    }

    //Save Integer function
    public void SaveInt(string key, int dataValue)
    {
        //Saves the Int data to PlayerPrefs based on the key
        PlayerPrefs.SetInt(key, dataValue);
    }

    //Get Integer function
    public int? GetSavedInt(string key)
    {
        int? temp;
        //Gets the Int data from PlayerPrefs if the key exists
        if (PlayerPrefs.HasKey(key))
        {
            temp = PlayerPrefs.GetInt(key);
        }
        else
        {
            //Debug.Log("key: " + key + " does not exist");
            return null;
        }
        return temp;
    }

    //Save Float function
    public void SaveFloat(string key, float dataValue)
    {
        //Saves the Float data to PlayerPrefs based on the key
        PlayerPrefs.SetFloat(key, dataValue);
    }

    //Get Float function
    public float? GetSavedFloat(string key)
    {
        float? temp;
        //Gets the int data from PlayerPrefs if the key exists
        if (PlayerPrefs.HasKey(key))
        {
            temp = PlayerPrefs.GetFloat(key);
        }
        else
        {
            //Debug.Log("key: " + key + " does not exist");
            temp = null;
        }
        return temp;
    }

    //Save String function
    public void SaveString(string key, string dataValue)
    {
        //Saves the Int data to PlayerPrefs based on the key
        PlayerPrefs.SetString(key, dataValue);
    }

    //Get String function
    public string GetSavedString(string key)
    {
        string temp;
        //Gets the String data from PlayerPrefs based on the key
        if (PlayerPrefs.HasKey(key))
        {
            temp = PlayerPrefs.GetString(key);
        }
        else
        {
            //Debug.Log("key: " + key + " does not exist");
            temp = null;
        }
        return temp;
    }

    //Save Boolean function
    public void SaveBool(string key, bool dataValue)
    {
        //Saves the Boolean data to PlayerPrefs based on the key
        PlayerPrefs.SetInt(key, dataValue? 1:0);
    }

    //Get Boolean function
    public bool?GetSavedBool(string key)
    {
        bool? temp;
        //Gets the Boolean data from PlayerPrefs if the key exists
        if (PlayerPrefs.HasKey(key))
        {
            temp = PlayerPrefs.GetInt(key)==1?true:false;
        }
        else
        {
            //Debug.Log("key: " + key + " does not exist");
            temp = null;
        }
        return temp;
    }
}
