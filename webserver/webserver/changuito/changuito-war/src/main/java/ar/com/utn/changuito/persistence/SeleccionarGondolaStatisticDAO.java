package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.ModelValidationException;
import ar.com.utn.changuito.model.JuegoStatistic;
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
    protected long getId(final SeleccionarGondolaStatistic domainEntity) {
        return domainEntity.getId();
    }

    @Override
    protected void validateEntityModel(final SeleccionarGondolaStatistic entityModel) throws ModelValidationException {
    	
    	//TODO: ver el tipo de la propiedad
        if (entityModel.getId() < 0)
            throw new ModelValidationException("Id cannot be negative");
    }
}
