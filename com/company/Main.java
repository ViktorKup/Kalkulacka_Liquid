package com.company;

import static Liquid.MichaniBazi.vyppocitejSiluLiquidu;
import static Liquid.MichaniPrichuti.vypocitejPodilPrichute;
import static Osetreni.Numbers.*;

public class Main {

    public static void main(String[] args) {
	// write your code here

        String[] menuItems = {"Michani bazi", "Michani prichuti", "Ukoncit"};

        int volba = 0;

        while (volba != 3) {

            for (int i = 0; i < menuItems.length; i++) {
                System.out.println((i+1) + " - " + menuItems[i]);
            }
            volba = setInt("jednu z moznosti");

            switch (volba) {
                case 1:
                    vyppocitejSiluLiquidu();
                    break;
                case 2:
                    vypocitejPodilPrichute();
                    break;
                case 3:
                    System.exit(1);
                default:
                    System.out.println("Zadali jste spatnou moznost");
                    break;
            }
        }

    }
}
