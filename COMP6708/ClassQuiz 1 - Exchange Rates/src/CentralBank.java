import java.util.ArrayList;
import java.util.List;

public class CentralBank implements Subject {
    private final List<Observer> observers = new ArrayList<>();

    @Override
    public void attach(Observer o) {
        observers.add(o);
    }

    @Override
    public void detach(Observer o) {
        observers.remove(o);
    }

    @Override
    public void notifyUpdate(double message) {
        observers.forEach(observer -> observer.update(message));
    }
}
