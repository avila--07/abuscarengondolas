package ar.com.utn.changuito.architecture.process;

public interface RetryableFuture<T> extends Retryable {

	T getValue();
}
