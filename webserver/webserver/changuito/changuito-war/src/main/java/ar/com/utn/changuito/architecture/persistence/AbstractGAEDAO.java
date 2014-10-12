package ar.com.utn.changuito.architecture.persistence;

import java.util.*;
import java.util.Map.Entry;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.process.IteratorTransform;
import ar.com.utn.changuito.architecture.process.Retryable;
import ar.com.utn.changuito.architecture.process.RetryableFuture;
import ar.com.utn.changuito.architecture.process.RetryingExecutor;
import com.google.appengine.api.datastore.DatastoreService;
import com.google.appengine.api.datastore.DatastoreServiceFactory;
import com.google.appengine.api.datastore.Entity;
import com.google.appengine.api.datastore.FetchOptions;
import com.google.appengine.api.datastore.Key;
import com.google.appengine.api.datastore.KeyFactory;
import com.google.appengine.api.datastore.Query;

public abstract class AbstractGAEDAO<T extends SharedObject> {

    private DatastoreService datastoreService;
    private Class<T> classType;

    private DatastoreService getDatastoreService() {
        if (datastoreService == null)
            datastoreService = DatastoreServiceFactory.getDatastoreService();
        return datastoreService;
    }

    protected AbstractGAEDAO(final Class<T> classType) {
        this.classType = classType;
    }

    protected abstract String getGAEEntityKind();

    protected abstract void validateEntityModel(final T entityModel) throws ModelValidationException;

    public T getEntityById(final String id) throws Exception {

        final Key key = KeyFactory.createKey(getGAEEntityKind(), id);
        final Entity entity = RetryingExecutor.execute(4, 150, new RetryableFuture<Entity>() {

            private Entity entity;

            public void run() throws Exception {
                this.entity = getDatastoreService().get(key);
            }

            public Entity getValue() {
                return this.entity;
            }
        });

        return convertGAEEntityToEntityModel(entity);
    }

    public Map<Long, T> getEntities(final List<Long> ids) throws Exception {

        // TODO: hacer la lista que devuelve sea un iterator
        final Map<Key, Entity> entities = RetryingExecutor.execute(4, 150, new RetryableFuture<Map<Key, Entity>>() {

            private Map<Key, Entity> entities;

            public void run() throws Exception {
                this.entities = getDatastoreService().get(buildGAEEntityKeys(ids));
            }

            public Map<Key, Entity> getValue() {
                return this.entities;
            }
        });

        final Map<Long, T> domainEntities = new HashMap<Long, T>(entities.size());

        for (final Entry<Key, Entity> entry : entities.entrySet())
            domainEntities.put(entry.getKey().getId(), convertGAEEntityToEntityModel(entry.getValue()));
        return domainEntities;
    }

    public Iterator<T> getEntities(final Query GAEQuery, final int limit) throws Exception {

        final String kind = getGAEEntityKind();
        final Iterable<Entity> entitiesIterator = RetryingExecutor.execute(4, 150, new RetryableFuture<Iterable<Entity>>() {

            private Iterable<Entity> entities;

            public void run() throws Exception {

                final FetchOptions options = FetchOptions.Builder.withLimit(limit);
                this.entities = getDatastoreService().prepare(GAEQuery).asIterable(options);
            }

            public Iterable<Entity> getValue() {
                return this.entities;
            }
        });

        return new IteratorTransform<Entity, T>(entitiesIterator.iterator(),
                new IteratorTransform.Transformer<Entity, T>() {
                    @Override
                    public T transform(final Entity entity) {
                        return convertGAEEntityToEntityModel(entity);
                    }
                });
    }

    public void persist(final T domainEntity) {

        validateEntityModel(domainEntity);

        RetryingExecutor.execute(4, 150, new Retryable() {

            public void run() {

                getDatastoreService().put(convertDomainEntityToGAEEntity(domainEntity));
            }
        });
    }

    private List<Key> buildGAEEntityKeys(final List<Long> ids) {

        final List<Key> keys = new ArrayList<Key>(ids.size());
        for (final Long id : ids) {
            keys.add(KeyFactory.createKey(getGAEEntityKind(), id));
        }
        return keys;
    }

    private Entity convertDomainEntityToGAEEntity(final T domainEntity) {

        final Entity entity = new Entity(getGAEEntityKind());

        for (final String keyName : domainEntity.getKeys()) {
            entity.setProperty(keyName, domainEntity.get(keyName));
        }
        return entity;
    }

    private T convertGAEEntityToEntityModel(final Entity entity) {

        final T instance = getNewentityModelInstance();
        instance.mergeWith(convertGAEEntityToSharedObject(entity));
        return instance;
    }

    private SharedObject convertGAEEntityToSharedObject(final Entity entity) {

        final SharedObject sharedObject = new SharedObject();

        for (final Entry<String, Object> entry : entity.getProperties().entrySet()) {
            sharedObject.set(entry.getKey(), entry.getValue());
        }
        return sharedObject;
    }

    private T getNewentityModelInstance() {
        try {
            return classType.newInstance();
        } catch (final Exception e) {
            throw new RuntimeException("Cannot instanciate [" + classType.getName() + "] class. The reason is: ", e);
        }
    }
}
