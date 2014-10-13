package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.ModelValidationException;
import ar.com.utn.changuito.model.JuegoStatistic;

public class JuegoStatisticDAO extends AbstractGAEDAO<JuegoStatistic> {

    public JuegoStatisticDAO() {
        super(JuegoStatistic.class);
    }

    @Override
    protected String getGAEEntityKind() {
        return "JuegoStatistic";
    }

    @Override
    protected long getId(final JuegoStatistic domainEntity) {
        return domainEntity.getId();
    }

    @Override
    protected void validateEntityModel(final JuegoStatistic entityModel) throws ModelValidationException {
    	
    	//TODO: ver el tipo de la propiedad
        if (entityModel.getId() < 0)
            throw new ModelValidationException("Id cannot be negative");
    }
}
