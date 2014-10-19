package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.DomainModelValidationException;
import ar.com.utn.changuito.model.SeleccionarGondolaStatistic;

public class SeleccionarGondolaStatisticDAO extends AbstractGAEDAO<SeleccionarGondolaStatistic> {

    public SeleccionarGondolaStatisticDAO() {
        super(SeleccionarGondolaStatistic.class);
    }

    @Override
    protected String getGAEEntityKind() {
        return "SeleccionarGondolaStatistic";
    }

    @Override
    protected void validateDomainEntity(final SeleccionarGondolaStatistic entityModel) throws DomainModelValidationException {
    	
    	//TODO: ver el tipo de la propiedad
        if (entityModel.getId() < 0)
            throw new DomainModelValidationException("Id cannot be negative");
    }
}
