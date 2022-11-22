package xyz.angeloanan;

import java.util.HashMap;
import java.util.Scanner;

public class Main {
    private static final Scanner stdin = new Scanner(System.in);
    private static final HashMap<String, Singleton> AnimalStore = new HashMap<>();

    public static void main(String[] args) {
        AnimalStore.put("cow", new CowSingleton());
        AnimalStore.put("bird", new BirdSingleton());
        AnimalStore.put("snake", new SnakeSingleton());

        while (true) {
            System.out.print("> ");
            String input = stdin.nextLine();

            String[] splittedInput = input.toLowerCase().split(" ");
            if (splittedInput.length < 3) {
                System.out.println("Please input `query <classname> <methodname>` or `newanimal <animalname> <cow|bird|snake>`");
                continue;
            }

            String statement = splittedInput[0];
            String animalName = splittedInput[1];
            switch (statement.toLowerCase()) {
                case "query" -> {
                    String queryMethod = splittedInput[2];
                    Animal selectedAnimal = (Animal) AnimalStore.get(animalName).getInstance();

                    if (selectedAnimal == null) {
                        System.out.println("Invalid animal name!");
                        break;
                    }

                    switch (queryMethod) {
                        case "eat" -> selectedAnimal.Eat();
                        case "move" -> selectedAnimal.Move();
                        case "speak" -> selectedAnimal.Speak();
                        default -> System.out.println("Invalid method name!");
                    }
                }

                case "newanimal" -> {
                    String animalType = splittedInput[2];
                    switch (animalType.toLowerCase()) {
                        case "cow" -> AnimalStore.put(animalName, new CowSingleton());
                        case "bird" -> AnimalStore.put(animalName, new BirdSingleton());
                        case "snake" -> AnimalStore.put(animalName, new SnakeSingleton());
                        default -> System.out.println("Invalid Animal type. Use `cow`, `snake` and `bird`!");
                    }
                }

                default -> System.out.println("Unknown statement. Use `query` or `newanimal`!");
            }
        }
    }
}
