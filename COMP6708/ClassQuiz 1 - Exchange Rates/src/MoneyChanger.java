import java.util.Map;

public class MoneyChanger implements Observer {
    private final Database db = new Database();
    private final String location;

    public MoneyChanger(String loc) {
        this.location = loc;
    }

    // Start calculating
    @Override
    public void update(double message) {
        // Get data from DB
        Map<String, Double> rates = db.getRates(location.toUpperCase());

        System.out.println("Location: " + location.toUpperCase());

        System.out.println("IDR = " + message);
        System.out.println("USD = " + (message / rates.get("IDR")) * rates.get("USD"));
        System.out.println("CNY = " + (message / rates.get("IDR")) * rates.get("CNY"));
        System.out.println();
    }
}
