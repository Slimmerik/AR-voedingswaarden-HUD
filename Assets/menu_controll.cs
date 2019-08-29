using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class menu_controll : MonoBehaviour
{

    public logic consumption_container; //maaltijd container script


    public GameObject main_menu; //main menu canvas object
    public GameObject add_meal_menu; //add_meal_menu canvas object
    public GameObject meal_list_menu; //meal_list_menu canvas object 
    public GameObject onscreen_menu; //onscreen_menu canvas object

    public GameObject input_fat; //input field fat
    public GameObject input_health;//input field health
    public GameObject input_prot; //input field protein
    public GameObject input_name; //input field naam
    public GameObject input_carb; //input field koolydraaten
    public GameObject input_kcal; //input field kcal

    public GameObject meal_list_texts; //text object waar maaltijd lijst terecht komt

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // switch naar main menu
    public void with_to_main_menu() {
        main_menu.SetActive(true);
        add_meal_menu.SetActive(false);
        meal_list_menu.SetActive(false);
        onscreen_menu.SetActive(false);
    }

    //switch naar add meal menu
    public void switch_to_add_meal_menu() {
        main_menu.SetActive(false);
        add_meal_menu.SetActive(true);
        meal_list_menu.SetActive(false);
        onscreen_menu.SetActive(false);
    }

    //switch naar meal list
    public void switch_to_meal_list() {
        make_meal_list();
        main_menu.SetActive(false);
        add_meal_menu.SetActive(false);
        meal_list_menu.SetActive(true);
        onscreen_menu.SetActive(false);
    }

    //switch naar ar overlay
    public void switch_to_ar_overlay() {
        main_menu.SetActive(false);
        add_meal_menu.SetActive(false);
        meal_list_menu.SetActive(false);
        onscreen_menu.SetActive(true);
    }

    //switch naar add meal menu
    public void add_meal() {
        string name = input_name.GetComponent<InputField>().text;
        double fat = Convert.ToDouble(input_fat.GetComponent<InputField>().text);
        double prot = Convert.ToDouble(input_prot.GetComponent<InputField>().text);
        double health = Convert.ToDouble(input_health.GetComponent<InputField>().text);
        double carb = Convert.ToDouble(input_carb.GetComponent<InputField>().text);
        double kcal = Convert.ToDouble(input_kcal.GetComponent<InputField>().text);
        consumption_container.add_meal(new logic.meal(name, kcal, health, fat, carb, prot));
    }

    //maken van maaltijd lijst
    public void make_meal_list() {
        string re = "";
        foreach (logic.meal temp in consumption_container.meal_list) {
            re = re + ("Name: " + temp.name + " Healthscore: " + temp.healtyscore + " Kcal: " + temp.kcal + " Fat: " + temp.fat + " Carbs: " + temp.carb + " protein: " + temp.prot + "\n");
        }
        meal_list_texts.GetComponent<Text>().text = re;
    }

}
