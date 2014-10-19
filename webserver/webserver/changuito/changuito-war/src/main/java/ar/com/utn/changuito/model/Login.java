package ar.com.utn.changuito.model;

import ar.com.utn.changuito.architecture.net.SharedObject;

public class Login extends SharedObject  {

	public void setUser(String user){
		set("user",user);
	}

	public String getUser(){
		return getString("user");
	}
	
	public void setPass(String pass){
		set("pass",pass);
	}
	
	public String getPass(){
		return getString("pass");
	}
	
	public Login(final SharedObject sharedObject) {
		super(sharedObject);
	}

	//TODO: Implementar solucion a los ID
	public long getId() {
		return 0;
	}
}
