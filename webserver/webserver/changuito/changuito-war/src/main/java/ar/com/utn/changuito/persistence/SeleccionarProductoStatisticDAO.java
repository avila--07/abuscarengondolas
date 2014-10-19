package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.DomainModelValidationException;
import ar.com.utn.changuito.model.SeleccionarProductoStatistic;

public class SeleccionarProductoStatisticDAO extends AbstractGAEDAO<SeleccionarProductoStatistic> {

    public SeleccionarProductoStatisticDAO() {
        super(SeleccionarProductoStatistic.class);
    }

    @Override
    protected String getGAEEntityKind() {
        return "SeleccionarProductoStatistic";
    }

    @Override
    protected void validateDomainEntity(final SeleccionarProductoStatistic entityModel) throws DomainModelValidationException {
    	
    	//TODO: ver el tipo de la propiedad
        if (entityModel.getId() < 0)
            throw new DomainModelValidationException("Id cannot be negative");
    }
}
