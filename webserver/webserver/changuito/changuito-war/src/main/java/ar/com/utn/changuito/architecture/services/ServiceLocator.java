package ar.com.utn.changuito.architecture.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.services.*;

import java.util.HashMap;
import java.util.Map;

public final class ServiceLocator {

    private static final Object LOCK_OBJECT = new Object();
    private static ServiceLocator instance;

    private Map<String, AbstractService> services = new HashMap<String, AbstractService>(15);

    private ServiceLocator() {
        registerServices();
    }

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

    public AbstractService getService(final String serviceId) {
        final AbstractService service = services.get(serviceId);
        if (service == null) {
            throw new RuntimeException("Service with id [" + serviceId + "] does not exists or is not register at ServiceLocator class.");
        }
        return service;
    }

    private void registerServices() {

        // Here you must register all game services
        registerService(new GameLoginService());
        registerService(new GetGameRoundService());
        registerService(new GetRecentGameRoundsForUserService());
        registerService(new SaveConfigurationService());
        registerService(new UploadGameRoundService());
        registerService(new UploadStatisticsService());
    }

    private void registerService(final AbstractService service) {
        services.put(service.getId(), service);
    }

}
