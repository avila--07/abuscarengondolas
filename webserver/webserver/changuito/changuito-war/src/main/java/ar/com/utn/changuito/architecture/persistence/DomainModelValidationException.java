package ar.com.utn.changuito.architecture.persistence;

public class DomainModelValidationException extends RuntimeException {

    public DomainModelValidationException(final String message) {
        super(message);
    }

}
