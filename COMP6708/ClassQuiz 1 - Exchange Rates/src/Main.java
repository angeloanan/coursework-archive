import java.util.Scanner;

public class Main {
    static final Scanner stdin = new Scanner(System.in);

    public static void main(String[] args) {
        // Setup Publisher
        CentralBank centralBank = new CentralBank();

        // Setup Subscribers
        MoneyChanger jakartaMoneychanger = new MoneyChanger("Jakarta");
        MoneyChanger tangerangMoneychanger = new MoneyChanger("Tangerang");
        MoneyChanger baliMoneychanger = new MoneyChanger("Bali");

        centralBank.attach(jakartaMoneychanger);
        centralBank.attach(tangerangMoneychanger);
        centralBank.attach(baliMoneychanger);

        // Actual code starts below

        System.out.print("Input IDR = ");
        double moneyAmount = stdin.nextDouble();

        centralBank.notifyUpdate(moneyAmount);
    }
}