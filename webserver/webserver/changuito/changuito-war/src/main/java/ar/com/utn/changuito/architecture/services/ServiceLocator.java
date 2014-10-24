package ar.com.utn.changuito.architecture.services;

import java.util.HashMap;
import java.util.Map;

import ar.com.utn.changuito.model.SeleccionarGondolaStatistic;
import ar.com.utn.changuito.services.*;

/**
 * Created by fernando on 27/09/2014.
 */
public final class ServiceLocator {

    private static final Object LOCK_OBJECT = new Object();
    private static ServiceLocator instance;

    private Map<String, AbstractService> services = new HashMap<String, AbstractService>(15);

    public static ServiceLocator getInstance() {
        if (instance == null) {
            synchronized (LOCK_OBJECT) {
                if (instance == null) {
                    instance = new ServiceLocator();
                }
            }
        }
        return instance;
    }

    private ServiceLocator() {
        registerServices();
    }

    public AbstractService getService(final String serviceId) {
        final AbstractService service = services.get(serviceId);
        if (service == null) {
            throw new RuntimeException("Service with id [" + serviceId + "] does not exists or is not register at ServiceLocator class.");
        }
        return service;
    }

    private void registerServices() {

        // Here you must register all game services
        registerService(new UploadStatisticsService());
        registerService(new GameLoginService());
    }

    private void registerService(final AbstractService service) {
        services.put(service.getId(), service);
    }
}
