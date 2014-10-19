package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.model.Login;
import ar.com.utn.changuito.persistence.JuegoStatisticDAO;
import ar.com.utn.changuito.persistence.LoginDAO;

public class LoginService extends GenericService<Login>  {

	@Override
	protected SharedObject typedCall(Login serviceParameter) {
	    final SharedObject response = new SharedObject();

	    response.set("user", serviceParameter.getUser());
	    response.set("pass", serviceParameter.getPass());
		
        new LoginDAO().persist(serviceParameter);

		return response;
	}

	@Override
	public String getId() {
		return "ls";
	}

}
