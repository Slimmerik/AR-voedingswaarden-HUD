using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class menu_controll : MonoBehaviour
{

    public logic consumption_container;


    public GameObject main_menu;
    public GameObject add_meal_menu;
    public GameObject meal_list_menu;
    public GameObject onscreen_menu;

    public GameObject input_fat;
    public GameObject input_health;
    public GameObject input_prot;
    public GameObject input_name;
    public GameObject input_carb;
    public GameObject input_kcal;

    public GameObject meal_list_texts;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {







    }


    public void with_to_main_menu() {
        main_menu.SetActive(true);
        add_meal_menu.SetActive(false);
        meal_list_menu.SetActive(false);
        onscreen_menu.SetActive(false);
    }

    public void switch_to_add_meal_menu() {
        main_menu.SetActive(false);
        add_meal_menu.SetActive(true);
        meal_list_menu.SetActive(false);
        onscreen_menu.SetActive(false);
    }

    public void switch_to_meal_list() {
        make_meal_list();
        main_menu.SetActive(false);
        add_meal_menu.SetActive(false);
        meal_list_menu.SetActive(true);
        onscreen_menu.SetActive(false);
    }

    public void switch_to_ar_overlay() {
        main_menu.SetActive(false);
        add_meal_menu.SetActive(false);
        meal_list_menu.SetActive(false);
        onscreen_menu.SetActive(true);
    }

    public void add_meal() {
        string name = input_name.GetComponent<InputField>().text;
        double fat = Convert.ToDouble(input_fat.GetComponent<InputField>().text);
        double prot = Convert.ToDouble(input_prot.GetComponent<InputField>().text);
        double health = Convert.ToDouble(input_health.GetComponent<InputField>().text);
        double carb = Convert.ToDouble(input_carb.GetComponent<InputField>().text);
        double kcal = Convert.ToDouble(input_kcal.GetComponent<InputField>().text);
        consumption_container.add_meal(new logic.meal(name, kcal, health, fat, carb, prot));
    }

    public void make_meal_list() {
        string re = "";
        foreach (logic.meal temp in consumption_container.meal_list) {
            re = re + ("Name: " + temp.name + " Healthscore: " + temp.healtyscore + " Kcal: " + temp.kcal + " Fat: " + temp.fat + " Carbs: " + temp.carb + " protein: " + temp.prot + "\n");
        }
        meal_list_texts.GetComponent<Text>().text = re;
    }

}
