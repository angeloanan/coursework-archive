package xyz.angeloanan.LabQuiz;

import java.util.ArrayList;
import java.util.Scanner;

// Christopher Angelo - 2440041503
// ---
// Designed to be compiled with Java 17
// Personally compiled with IBM Semeru Runtime
// https://developer.ibm.com/languages/java/semeru-runtimes/downloads

public class Main {
    private static final Scanner stdin = new Scanner(System.in); // Helper

    /**
     * Where to store all the guitars
     */
    private static final ArrayList<Guitar> GuitarStores = new ArrayList<>();

    public static void main(String[] args) {
        while (true) {
            printMainMenu();

            int menuChoice = stdin.nextInt();
            stdin.nextLine();

            if (menuChoice == 3) break;
            switch (menuChoice) {
                case 1 -> buildGuitar();
                case 2 -> displayGuitars();
            }
        }
    }

    private static void printMainMenu() {
        System.out.println("1. Build Guitar");
        System.out.println("2. Display List of Guitar");
        System.out.println("3. Exit");
        System.out.print("Choose menu[1..3]: ");
    }

    private static void buildGuitar() {
        System.out.println();
        System.out.println("1. Acoustic");
        System.out.println("2. Electric");
        System.out.println("3. Acoustic Electric");
        System.out.println();
        System.out.print("Input guitar type[1..3]: ");

        int guitarChoice = stdin.nextInt();
        stdin.nextLine();

        Guitar guitarToMake;
        switch (guitarChoice) {
            case 1 -> guitarToMake = new AcousticGuitar();
            case 2 -> guitarToMake = new ElectricGuitar();
            case 3 -> guitarToMake = new AcousticElectricGuitar();
            default -> throw new IllegalStateException("Unexpected value: " + guitarChoice);
            // ^ otherwise IntelliJ complains about uninitialized var
        }
        
        // Using `instanceof` to dynamically detect class implementation.
        if (guitarToMake instanceof SwitchPositionable) {
            System.out.print("Input switch position: ");
            int selectedSwitchPosition = stdin.nextInt();
            stdin.nextLine();

            ((SwitchPositionable) guitarToMake).setSwitchPosition(selectedSwitchPosition);
        }

        if (guitarToMake instanceof ToneControlable) {
            System.out.print("Input tone: ");
            int selectedSwitchPosition = stdin.nextInt();
            stdin.nextLine();

            ((ToneControlable) guitarToMake).setTone(selectedSwitchPosition);
        }

        if (guitarToMake instanceof  VolumeControlable) {
            System.out.print("Input volume: ");
            int selectedSwitchPosition = stdin.nextInt();
            stdin.nextLine();

            ((VolumeControlable) guitarToMake).setVolume(selectedSwitchPosition);
        }

        GuitarStores.add(guitarToMake);
    }

    private static void displayGuitars() {
        System.out.println();
        System.out.println("[GuitarType] - [GuitarSoundType] - [Tone] - [Volume] - [SwitchPosition]");
        GuitarStores.forEach(Guitar::printStats);
        System.out.println();
    }
}
