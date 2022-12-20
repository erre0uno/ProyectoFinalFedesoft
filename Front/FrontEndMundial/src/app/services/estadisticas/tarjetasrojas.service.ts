import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { TarjetaRoja } from 'src/app/models/TarjetaRoja';

@Injectable({
  providedIn: 'root',
})
export class TarjetasrojasService {
  url = environment.url;
  tarjetasrojas!: TarjetaRoja[];

  constructor(private httpclient: HttpClient) {}

  getHttpOptions() {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + sessionStorage.getItem('token'),
      }),
    };
    return httpOptions;
  }

  getTarjetasRojas(): Observable<TarjetaRoja[]> {
    return this.httpclient.get<TarjetaRoja[]>(this.url + 'tarjetasrojas');
  }

  getTarjetasRojas_2() {
    this.httpclient
      .get(this.url + 'tarjetasrojas')
      .toPromise()
      .then((data) => {
        this.tarjetasrojas = data as TarjetaRoja[];

        this.tarjetasrojas?.sort((a, b) => (a.numero < b.numero ? 1 : -1));
      });
  }

  updateTarjetasRojas(
    id: number,
    posicion: TarjetaRoja
  ): Observable<TarjetaRoja> {
    return this.httpclient.put<TarjetaRoja>(
      this.url + 'tarjetasrojas/' + id,
      posicion,
      this.getHttpOptions()
    );
  }
}
