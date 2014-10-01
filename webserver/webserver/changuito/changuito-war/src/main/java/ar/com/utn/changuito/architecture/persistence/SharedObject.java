package ar.com.utn.changuito.architecture.persistence;

import ar.com.utn.changuito.model.Statistic;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonObject;

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

    public double getDouble(final String key) {
        return (Double) data.get(key);
    }

    public int getInt(final String key) {
        return (Integer) data.get(key);
    }

    public String getString(final String key) {
        return (String) data.get(key);
    }

    public <T extends SharedObject> T getSharedObject(final String key, final Class<T> classType) {

        try {
            final T result = classType.newInstance();
            result.mergeWith(getSharedObject(key));
            return result;
        } catch (final Exception exception) {
            throw new RuntimeException(exception.getMessage(), exception);
        }
    }

    public SharedObject getSharedObject(final String key) {

        final Object value = data.get(key);

        SharedObject valueAsSharedObject = null;
        if (value instanceof SharedObject) {
            valueAsSharedObject = (SharedObject) value;
        }
        else if (valueAsSharedObject == null) {
            valueAsSharedObject = new SharedObject((Map<String, Object>) ((Map<String, Object>) value).get("data"));
            // Preferible dejar el objeto ya deserializado, en vez de deserializarlo siempre
            set(key, valueAsSharedObject);
        }
        return valueAsSharedObject;
    }

    public void mergeWith(final SharedObject sharedObject) {
        for (final Map.Entry<String, Object> entry : sharedObject.data.entrySet()) {
            final String key = entry.getKey();
            final Object value = entry.getValue();

            if (value instanceof SharedObject) {
                final SharedObject valueAsSharedObject = (SharedObject) value;
                final Object oldValue = getSharedObject(key);

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

    public byte[] serialize() {
        return toString().getBytes(getCharset());
    }

    public <T> void set(final String key, final T value) {
        data.put(key, value);
    }

    @Override
    public String toString() {
        //TODO: tiene que ser otro para deserializar!!!!!!!!!!!!!!!!!

        final Gson gson = new GsonBuilder().create();
        return gson.toJson(data);
    }

    public static void main(String[] args) {
/*
        final SharedObject parent = new SharedObject();
        parent.set("parent", 1);

        final SharedObject child = new SharedObject();
        child.set("child", 2);
        parent.set("child", child);

        byte[] parentSerialize = parent.serialize();
        SharedObject parentDeserialize = SharedObject.deserialize(parentSerialize);
        System.err.println(parentDeserialize);*/

        testSerialization();
        testMergeWith();
        testModelClassSharedObject();
    }


    static void testSerialization() {
        final SharedObject child = new SharedObject();
        child.set("childName", "mateo");

        final SharedObject parent = new SharedObject();
        parent.set("parentName", "fernando");
        parent.set("child", child);

        SharedObject parentDeserialized = SharedObject.deserialize(parent.serialize());

        System.err.println(parentDeserialized);

        SharedObject childDeserialized = parentDeserialized.getSharedObject("child");

        System.err.println(childDeserialized.getString("childName"));
    }

    static void testMergeWith() {
        SharedObject a = new SharedObject();
        SharedObject b = new SharedObject();
        SharedObject c = new SharedObject();
        SharedObject d = new SharedObject();

        b.set("id", "1");
        b.set("b", "1");

        d.set("id", "2");
        d.set("b", "2");
        d.set("d", "2");

        a.set("so", b);
        c.set("so", d);

        System.err.println("a: " + a);
        System.err.println("c: " + c);

        a.mergeWith(c);

        System.err.println("a.MergeWith(c): " + a);

        SharedObject e = new SharedObject();

        System.err.println("e: " + e);

        e.mergeWith(b);

        System.err.println("b: " + b);
        System.err.println("e.MergeWith(b): " + e);
    }

    static void testModelClassSharedObject() {
        Statistic statistic = new Statistic();
        statistic.setId("id");

        System.err.println("Statistic: " + statistic);

        SharedObject sharedObject = new SharedObject();
        sharedObject.set("child", statistic);

        System.err.println("SharedObject: " + sharedObject);

        Statistic statisticCopy = sharedObject.getSharedObject("child", Statistic.class);
        statisticCopy.set("copy", "true");

        System.err.println("Statistic: " + statistic);
        System.err.println("StatisticCopy: " + statisticCopy);
    }
}
