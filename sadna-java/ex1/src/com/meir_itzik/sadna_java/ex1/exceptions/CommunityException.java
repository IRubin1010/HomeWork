package com.meir_itzik.sadna_java.ex1.exceptions;

public class CommunityException extends Exception{
    public CommunityException() {
        super();
    }

    public CommunityException(String message) {
        super(message);
    }

    public CommunityException(String message, Throwable cause) {
        super(message, cause);
    }

    public CommunityException(Throwable cause) {
        super(cause);
    }

    protected CommunityException(String message, Throwable cause, boolean enableSuppression, boolean writableStackTrace) {
        super(message, cause, enableSuppression, writableStackTrace);
    }
}
