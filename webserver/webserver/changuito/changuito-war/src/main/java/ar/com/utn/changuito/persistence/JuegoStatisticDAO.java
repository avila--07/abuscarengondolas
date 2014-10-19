package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.DomainModelValidationException;
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
    protected void validateDomainEntity(final JuegoStatistic entityModel) throws DomainModelValidationException {
    	
    	//TODO: ver el tipo de la propiedad
        if (entityModel.getId() < 0)
            throw new DomainModelValidationException("Id cannot be negative");
    }
}
