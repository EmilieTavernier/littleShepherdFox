using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariables
{
    private static int currentLevel = 0, score = 0, loseCode = 0;
    private static int[] levelsCode = new int[] { 1, 2 };

    public static int CurrentLevel 
    {
        get 
        {
            return currentLevel;
        }
        set 
        {
            currentLevel = value;
        }
    }

    public static int Score 
    {
        get 
        {
            return score;
        }
        set 
        {
            score = value;
        }
    }

    public static int LoseCode 
    {
        get 
        {
            return loseCode;
        }
        set 
        {
            loseCode = value;
        }
    }

    public static int[] LevelsCode 
    {
        get 
        {
            return levelsCode;
        }
    }
}
