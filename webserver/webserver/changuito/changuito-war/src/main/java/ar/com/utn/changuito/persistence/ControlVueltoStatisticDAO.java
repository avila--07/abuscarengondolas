package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.ModelValidationException;
import ar.com.utn.changuito.model.ControlVueltoStatistic;
import ar.com.utn.changuito.model.JuegoStatistic;
import ar.com.utn.changuito.model.PagoStatistic;

public class ControlVueltoStatisticDAO extends AbstractGAEDAO<ControlVueltoStatistic> {

    public ControlVueltoStatisticDAO() {
        super(ControlVueltoStatistic.class);
    }

    @Override
    protected String getGAEEntityKind() {
        return "ControlVueltoStatistic";
    }

    @Override
    protected long getId(final ControlVueltoStatistic domainEntity) {
        return domainEntity.getId();
    }

    @Override
    protected void validateEntityModel(final ControlVueltoStatistic entityModel) throws ModelValidationException {
    	
    	//TODO: ver el tipo de la propiedad
        if (entityModel.getId() < 0)
            throw new ModelValidationException("Id cannot be negative");
    }

}
