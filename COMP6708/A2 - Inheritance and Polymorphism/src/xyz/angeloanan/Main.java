package xyz.angeloanan;

import java.util.Scanner;

public class Main {
    // TODO: Make `Animal` an abstract class and extend these animals from class `Animal`
    private static final Animal cow = new Animal("grass", "walk", "moo");
    private static final Animal bird = new Animal("worms", "fly", "peep");
    private static final Animal snake = new Animal("mice", "slither", "hsss");

    private static final Scanner stdin = new Scanner(System.in);

    public static void main(String[] args) {
        while (true) {
            System.out.print("> ");
            String input = stdin.nextLine();

            String[] splittedInput = input.toLowerCase().split(" ");
            if (splittedInput.length < 2) {
                System.out.println("Please input `<classname> <methodname>`");
                continue;
            }

            String inputAnimal = splittedInput[0];
            String inputMethod = splittedInput[1];

            // TODO: Dynamically call the Animal by name. Use HashMap to store Object and somehow figure out how to call methods dynamically.
            Animal selectedClass = switch (inputAnimal) {
                case "cow" -> cow;
                case "bird" -> bird;
                case "snake" -> snake;
                default -> null;
            };

            if (selectedClass == null) {
                System.out.println("Invalid class name");
                continue;
            }

            switch (inputMethod) {
                case "eat" -> selectedClass.Eat();
                case "move" -> selectedClass.Move();
                case "speak" -> selectedClass.Speak();
                default -> System.out.println("Invalid method name");
            }
        }
    }
}
