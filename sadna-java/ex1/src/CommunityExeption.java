public class CommunityExeption extends Exception{
    public CommunityExeption() {
        super();
    }

    public CommunityExeption(String message) {
        super(message);
    }

    public CommunityExeption(String message, Throwable cause) {
        super(message, cause);
    }

    public CommunityExeption(Throwable cause) {
        super(cause);
    }

    protected CommunityExeption(String message, Throwable cause, boolean enableSuppression, boolean writableStackTrace) {
        super(message, cause, enableSuppression, writableStackTrace);
    }
}
