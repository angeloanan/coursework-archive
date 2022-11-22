public interface Subject {
    void attach(Observer o);
    void detach(Observer o);

    // TODO: Split message into a package, using message type ENUMs
    void notifyUpdate(double message);
}