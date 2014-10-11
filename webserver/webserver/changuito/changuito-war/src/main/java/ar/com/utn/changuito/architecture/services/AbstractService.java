package ar.com.utn.changuito.architecture.services;

import ar.com.utn.changuito.architecture.net.SharedObject;

public abstract class AbstractService {

    public abstract String getId();

    protected abstract SharedObject call(final SharedObject serviceParameter);
}
