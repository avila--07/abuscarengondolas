package ar.com.utn.changuito.architecture.utils;

public class StringUtils {

    public static boolean isEmptyOrNull(final String aString) {
        return (aString == null || aString.trim().length() == 0);
    }
}
