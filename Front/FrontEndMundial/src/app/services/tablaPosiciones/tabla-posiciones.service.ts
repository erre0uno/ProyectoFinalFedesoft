import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { TablaPosiciones } from 'src/app/models/TablaPosiciones';

@Injectable({
  providedIn: 'root',
})
export class TablaPosicionesService {
  //Consumir Urls
  
  listPosiciones!: TablaPosiciones[];
  url: string = environment.url;
  constructor(private http: HttpClient) {}
  
  getHttpOptions() {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + sessionStorage.getItem('token'),
      }),
    };
    return httpOptions;
  }

  obtenerPosiciones() {
    this.http.get(this.url + "tablaposiciones/").toPromise()
    .then((data) => {
        this.listPosiciones = data as TablaPosiciones[];
        
      });
  }
  actualizarPosciones(id:number,datos:TablaPosiciones):Observable<TablaPosiciones>{
    return this.http.put<TablaPosiciones>(this.url + "tablaposiciones/" + id, datos,  this.getHttpOptions())
  }
  

}
