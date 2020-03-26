package Liquid;

import static Osetreni.Numbers.*;

public class MichaniPrichuti {


    static int podilPrichute;
    static int celkoveMnozstviLiquidu;

    public static void vypocitejPodilPrichute() {
        podilPrichute = setInt("podil prichute (%)");
        celkoveMnozstviLiquidu = setInt("celkove mnozstvi liquidu (ml)");
        float vysledek = (podilPrichute * celkoveMnozstviLiquidu) / 100;
        System.out.println("Pridejte " + vysledek + "ml prichute");
        System.out.println("Do " + (celkoveMnozstviLiquidu - vysledek) + "ml baze");
    }


}
