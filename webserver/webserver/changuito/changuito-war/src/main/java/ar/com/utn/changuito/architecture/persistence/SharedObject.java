package ar.com.utn.changuito.architecture.persistence;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.nio.charset.Charset;
import java.util.HashMap;
import java.util.Map;

public class SharedObject {

    private final Map<String, Object> data;

    public SharedObject() {
        data = new HashMap<String, Object>(20);
    }

    public SharedObject(final SharedObject sharedObject) {
        this(sharedObject.data);
    }

    private SharedObject(final Map<String, Object> data) {
        this.data = data;
    }

    public static SharedObject deserialize(final byte[] bytes) {

        final String jsonCode = new String(bytes, getCharset());

        return new SharedObject(new GsonBuilder().create().fromJson(jsonCode, HashMap.class));
    }

    public static SharedObject deserialize(final String serializedString) {

        return new SharedObject(new GsonBuilder().create().fromJson(serializedString, HashMap.class));
    }

    private static Charset getCharset() {
        return Charset.forName("UTF-8");
    }

    public void mergeWith(final SharedObject sharedObject) {
        for (final Map.Entry<String, Object> entry : sharedObject.data.entrySet()) {
            final String key = entry.getKey();
            final Object value = entry.getValue();

            if (value instanceof SharedObject) {
                final SharedObject valueAsSharedObject = (SharedObject) value;
                final Object oldValue = get(key);

                if (oldValue instanceof SharedObject) {
                    ((SharedObject) oldValue).mergeWith(valueAsSharedObject);
                } else {
                    set(key, valueAsSharedObject);
                }
            } else {
                set(key, value);
            }
        }
    }

    public <T extends SharedObject> T getSharedObject(final String key) {
        return (T) data.get(key);
    }

    public <T> T get(final String key) {
        return (T) data.get(key);
    }

    public void set(final String key, final SharedObject value) {
        if (value != null) {
            data.put(key, value.serializeInString());
        }
    }

    public <T> void set(final String key, final T value) {
        if (value != null) {
            data.put(key, value);
        }
    }

    public byte[] serialize() {
        return serializeInString().getBytes(getCharset());
    }

    public String serializeInString() {

        final Gson gson = new GsonBuilder().create();
        return gson.toJson(data);
    }

    public static void main(String[] args) {

        final SharedObject parent = new SharedObject();
        parent.set("parent", 1);

        final SharedObject child = new SharedObject();
        child.set("child", 2);
        parent.set("child", child);

        byte[] parentSerialize = parent.serialize();
        SharedObject parentDeserialize = SharedObject.deserialize(parentSerialize);
        System.err.println(parentDeserialize.serializeInString());
    }
}
