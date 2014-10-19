package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.DomainModelValidationException;
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
    protected void validateDomainEntity(final PagoStatistic entityModel) throws DomainModelValidationException {
    	
    	//TODO: ver el tipo de la propiedad
        if (entityModel.getId() < 0)
            throw new DomainModelValidationException("Id cannot be negative");
    }

}
