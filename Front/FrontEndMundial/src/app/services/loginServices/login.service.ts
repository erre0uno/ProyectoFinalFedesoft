import {Injectable } from '@angular/core';

//imports
import {
  HttpClient,
} from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/app/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  //readonly url = 'https://localhost:44335/api/';
  url: string = environment.url;
  dataEnSesion = new BehaviorSubject(null);

  constructor(private http: HttpClient) {
    this.verificarSesion();
  }

  verificarSesion() {
    let data = this.obtenerSesion();
    if (data) {
      this.refrescarDatosSession(data);
    }
  }

  refrescarDatosSession(datos: any) {
    this.dataEnSesion.next(datos);
  }

  obtenerSesion() {
    let data = sessionStorage.getItem('token');
    if (data) {
      //let data=JSON.parse(data);
      return data;
    } else {
      return null;
    }
  }

  eliminarSesion() {
    sessionStorage.removeItem('token');
    this.refrescarDatosSession('');
  }

  logOut() {
    sessionStorage.removeItem('token');
    this.refrescarDatosSession('');
  }

  seInicioSesion() {
    let dataString = sessionStorage.getItem('token');
    return dataString;
  }

  obtenerDatosUsuarioEnSesion() {
    return this.dataEnSesion.asObservable();
  }

  obtenerToken() {
    let data = sessionStorage.getItem('token');
    if (data) {
      //let token = JSON.parse(dataString);
      return data;
    } else {
      return '';
    }
  }

  //metodos
  //post para login de usuarios
  public post(data: any) {
    return this.http.post(this.url + 'login', data);
  }

  //save token in sessionStorage
  GuardarToken(token: string) {
    sessionStorage.setItem('token', token);
    this.refrescarDatosSession(token);
  }
}
