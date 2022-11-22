package xyz.angeloanan;

public class CowSingleton implements Singleton<Cow> {
    private static Cow cow;

    public Cow getInstance() {
        if (cow == null) cow = new Cow();

        return cow;
    }
}

class Cow implements Animal {
    String food = "grass";
    String locomotion = "walk";
    String noise = "moo";

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
