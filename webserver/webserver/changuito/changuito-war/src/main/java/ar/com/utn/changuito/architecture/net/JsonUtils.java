package ar.com.utn.changuito.architecture.net;

import org.apache.commons.io.IOUtils;

import javax.json.Json;
import javax.json.JsonObjectBuilder;
import javax.json.stream.JsonParser;
import java.io.IOException;
import java.io.InputStream;
import java.nio.charset.Charset;
import java.util.HashMap;
import java.util.Map;

public class JsonUtils {

    public static byte[] convertMapToJsonBytes(final Map<String, Object> data) {

        return convertMapToJsonString(data).getBytes(getCharset());
    }

    public static String convertMapToJsonString(final Map<String, Object> data) {

        final JsonObjectBuilder objectBuilder = Json.createObjectBuilder();
        for (final Map.Entry<String, Object> entry : data.entrySet()) {
            set(objectBuilder, entry.getKey(), entry.getValue());
        }
        return objectBuilder.build().toString();
    }

    public static Map<String, Object> convertJsonBytesToMap(final byte[] jsonCodeBytes) {

        final String jsonCode = new String(jsonCodeBytes, getCharset());
        return convertJsonStringToMap(jsonCode);
    }

    public static Map<String, Object> convertJsonStringToMap(final String jsonCode) {

        final HashMap<String, Object> data = new HashMap<String, Object>(20);
        try {
            final InputStream inputStream = IOUtils.toInputStream(jsonCode, getCharset().displayName());

            final JsonParser parser = Json.createParser(inputStream);
            String key = null;
            while (parser.hasNext()) {
                final JsonParser.Event event = parser.next();

                switch (event) {
                    case KEY_NAME:
                        key = parser.getString();
                        break;
                    case VALUE_TRUE:
                        data.put(key, true);
                        break;
                    case VALUE_FALSE:
                        data.put(key, false);
                        break;
                    case VALUE_NUMBER:
                        data.put(key, parser.getInt());
                        break;
                    case VALUE_STRING:
                        data.put(key, parser.getString());
                        break;
                    case VALUE_NULL:
                        data.put(key, null);
                        break;
                }
            }

            return data;
        } catch (final IOException exception) {
            throw new RuntimeException("Desearialization of [" + jsonCode + "] failed ", exception);
        }
    }

    private static Charset getCharset() {
        return Charset.forName("UTF-8");
    }

    private static void set(final JsonObjectBuilder jsonBuilder, final String key, final Object value) {
        if (value == null) {
            jsonBuilder.addNull("");
        } else if (value instanceof Integer) {
            jsonBuilder.add(key, (Integer) value);
        } else if (value instanceof Double) {
            jsonBuilder.add(key, (Double) value);
        } else if (value instanceof String) {
            jsonBuilder.add(key, (String) value);
        } else if (value instanceof SharedObject) {
            jsonBuilder.add(key, ((SharedObject) value).toString());
        } else {
            jsonBuilder.add(key, value.toString());
        }
    }
}
