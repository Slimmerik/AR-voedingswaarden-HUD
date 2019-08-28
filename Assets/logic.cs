using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class logic : MonoBehaviour
{
    public voedingswaarden voeding_web_scrape = new voedingswaarden();
    public double max_fat = 0.0;
    public double max_prot = 0.0;
    public double max_carb = 0.0;
    public double max_kcal = 0.0;
    public int max_unhealty_comsumpltions = 0;

    public int aantal_unhealt_consumption = 0;

    public double gezonde_consumptie_trashold = 6.0;



    public struct meal
    {
        public string name;
        public double kcal;
        public double healtyscore;
        public double fat;
        public double carb;
        public double prot;

        public meal(string n, double k, double h, double f, double c, double p)
        {
            name = n;
            kcal = k;
            healtyscore = h;
            fat = f;
            carb = c;
            prot = p;
        }
    }


    public List<meal> meal_list = new List<meal>();




    // Start is called before the first frame update
    void Start()
    {
        meal_list.Add(new meal("ontbijt", 300.0, 6.0, 10, 40, 10));
        meal_list.Add(new meal("lunch", 300.0, 7.0, 5, 30, 15));
        //meal_list.Add(new meal("dinner", 1200.0, 5.0, 30, 100, 40));
        //meal_list.Add(new meal("cola", 100.0, 4.0, 0.0, 40.0, 0.0));
        //meal_list.Add(new meal("cola", 100.0, 5.2, 0.0, 40.0, 0.0));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void add_meal(int id)
    {
        meal_list.Add(voeding_web_scrape.updateAllVoedingsValues(id));
    }

    public void add_meal(meal m)
    {
        meal_list.Add(m);
    }


    public meal get_total_value()
    {
        meal total_meal = new meal();
        total_meal.name = "total";
        foreach (meal temp in meal_list)
        {
            total_meal.carb = total_meal.carb + temp.carb;
            total_meal.fat = total_meal.fat + temp.fat;
            total_meal.prot = total_meal.prot + temp.prot;
            total_meal.kcal = total_meal.kcal + temp.kcal;
        }
        return total_meal;
    }

    public double gethealscore()
    {
        double healscore = 0;
        int times = 0;
        foreach (meal temp in meal_list)
        {
            healscore = healscore + temp.healtyscore;
            times = times + 1;
        }
        healscore = healscore / times;
        return healscore;
    }

    public void add_unhealy_consuption()
    {
        aantal_unhealt_consumption = aantal_unhealt_consumption + 1;
    }



}
