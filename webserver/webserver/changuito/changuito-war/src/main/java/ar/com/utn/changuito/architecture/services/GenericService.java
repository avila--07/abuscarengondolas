package ar.com.utn.changuito.architecture.services;

import ar.com.utn.changuito.architecture.persistence.SharedObject;

import java.lang.reflect.ParameterizedType;

public abstract class GenericService<TIn extends SharedObject> extends AbstractService {

    protected abstract SharedObject typedCall(final TIn serviceParameter);

    @Override
    protected SharedObject call(final SharedObject serviceParameter) {

        final TIn specificServiceParameter = NewInstanceOfSpecificParameter();
        specificServiceParameter.mergeWith(serviceParameter);
        return typedCall(specificServiceParameter);
    }

    private TIn NewInstanceOfSpecificParameter() {

        try {
            return (TIn) ((Class) ((ParameterizedType) this.getClass().
                    getGenericSuperclass()).getActualTypeArguments()[0]).newInstance();
        } catch (final Exception exception) {
            throw new RuntimeException("Cannot craete instance of GenericService parameter type.", exception);
        }
    }
}
