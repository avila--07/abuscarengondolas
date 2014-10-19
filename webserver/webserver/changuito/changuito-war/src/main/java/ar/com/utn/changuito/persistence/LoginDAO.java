package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.ModelValidationException;
import ar.com.utn.changuito.model.Login;
import ar.com.utn.changuito.model.PagoStatistic;

public class LoginDAO extends AbstractGAEDAO<Login> {

	public LoginDAO() {
		super(Login.class);
	}

	private String user;
	private String pass;
	
	public String getUser() {
		return user;
	}
	public void setUser(String user) {
		this.user = user;
	}
	public String getPass() {
		return pass;
	}
	public void setPass(String pass) {
		this.pass = pass;
	}
	@Override
	protected String getGAEEntityKind() {
		return null;
	}
	@Override
    protected long getId(final Login domainEntity) {
        return domainEntity.getId();
    }

	@Override
	protected void validateEntityModel(Login entityModel){
		//TODO: ver el tipo de la propiedad
	    if (entityModel.getId() < 0)
	        throw new ModelValidationException("Id cannot be negative");
	}
}