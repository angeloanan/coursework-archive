package xyz.angeloanan;

public class SnakeSingleton implements Singleton<Snake> {
    private static Snake snake;

    public Snake getInstance() {
        if (snake == null) snake = new Snake();

        return snake;
    }
}

class Snake implements Animal {
    String food = "mice";
    String locomotion = "slither";
    String noise = "hsss";

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
