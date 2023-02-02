using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backend : MonoBehaviour
{
    public static int IsFirstOpen(){
        return PlayerPrefs.GetInt("first_open", 0);
    }

    public static void SaveNewCar(){
        PlayerPrefs.SetInt("available_cars", PlayerPrefs.GetInt("available_cars") + 1);
    }

    public static void SaveCurrentCoin(){
        PlayerPrefs.SetInt("coins_collected_in_scene_"+Application.loadedLevel.ToString(), PlayerPrefs.GetInt("coins_collected_in_scene_"+Application.loadedLevel.ToString())+1);
    }

    public static int CoinsSavedInLevel(){
        return PlayerPrefs.GetInt("coins_collected_in_scene_"+Application.loadedLevel.ToString());
    }

    public static int GetNumberOfAvailableCars(){
        return PlayerPrefs.GetInt("available_cars") + 1;
    }

    public static void SetIsFirstOpenState(int state){
        PlayerPrefs.SetInt("first_open", state);
    }

    public static void SetIsFirstShopOpenState(int state){
        PlayerPrefs.SetInt("first_shop_open", state);
    }

    public static int GetFirstShopOpenState(){
        return PlayerPrefs.GetInt("first_shop_open", 0);
    }

    public static int AddCoins(int amount){
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")+amount);

        return Backend.GetCoins();
    }

    public static int SubCoins(int amount){
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")-amount);

        return Backend.GetCoins();
    }

    public static int GetCoins(){
        return PlayerPrefs.GetInt("coins");
    }

    public static void SaveLevelProgress(int progress, int level, int isCompleted){
        PlayerPrefs.SetInt("level#"+level.ToString(), progress);

        if(progress>Backend.GetLevelHighestScore(level)){
            Backend.SetLevelHighestScore(level, progress);
        }

        Backend.SetLevelIsCompleted(level, isCompleted);
    }

    public static int LevelIsCompleted(int level){
        return PlayerPrefs.GetInt("is_completed_level#"+level.ToString(), 0);
    }

    public static void SetLevelIsCompleted(int level, int isCompleted){
        PlayerPrefs.SetInt("is_completed_level#"+level.ToString(), isCompleted);
    }

    public static int GetLevelHighestScore(int level){
        return PlayerPrefs.GetInt("max_level#"+level.ToString(), 0);
    }

    public static void SetLevelStars(int level, int stars){
        if(stars>PlayerPrefs.GetInt("max_stars_level#"+level.ToString())){
            PlayerPrefs.SetInt("max_stars_level#"+level.ToString(), stars);
        }
    }

    public static int GetLevelStars(int level){
        return PlayerPrefs.GetInt("max_stars_level#"+level.ToString());
    }

    public static void SetLevelHighestScore(int level, int progress){
        PlayerPrefs.SetInt("max_level#"+level.ToString(), progress);
    }

    public static void SetCarAlreadyGiven(int level, int value){
        PlayerPrefs.SetInt("car_given_at_level_"+level.ToString(), value);
    }

    public static int CarAlreadyGiven(int level){
        return PlayerPrefs.GetInt("car_given_at_level_"+level.ToString());
    }

    public static void SeedDataStore(){
        Backend.AddCoins(14981);
    }

    public static bool GameIsCompletedPanelAlreadyShowed(){
        return PlayerPrefs.GetInt("game_is_completed_panel_already_showed", 0) == 1;
    }

    public static void SetGameIsCompletedPanelAlreadyShowed(int value = 1){
        PlayerPrefs.SetInt("game_is_completed_panel_already_showed", value);
    }

    public static bool IsRated(){
        return PlayerPrefs.GetInt("rated", 0) == 1;
    }

    public static void Rate(){
        PlayerPrefs.SetInt("rated", 1);
    }
}
