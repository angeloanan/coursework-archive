package xyz.angeloanan;

public class BirdSingleton implements Singleton<Bird> {
    private static Bird bird;

    public Bird getInstance() {
        if (bird == null) bird = new Bird();

        return bird;
    }
}

class Bird implements Animal {
    String food = "worms";
    String locomotion = "fly";
    String noise = "peep";

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
