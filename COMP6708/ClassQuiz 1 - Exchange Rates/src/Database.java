import java.sql.*;
import java.util.HashMap;
import java.util.Map;

public class Database {
    // TODO: Move to a .env file
    private final String HOST = "127.0.0.1:3306";
    private final String DATABASE_NAME = "moneychanger";

    private String USERNAME = "angelo";
    private String PASSWORD = "gay";

    private Statement statement;
    private static Database db;


    public Database() {
        try {
            String CONECTION_STRING = String.format("jdbc:mysql://%s/%s", HOST, DATABASE_NAME);
            Connection connection = DriverManager.getConnection(CONECTION_STRING, USERNAME, PASSWORD);
            statement = connection.createStatement();
        } catch (Exception e) {
            // TODO: Proper error handling
            e.printStackTrace();
        }
    }

    public static Database getDb() {
        return db = (db == null) ? new Database() : db;
    }

    // TODO: Separate into a logical thing
    public Map<String, Double> getRates(String loc) {
        String tableName = "moneychanger";
        Map<String, Double> rates = new HashMap<>();

        try {
            ResultSet res = statement.executeQuery(String.format("SELECT * FROM %s WHERE location = %s;", tableName, loc));

            // TODO: Put into array and loop over
            rates.put("IDR", res.getDouble("IDR"));
            rates.put("USD", res.getDouble("USD"));
            rates.put("CNY", res.getDouble("CNY"));

        } catch (Exception e) {
            e.printStackTrace();
        }

        return rates;
    }
}
