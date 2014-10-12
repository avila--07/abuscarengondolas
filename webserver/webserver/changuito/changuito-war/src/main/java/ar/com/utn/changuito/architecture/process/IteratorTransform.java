package ar.com.utn.changuito.architecture.process;

import java.util.Iterator;

public class IteratorTransform<TIn, TOut> implements Iterator<TOut> {

    private final Transformer<TIn, TOut> transformer;
    private final Iterator<TIn> iterator;

    public IteratorTransform(final Iterator<TIn> iterator, final Transformer<TIn, TOut> transformer) {

        this.iterator = iterator;
        this.transformer = transformer;
    }

    public boolean hasNext() {
        return iterator.hasNext();
    }

    public TOut next() {
        return transformer.transform(iterator.next());
    }

    public void remove() {
        iterator.remove();
    }

    public static interface Transformer<TIn1, TOut1> {

        TOut1 transform(final TIn1 in);
    }
}
