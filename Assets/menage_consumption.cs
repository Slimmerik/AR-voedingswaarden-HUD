using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menage_consumption : MonoBehaviour
{
    public logic consumption_container;
    public voedingswaarden voeding_web_scrape;

    private double prcentvodaan_fat;
    private double prcentvodaan_prot;
    private double prcentvodaan_car;
    private double prcentvodaan_kcal;
    private int procent_aantal_ongezonde_consumpties;

    private double prcentvodaan_fat_plus_consumptie;
    private double prcentvodaan_prot_plus_consumptie;
    private double prcentvodaan_car_plus_consumptie;
    private double prcentvodaan_kcal_plus_consumptie;
    private double procent_aantal_ongezonde_consumpties_plus_consumptie;
    
    public GameObject sphere;

    public GameObject fatbar;
    public GameObject protbar;
    public GameObject carbbar;
    public GameObject kcalbar;
    public GameObject healtybar;

    public GameObject fatbar_plus_consumptie;
    public GameObject protbar_plus_consumptie;
    public GameObject carbbar_plus_consumptie;
    public GameObject kcalbar_plus_consumptie;
    public GameObject healtybar_plus_consumptie;


    public Material red;
    public Material yellow;
    public Material green;
    public Material white;
    public Material black;
    public Material blue;

    public int consumptie_id;
    public double consumptie_multiplier;
    private logic.meal consumptie_waarden;
    // Start is called before the first frame update
    void Start()
    {
        consumptie_waarden = voeding_web_scrape.updateAllVoedingsValues(consumptie_id);
    }




    // Update is called once per frame
    void Update()
    {
        if (this.isActiveAndEnabled)
        {
            update_procenten();
            update_scoreboard();
            update_procenten_met_consumptie();
            update_scoreboard_plus_consumptie();
            color_sphere();
    //        Debug.Log(
    //            "fat: " + consumptie_waarden.fat + "\n" +
    //            "prot: " + consumptie_waarden.prot + "\n" +
    //            "carb: " + consumptie_waarden.carb + "\n" +
    //            "kcal: " + consumptie_waarden.kcal + "\n" +
    //            "healtyscore: " + consumptie_waarden.healtyscore + "\n"


            //            );
            //        Debug.Log(
            //"fat: " + prcentvodaan_fat + "\n" +
            //"prot: " + prcentvodaan_prot + "\n" +
            //"carb: " + prcentvodaan_car + "\n" +
            //"kcal: " + prcentvodaan_kcal + "\n" +
            //"healtyscore: " + procent_aantal_ongezonde_consumpties + "\n"


            //);

            //        Debug.Log(
            //            "fat: " + prcentvodaan_fat_plus_consumptie + "\n" +
            //            "prot: " + prcentvodaan_prot_plus_consumptie + "\n" +
            //            "carb: " + prcentvodaan_car_plus_consumptie + "\n" +
            //            "kcal: " + prcentvodaan_kcal_plus_consumptie + "\n" +
            //            "healtyscore: " + procent_aantal_ongezonde_consumpties_plus_consumptie + "\n"


            //            );



        }

    }

    void update_scoreboard()
    {

        //calc kcal bar
        kcalbar.GetComponent<Renderer>().material = green;
        if (prcentvodaan_kcal != 0)
        {
            float calc_kcal = (0.3f + (2.0f * (float)prcentvodaan_kcal));


            if (prcentvodaan_kcal > 0.5)
            {
                kcalbar.GetComponent<Renderer>().material = yellow;
            }
            else
            {
                kcalbar.GetComponent<Renderer>().material = green;
            }

            if (calc_kcal < 2.3f)
            {
                kcalbar.transform.localScale = new Vector3(calc_kcal, kcalbar.transform.localScale.y, kcalbar.transform.localScale.z);
            }
            else
            {
                kcalbar.transform.localScale = new Vector3(2.3f, kcalbar.transform.localScale.y, kcalbar.transform.localScale.z);
                kcalbar.GetComponent<Renderer>().material = red;
            }
        }
        else
        {
            kcalbar.transform.localScale = new Vector3(0.3f, kcalbar.transform.localScale.y, kcalbar.transform.localScale.z);
        }

        //calc prot bar
        protbar.GetComponent<Renderer>().material = green;
        if (prcentvodaan_prot != 0)
        {
            if (prcentvodaan_prot > 0.5)
            {
                protbar.GetComponent<Renderer>().material = yellow;
            }
            else
            {
                protbar.GetComponent<Renderer>().material = green;
            }

            float prot_calc = (0.3f + (2.0f * (float)prcentvodaan_prot));
            if (prot_calc < 2.3f)
            {
                protbar.transform.localScale = new Vector3(prot_calc, protbar.transform.localScale.y, protbar.transform.localScale.z);
            }
            else
            {
                protbar.transform.localScale = new Vector3(2.3f, protbar.transform.localScale.y, protbar.transform.localScale.z);
                protbar.GetComponent<Renderer>().material = red;
            }
        }
        else
        {
            protbar.transform.localScale = new Vector3(0.3f, protbar.transform.localScale.y, protbar.transform.localScale.z);
        }

        //calc carb bar
        carbbar.GetComponent<Renderer>().material = green;
        if (prcentvodaan_car != 0)
        {
            if (prcentvodaan_car > 0.5)
            {
                carbbar.GetComponent<Renderer>().material = yellow;
            }
            else
            {

            }

            float calc_carb = (0.3f + (2.0f * (float)prcentvodaan_car));
            if (calc_carb < 2.3f)
            {
                carbbar.transform.localScale = new Vector3(calc_carb, carbbar.transform.localScale.y, carbbar.transform.localScale.z);
            }
            else
            {
                carbbar.transform.localScale = new Vector3(2.3f, carbbar.transform.localScale.y, carbbar.transform.localScale.z);
                carbbar.GetComponent<Renderer>().material = red;
            }
        }
        else
        {
            carbbar.transform.localScale = new Vector3(0.3f, carbbar.transform.localScale.y, carbbar.transform.localScale.z);
        }

        //calc fat bar
        fatbar.GetComponent<Renderer>().material = green;
        if (prcentvodaan_fat != 0)
        {
            if (prcentvodaan_fat > 0.5)
            {
                fatbar.GetComponent<Renderer>().material = yellow;
            }
            else
            {
                fatbar.GetComponent<Renderer>().material = green;
            }
            float calc_fat = (0.3f + (2.0f * (float)prcentvodaan_fat));
            if (calc_fat < 2.3f)
            {
                fatbar.transform.localScale = new Vector3(calc_fat, fatbar.transform.localScale.y, fatbar.transform.localScale.z);
            }
            else
            {
                fatbar.transform.localScale = new Vector3(2.3f, fatbar.transform.localScale.y, fatbar.transform.localScale.z);
                fatbar.GetComponent<Renderer>().material = red;
            }
        }
        else
        {
            fatbar.transform.localScale = new Vector3(0.3f, fatbar.transform.localScale.y, fatbar.transform.localScale.z);
        }

        //calc aantal_ongezonde_consumpties bar
        healtybar.GetComponent<Renderer>().material = green;
        if (procent_aantal_ongezonde_consumpties != 0)
        {
            if (procent_aantal_ongezonde_consumpties > 0.5)
            {
                healtybar.GetComponent<Renderer>().material = yellow;
            }
            else
            {
                healtybar.GetComponent<Renderer>().material = green;
            }
            float calc_aoc = (0.3f + (2.0f * (float)procent_aantal_ongezonde_consumpties));
            if (calc_aoc < 2.3f)
            {
                healtybar.transform.localScale = new Vector3(calc_aoc, healtybar.transform.localScale.y, healtybar.transform.localScale.z);
            }
            else
            {
                healtybar.transform.localScale = new Vector3(2.3f, healtybar.transform.localScale.y, healtybar.transform.localScale.z);
                healtybar.GetComponent<Renderer>().material = red;
            }
        }
        else
        {
            healtybar.transform.localScale = new Vector3(0.3f, healtybar.transform.localScale.y, healtybar.transform.localScale.z);
        }

    }

    void update_scoreboard_plus_consumptie() {
        //calc kcal bar
        if (prcentvodaan_kcal_plus_consumptie != 0)
        {
            float calc_kcal = (0.3f + (2.0f * (float)prcentvodaan_kcal_plus_consumptie));

            kcalbar_plus_consumptie.GetComponent<Renderer>().material = blue;
    

            if (calc_kcal < 2.3f)
            {
                kcalbar_plus_consumptie.transform.localScale = new Vector3(calc_kcal, kcalbar_plus_consumptie.transform.localScale.y, kcalbar_plus_consumptie.transform.localScale.z);
            }
            else
            {
                kcalbar_plus_consumptie.transform.localScale = new Vector3(2.3f, kcalbar_plus_consumptie.transform.localScale.y, kcalbar_plus_consumptie.transform.localScale.z);
            }
        }
        else
        {
            kcalbar_plus_consumptie.transform.localScale = new Vector3(0.3f, kcalbar_plus_consumptie.transform.localScale.y, kcalbar_plus_consumptie.transform.localScale.z);
        }

        //calc prot bar
        if (prcentvodaan_prot_plus_consumptie != 0)
        {

            protbar_plus_consumptie.GetComponent<Renderer>().material = blue;


            float prot_calc = (0.3f + (2.0f * (float)prcentvodaan_prot_plus_consumptie));
            if (prot_calc < 2.3f)
            {
                protbar_plus_consumptie.transform.localScale = new Vector3(prot_calc, protbar_plus_consumptie.transform.localScale.y, protbar_plus_consumptie.transform.localScale.z);
            }
            else
            {
                protbar_plus_consumptie.transform.localScale = new Vector3(2.3f, protbar_plus_consumptie.transform.localScale.y, protbar_plus_consumptie.transform.localScale.z);
            }
        }
        else
        {
            protbar_plus_consumptie.transform.localScale = new Vector3(0.3f, protbar_plus_consumptie.transform.localScale.y, protbar_plus_consumptie.transform.localScale.z);
        }

        //calc carb bar
        if (prcentvodaan_car_plus_consumptie != 0)
        {

            carbbar_plus_consumptie.GetComponent<Renderer>().material = blue;


            float calc_carb = (0.3f + (2.0f * (float)prcentvodaan_car_plus_consumptie));
            if (calc_carb < 2.3f)
            {
                carbbar_plus_consumptie.transform.localScale = new Vector3(calc_carb, carbbar_plus_consumptie.transform.localScale.y, carbbar_plus_consumptie.transform.localScale.z);
            }
            else
            {
                carbbar_plus_consumptie.transform.localScale = new Vector3(2.3f, carbbar_plus_consumptie.transform.localScale.y, carbbar_plus_consumptie.transform.localScale.z);
            }
        }
        else
        {
            carbbar_plus_consumptie.transform.localScale = new Vector3(0.3f, carbbar_plus_consumptie.transform.localScale.y, carbbar_plus_consumptie.transform.localScale.z);
        }

        //calc fat bar
        if (prcentvodaan_fat_plus_consumptie != 0)
        {
            fatbar_plus_consumptie.GetComponent<Renderer>().material = blue;

            float calc_fat = (0.3f + (2.0f * (float)prcentvodaan_fat_plus_consumptie));
            if (calc_fat < 2.3f)
            {
                fatbar_plus_consumptie.transform.localScale = new Vector3(calc_fat, fatbar_plus_consumptie.transform.localScale.y, fatbar_plus_consumptie.transform.localScale.z);
            }
            else
            {
                fatbar_plus_consumptie.transform.localScale = new Vector3(2.3f, fatbar_plus_consumptie.transform.localScale.y, fatbar_plus_consumptie.transform.localScale.z);
            }
        }
        else
        {
            fatbar_plus_consumptie.transform.localScale = new Vector3(0.3f, fatbar_plus_consumptie.transform.localScale.y, fatbar_plus_consumptie.transform.localScale.z);
        }

        //calc aantal_ongezonde_consumpties bar
        if (procent_aantal_ongezonde_consumpties_plus_consumptie != 0)
        {
            
            healtybar_plus_consumptie.GetComponent<Renderer>().material = blue;
  
            float calc_aoc = (0.3f + (2.0f * (float)procent_aantal_ongezonde_consumpties_plus_consumptie));
            if (calc_aoc < 2.3f)
            {
                healtybar_plus_consumptie.transform.localScale = new Vector3(calc_aoc, healtybar_plus_consumptie.transform.localScale.y, healtybar_plus_consumptie.transform.localScale.z);
            }
            else
            {
                healtybar_plus_consumptie.transform.localScale = new Vector3(2.3f, healtybar_plus_consumptie.transform.localScale.y, healtybar_plus_consumptie.transform.localScale.z);
            }
        }
        else
        {
            healtybar_plus_consumptie.transform.localScale = new Vector3(0.3f, healtybar_plus_consumptie.transform.localScale.y, healtybar_plus_consumptie.transform.localScale.z);
        }

    }

    void update_procenten()
    {
        logic.meal total = consumption_container.get_total_value();
        prcentvodaan_fat = total.fat / consumption_container.max_fat;
        prcentvodaan_prot = total.prot / consumption_container.max_prot;
        prcentvodaan_kcal = total.kcal / consumption_container.max_kcal;
        prcentvodaan_car = total.carb / consumption_container.max_carb;
        procent_aantal_ongezonde_consumpties = consumption_container.aantal_unhealt_consumption / consumption_container.max_unhealty_comsumpltions;
    }

    void update_procenten_met_consumptie()
    {
        logic.meal total = consumption_container.get_total_value();
        prcentvodaan_fat_plus_consumptie = (total.fat + (consumptie_waarden.fat* consumptie_multiplier)) / consumption_container.max_fat;
        prcentvodaan_prot_plus_consumptie = (total.prot + (consumptie_waarden.prot * consumptie_multiplier)) / consumption_container.max_prot;
        prcentvodaan_kcal_plus_consumptie = (total.kcal + (consumptie_waarden.kcal * consumptie_multiplier)) / consumption_container.max_kcal;
        prcentvodaan_car_plus_consumptie = (total.carb + (consumptie_waarden.carb * consumptie_multiplier)) / consumption_container.max_carb;
        if (consumptie_waarden.healtyscore > consumption_container.gezonde_consumptie_trashold) {
            procent_aantal_ongezonde_consumpties_plus_consumptie = consumption_container.aantal_unhealt_consumption  / consumption_container.max_unhealty_comsumpltions;
        }
        else {
            procent_aantal_ongezonde_consumpties_plus_consumptie = (((double)consumption_container.aantal_unhealt_consumption + 1.0) / (double)consumption_container.max_unhealty_comsumpltions);
        }
    }

    void color_sphere()
    {
        if (prcentvodaan_fat_plus_consumptie < 1.0 && prcentvodaan_prot_plus_consumptie < 1.0 && prcentvodaan_kcal_plus_consumptie < 1.0 && prcentvodaan_car_plus_consumptie < 1.0 && procent_aantal_ongezonde_consumpties_plus_consumptie < 1.0) {
            sphere.GetComponent<Renderer>().material = yellow;
        } else if (prcentvodaan_fat_plus_consumptie < 0.5 && prcentvodaan_prot_plus_consumptie < 0.5 && prcentvodaan_kcal_plus_consumptie < 0.5 && prcentvodaan_car_plus_consumptie < 0.5 && procent_aantal_ongezonde_consumpties_plus_consumptie < 0.5) {
            sphere.GetComponent<Renderer>().material = green;
        }else{
            sphere.GetComponent<Renderer>().material = red;
        }

    }


}
