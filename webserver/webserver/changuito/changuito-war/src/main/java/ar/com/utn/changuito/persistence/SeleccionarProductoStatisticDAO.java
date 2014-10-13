package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.ModelValidationException;
import ar.com.utn.changuito.model.SeleccionarProductoStatistic;
import ar.com.utn.changuito.model.Statistic;

public class SeleccionarProductoStatisticDAO extends AbstractGAEDAO<SeleccionarProductoStatistic> {

    public SeleccionarProductoStatisticDAO() {
        super(SeleccionarProductoStatistic.class);
    }

    @Override
    protected String getGAEEntityKind() {
        return "SeleccionarProductoStatistic";
    }

    @Override
    protected long getId(final SeleccionarProductoStatistic domainEntity) {
        return domainEntity.getId();
    }

    @Override
    protected void validateEntityModel(final SeleccionarProductoStatistic entityModel) throws ModelValidationException {
    	
    	//TODO: ver el tipo de la propiedad
        if (entityModel.getId() < 0)
            throw new ModelValidationException("Id cannot be negative");
    }
}
