package ar.com.utn.changuito.architecture.utils;

import java.security.SecureRandom;

/**
 * Created by fernando on 19/10/2014.
 */
public class RandomUtils {


    private final static char[] ALL_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".toCharArray();
    private final static char[] NUMBERS = "0123456789".toCharArray();
    private final static char[] ALL_LETTERS_AND_NUMBERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".toCharArray();
    private static final Object LOCK_OBJECT = new Object();
    private static RandomUtils instance;
    private final SecureRandom random;

    private RandomUtils() {
        this.random = new SecureRandom();
    }

    public static RandomUtils getInstance() {
        if (instance == null) {
            synchronized (LOCK_OBJECT) {
                if (instance == null) {
                    instance = new RandomUtils();
                }
            }
        }
        return instance;
    }

    public int getRandomInt(final int exclusiveMax) {
        return this.getRandomInt(0, exclusiveMax);
    }

    public long getRandomLong(final long inclusiveMin, final long exclusiveMax) {
        return inclusiveMin + random.nextLong();
    }

    public int getRandomInt(final int inclusiveMin, final int exclusiveMax) {
        return inclusiveMin + random.nextInt(exclusiveMax - inclusiveMin);
    }

    public String getRandomString(final int size) {
        return getRandomSymbols(size, ALL_LETTERS);
    }

    public String getRandomNumberString(final int size) {
        return getRandomSymbols(size, NUMBERS);
    }

    public String getRandomAlphaNumberString(final int size) {
        return getRandomSymbols(size, ALL_LETTERS_AND_NUMBERS);
    }

    private String getRandomSymbols(final int size, final char[] symbols) {

        final StringBuilder _buffer = new StringBuilder(size);
        while (_buffer.length() < size) {
            _buffer.append(symbols[random.nextInt(symbols.length - 1)]);
        }
        return _buffer.toString();
    }

}
