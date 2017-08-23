using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences {

    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string HardDifficultyHighScore = "HardDifficultyHighScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";

    // 0 - false, 1 - true
    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt(IsMusicOn, state);
    }

    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(IsMusicOn);
    }

    public static void SetEasyDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(EasyDifficulty, difficulty);
    }

    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(EasyDifficulty);
    }

    public static void SetMediumDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(MediumDifficulty, difficulty);
    }

    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(MediumDifficulty);
    }

    public static void SetHardDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(HardDifficulty, difficulty);
    }

    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(HardDifficulty);
    }

    public static void SetEasyDifficultyHighScore(int DifficultyHighScore)
    {
        PlayerPrefs.SetInt(EasyDifficultyHighScore, DifficultyHighScore);
    }

    public static int GetEasyDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(EasyDifficultyHighScore);
    }

    public static void SetMediumDifficultyHighScore(int DifficultyHighScore)
    {
        PlayerPrefs.SetInt(MediumDifficultyHighScore, DifficultyHighScore);
    }

    public static int GetMediumDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(MediumDifficultyHighScore);
    }

    public static void SetHardDifficultyHighScore(int DifficultyHighScore)
    {
        PlayerPrefs.SetInt(HardDifficultyHighScore, DifficultyHighScore);
    }

    public static int GetHardDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(HardDifficultyHighScore);
    }

    public static void SetEasyDifficultyCoinScore(int DifficultyCoinScore)
    {
        PlayerPrefs.SetInt(EasyDifficultyCoinScore, DifficultyCoinScore);
    }

    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(EasyDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScore(int DifficultyCoinScore)
    {
        PlayerPrefs.SetInt(MediumDifficultyCoinScore, DifficultyCoinScore);
    }

    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(MediumDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinScore(int DifficultyCoinScore)
    {
        PlayerPrefs.SetInt(HardDifficultyCoinScore, DifficultyCoinScore);
    }

    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(HardDifficultyCoinScore);
    }



}
