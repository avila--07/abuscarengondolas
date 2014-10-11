package ar.com.utn.changuito.architecture.process;

import java.util.logging.Level;
import java.util.logging.Logger;

public class RetryingExecutor {

    public static void execute(final int maxRetryingTimes, final int increasingTimeBetween, final Retryable retryable)
            throws Exception {

        executeImpl(maxRetryingTimes, 0, increasingTimeBetween, retryable);
    }

    public static <T> T execute(final int maxRetryingTimes, final int increasingTimeBetween,
                                final RetryableFuture<T> retryableFuture) throws Exception {

        executeImpl(maxRetryingTimes, 0, increasingTimeBetween, retryableFuture);
        return retryableFuture.getValue();
    }

    private static void executeImpl(final int maxRetryingTimes, int retryingTimes, final int increasingTimeBetween,
                                    final Retryable runnable) throws Exception {

        try {
            runnable.run();
        } catch (final Exception e) {

            if (maxRetryingTimes == retryingTimes++) {
                throw new Exception("No more execution retries! Exception is [" + e.getMessage() + "]");
            }
            Logger.getAnonymousLogger().log(Level.WARNING, e + " - " + e.getMessage() + " - " + e.getStackTrace());
            sleep(increasingTimeBetween * retryingTimes);
            executeImpl(maxRetryingTimes, retryingTimes, increasingTimeBetween, runnable);
        }
    }

    private static void sleep(final int millis) {
        try {
            Thread.sleep(millis);
        } catch (final InterruptedException e) {
            // nothing to do
        }
    }
}
