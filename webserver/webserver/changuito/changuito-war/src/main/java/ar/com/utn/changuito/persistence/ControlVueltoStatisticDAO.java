package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.DomainModelValidationException;
import ar.com.utn.changuito.model.ControlVueltoStatistic;

public class ControlVueltoStatisticDAO extends AbstractGAEDAO<ControlVueltoStatistic> {

    public ControlVueltoStatisticDAO() {
        super(ControlVueltoStatistic.class);
    }

    @Override
    protected String getGAEEntityKind() {
        return "ControlVueltoStatistic";
    }

    @Override
    protected void validateDomainEntity(final ControlVueltoStatistic entityModel) throws DomainModelValidationException {
    	
    	//TODO: ver el tipo de la propiedad
        if (entityModel.getId() < 0)
            throw new DomainModelValidationException("Id cannot be negative");
    }

}
