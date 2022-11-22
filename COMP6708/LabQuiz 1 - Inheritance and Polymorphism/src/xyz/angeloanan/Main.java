package xyz.angeloanan;

import java.util.HashMap;
import java.util.Scanner;

public class Main {
    private static final Scanner stdin = new Scanner(System.in);
    private static final HashMap<String, Animal> AnimalStore = new HashMap<>();

    public static void main(String[] args) {
        AnimalStore.put("cow", new Cow());
        AnimalStore.put("bird", new Bird());
        AnimalStore.put("snake", new Snake());

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
                    Animal selectedAnimal = AnimalStore.get(animalName);

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
                        case "cow" -> AnimalStore.put(animalName, new Cow());
                        case "bird" -> AnimalStore.put(animalName, new Bird());
                        case "snake" -> AnimalStore.put(animalName, new Snake());
                        default -> System.out.println("Invalid Animal type. Use `cow`, `snake` and `bird`!");
                    }
                }

                default -> System.out.println("Unknown statement. Use `query` or `newanimal`!");
            }
        }
    }
}
