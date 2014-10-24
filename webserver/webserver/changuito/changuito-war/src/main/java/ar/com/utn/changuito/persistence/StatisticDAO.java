package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.DomainModelValidationException;
import ar.com.utn.changuito.model.Statistic;

public class StatisticDAO extends AbstractGAEDAO<Statistic> {

    public StatisticDAO() {
        super(Statistic.class);
    }

    @Override
    protected String getGAEEntityKind() {
        return "Statistic";
    }

    @Override
    protected void validateDomainEntity(final Statistic entityModel) throws DomainModelValidationException {

        if (entityModel.getId() <= 0)
            throw new DomainModelValidationException("Id cannot be zero or negative");
    }
}
