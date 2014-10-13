package ar.com.utn.changuito.architecture.persistence;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.process.IteratorTransform;
import ar.com.utn.changuito.architecture.process.Retryable;
import ar.com.utn.changuito.architecture.process.RetryableFuture;
import ar.com.utn.changuito.architecture.process.RetryingExecutor;
import com.google.appengine.api.datastore.*;

import java.util.*;

public abstract class AbstractGAEDAO<T extends SharedObject> {

    private DatastoreService datastoreService;
    private Class<T> classType;

    protected AbstractGAEDAO(final Class<T> classType) {
        this.classType = classType;
    }

    protected abstract String getGAEEntityKind();

    protected abstract long getId(final T domainEntity);

    protected abstract void validateEntityModel(final T entityModel) throws ModelValidationException;

    public T getEntityById(final Long id) {

        final Key key = KeyFactory.createKey(getGAEEntityKind(), id);
        final Entity entity = RetryingExecutor.execute(4, 150, new RetryableFuture<Entity>() {

            private Entity entity;

            public void run() {
                try {
                    this.entity = getDatastoreService().get(key);
                } catch (final EntityNotFoundException e) {
                    throw new RuntimeException("Entity with kind [" + getGAEEntityKind() + "] and key [" + id + "] does not exists.", e);
                }
            }

            public Entity getValue() {
                return this.entity;
            }
        });

        return convertGAEEntityToEntityModel(entity);
    }

    public Map<Long, T> getEntities(final List<Long> ids) {

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

        for (final Map.Entry<Key, Entity> entry : entities.entrySet())
            domainEntities.put(entry.getKey().getId(), convertGAEEntityToEntityModel(entry.getValue()));
        return domainEntities;
    }

    public Iterator<T> getEntities(final Query GAEQuery, final int limit) {

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

        final Entity entity = new Entity(getGAEEntityKind(), getId(domainEntity));

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

        for (final Map.Entry<String, Object> entry : entity.getProperties().entrySet()) {
            sharedObject.set(entry.getKey(), entry.getValue());
        }
        return sharedObject;
    }

    private DatastoreService getDatastoreService() {
        if (datastoreService == null)
            datastoreService = DatastoreServiceFactory.getDatastoreService();
        return datastoreService;
    }

    private T getNewentityModelInstance() {
        try {
            return classType.newInstance();
        } catch (final Exception e) {
            throw new RuntimeException("Cannot instanciate [" + classType.getName() + "] class. The reason is: ", e);
        }
    }
}
