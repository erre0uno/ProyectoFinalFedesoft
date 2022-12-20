import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { Goleadores } from 'src/app/models/Goleadores';

@Injectable({
  providedIn: 'root',
})
export class GoleadoresService {
  url = environment.url;
  goleadores!: Goleadores[];

  constructor(private httpclient: HttpClient) {}
  getHttpOptions() {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + sessionStorage.getItem('token'),
      }),
    };
    return httpOptions;
  }

  getGoleadores(): Observable<Goleadores[]> {
    return this.httpclient.get<Goleadores[]>(this.url + 'goleadores');
  }

  getGoleadores_2() {
    this.httpclient
      .get(this.url + 'goleadores')
      .toPromise()
      .then((data) => {
        this.goleadores = data as Goleadores[];

        this.goleadores?.sort((a, b) => (a.goles < b.goles ? 1 : -1));
      });
  }

  updateGoleadores(id: number, posicion: Goleadores): Observable<Goleadores> {
    return this.httpclient.put<Goleadores>(
      this.url + 'goleadores/' + id,
      posicion,
      this.getHttpOptions()
    );
  }
}
