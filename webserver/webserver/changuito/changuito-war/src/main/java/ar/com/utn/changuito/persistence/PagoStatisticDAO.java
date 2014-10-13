package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.ModelValidationException;
import ar.com.utn.changuito.model.JuegoStatistic;
import ar.com.utn.changuito.model.PagoStatistic;

public class PagoStatisticDAO extends AbstractGAEDAO<PagoStatistic> {

    public PagoStatisticDAO() {
        super(PagoStatistic.class);
    }

    @Override
    protected String getGAEEntityKind() {
        return "PagoStatistic";
    }

    @Override
    protected long getId(final PagoStatistic domainEntity) {
        return domainEntity.getId();
    }

    @Override
    protected void validateEntityModel(final PagoStatistic entityModel) throws ModelValidationException {
    	
    	//TODO: ver el tipo de la propiedad
        if (entityModel.getId() < 0)
            throw new ModelValidationException("Id cannot be negative");
    }

}
