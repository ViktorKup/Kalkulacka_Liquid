package Osetreni;

import java.io.IOException;
import java.util.Scanner;

public class Numbers {

    static Scanner sc = new Scanner(System.in, "UTF-8");

    public static int setInt(String string) {
        return (int) checkNumberExceptions(string);
    }

    public static float setFloat(String string) {
        return checkNumberExceptions(string);
    }

    private static float checkNumberExceptions(String string) {
        String cislo;
        while (true) {
            System.out.println("Zadejte " + string + ": ");
            try {
                cislo = sc.nextLine();
                if (cislo.equals("") || cislo.equals(" ")) {
                    throw new IOException("Pole nesmi byt prazdne...");
                } else if (!cislo.matches("^[0-9]+$")) {
                    throw new IOException("Text muze obsahovat pouze cislice...");
                } else if (cislo.contains(" ")) {
                    throw new IOException("Text nesmi obsahovat mezeru...");
                } else break;
            } catch (IOException e) {
                System.err.println(e.toString());
            }
        }
        return Float.parseFloat(cislo);
    }

}
