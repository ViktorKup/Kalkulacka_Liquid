package Liquid;

import static Osetreni.Numbers.*;

public class MichaniBazi {

    static int silaBoosteru;
    static int vyslednyObjemLiquidu;
    static float vyslednaSilaLiquidu;

    public static void vyppocitejSiluLiquidu() {
        silaBoosteru = setInt("silu boosteru (mg/ml)");
        vyslednyObjemLiquidu = setInt("vysledny objem liquidu (ml)");
        vyslednaSilaLiquidu = setFloat("vyslednou silu liquidu (mg/ml)");
        float vysledek = (vyslednaSilaLiquidu / silaBoosteru) * vyslednyObjemLiquidu;
        System.out.println("Pridej " + vysledek + "ml boosteru");
        System.out.println("Do " + (vyslednyObjemLiquidu - vysledek) + "ml ciste baze");
    }


}
