package ar.com.utn.changuito.architecture.net;

import ar.com.utn.changuito.model.statistics.Statistic;

public class SharedObjectTest {

    public static void main(String[] args) {

        testSerialization();
        testMergeWith();
        testModelClassSharedObject();
    }

    private static void testSerialization() {
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

    private static void testMergeWith() {
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

    private static void testModelClassSharedObject() {
        Statistic statistic = new Statistic();
        statistic.setId(123L);

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
