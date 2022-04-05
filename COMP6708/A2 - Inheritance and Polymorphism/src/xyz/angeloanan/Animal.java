package xyz.angeloanan;

public class Animal {
    String food;
    String locomotion;
    String noise;

    public Animal(String food, String locomotion, String noise) {
        this.food = food;
        this.locomotion = locomotion;
        this.noise = noise;
    }

    public void Eat () {
        System.out.println(this.food);
    }

    public void Move () {
        System.out.println(this.locomotion);
    }

    public void Speak () {
        System.out.println(this.noise);
    }
}
